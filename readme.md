
# xfNetLink .NET Core Pooling Example

This repository contains an example of how to implement object pooling in an ASP.NET Core client application
that is using xfNetLink .NET Core to interact with a traditional Synergy xfServerPlus environment.

## Introduction

Unlike implementing object pooling in .NET Framework applications, where COM+ Pooling is available for use, implementing
object pooling in .NET (Core) applications is something that is done within the code of the client application.

## Steps

There are several steps involved in implementing an object pooling environment within your ASP.NET Core web application. The basic steps are:

* [Add pool support methods](#adding-pool-support-methods)
* [Define pool characteristics](#defining-pool-characteristics)
* [Define a pool policy](#defining-a-pool-policy)
* [Create a pool service](#creating-a-pool-service)
* [Use pooled objects](#using-pooled-objects)

## Adding Pool Support Methods

You may or may not need to add one or more "pooling support" methods to your traditional Synergy environment. These are methods that are 
called automatically by the pooling environment to allow you to execute code at various times during the lifetime of a pooled object. There
are five pooling support methods, all of which are optional:

* [Initialize](#adding-an-initialize-method)
* [Activate](#adding-an-activate-method)
* [Deactivate](#adding-a-deactivate-method)
* [CanBePooled](#adding-a-canbepooled-method)
* [Cleanup](#adding-a-cleanup-method)

The functionality of each of these methods is discussed below.

### Adding an Initialize Method

If present, the Initialize method is called when a new object is being created and added to the pool. The purpose of the method is to perform
any early initialization code that can be executed in advance of the object being assigned to a specific client. Typically the Initialize
method is used to open data files and perform other early startup operations.

The Initialize method is a function that returns a ^VAL value. The routine should return 0 if the initialization was successful, or 1 if initialization failed.

```
{xfMethod(interface="MyInterface",elb="EXE:MyElb")}
function Initialize, ^val
proc
    ;TODO: Add initialization code here

    freturn 0
end
```

### Adding an Activate Method

If present, the Activate method is called when an object that is currently in the pool is being assigned to a specific client for actual use.

The Activate method is a subroutine:

```
{xfMethod(interface="SynergyMethods",elb="EXE:SynergyMethods")}
subroutine Activate
proc
    ;TODO: Add activate code here

    xreturn
endsubroutine
```

### Adding a Deactivate Method

If present, the Deactivate method is called when an object that was previously assigned to a specific client is being released by that client.

The Deactivate method is a subroutine:

```
{xfMethod(interface="SynergyMethods",elb="EXE:SynergyMethods")}
subroutine Deactivate
proc
    ;TODO: Add deactivate code here

    xreturn
endsubroutine
```

### Adding a CanBePooled Method

If present, the CanBePooled method is called immediately after the Deactivate method. The purpose of the method is to determine whether the
released object can be returned to the pool for reuse, or whether it should be discarded and replaced by a new object.

The CanBePooled method is a function that returns a ^VAL value. The routine should return 1 if the object can be returned to the pool, and 0 if it should be discarded.

```
{xfMethod(interface="MyInterface",elb="EXE:MyElb")}
function CanBePooled, ^val
proc
    ;TODO: Add code to determine of the object can be reused here

    freturn 1
end
```

### Adding a Cleanup Method

If present, the Cleanup method is called when an object that was previously assigned to a specific client is being released by that client.

The Cleanup method is a subroutine:

```
{xfMethod(interface="SynergyMethods",elb="EXE:SynergyMethods")}
subroutine Cleanup
proc
    ;TODO: Add cleanup code here

    xreturn
endsubroutine
```


When you are done adding the pooling support methods it is time to use the gencs utility re-generate your xfNetLink .NET client code.

## Defining Pool Characteristics

There are several pieces of information that you will need to provide when implementing an object pool. These are:

* xfServerPlus host system (name or IP address)
* xfServerPlus listener port (2356 or some other custom value)
* Maximum pool size
* Maximum idle pool size

We suggest that you specify these settings via your ASP.NET applications configuration system, by adding them to the appsettings.json file, like this:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "xfServerPlusHost": "localhost",
  "xfServerPlusPort": 2356,
  "PoolMaxSize": 4,
  "PoolMaxIdle": 2
}
```
In this example, the final four settings in the file (xfServerPlusHost, xfServerPlusPort, PoolMaxSize and PoolMaxIdle) represent the pool characteristics.

## Defining a Pool Policy

A pool policy determines the xfServerPlus instance that objects in the pool will connect to, as well as which (if any) pool support
methods will be used. We recommend that you implement a helper method that can be called to create and return an instance of the pool
policy object, like this:

```
using Synergex.xfnlnet;
using SynergyClient;

namespace WebClientApp
{
    internal class SynergyMethodsPoolPolicyHelper
    {
        public static BlockingPooledObjectPolicy<SynergyMethods> CreatePolicy(
            string host = "localhost",
            int port = 2356,
            int poolMaxSize = 4,
            int poolMaxIdle = 2)
        {
            // SynergyMethods interface has all 5 pooling support methods
            return new BlockingPooledObjectPolicy<SynergyMethods>(poolMaxSize, poolMaxIdle)
            {
                //The Initialize action should ALWAYS be declared
                Initialize = (poolObject) =>
                {
                    poolObject.connect(host, port);
                    //TODO: Comment out the next line if there is no Initialize method in the interface
                    poolObject.Initialize();
                },
                //The Cleanup action should ALWAYS be declared
                Cleanup = (poolObject) =>
                {
                    //TODO: Comment out the next line if there is no Cleanup method in the interface
                    poolObject.Cleanup();
                    poolObject.disconnect();
                },
                //TODO: Remove the Activate action if there is no Activate method in the interface
                Activate = (poolObject) =>
                {
                    poolObject.Activate();
                },
                //TODO: Remove the Deactivate action if there is no Deactivate method in the interface
                Deactivate = (poolObject) =>
                {
                    poolObject.Deactivate();
                },
                //TODO: Remove the CanBePooled action if there is no CanBePooled method in the interface
                CanBePooled = (poolObject) =>
                {
                    return poolObject.CanBePooled();
                }
            };
        }
    }
}
```

In this example `SynergyMethods` represents the name of the xfNetLink client class (interface) that you wish to pool.
Notice how default values for the pool characteristics are provided, but can be overridden by passing
in different values via parameters.

## Creating a Pool Service

The next step in the process is to create an instance of a pool of your client objects, and to register it with the Dependency Injection environment as a
service that other (Controller) classes can request. In ASP.NET Core applications, this type of configuration generally takes place in the ConfigureServices
method of the Startup class. You will need to add code to that method, something like this:

```
//Create an object pool and make it available via Dependency Injection
services.AddSingleton<ObjectPool<SynergyMethods>>(
    new DefaultObjectPool<SynergyMethods>(
        SynergyMethodsPoolPolicyHelper.CreatePolicy(
            Configuration.GetValue<string>("xfServerPlusHost"),
            Configuration.GetValue<int>("xfServerPlusPort"),
            Configuration.GetValue<int>("PoolMaxSize"),
            Configuration.GetValue<int>("PoolMaxIdle")
        )
    )
);
```

In this example, `SynergyMethods` represents the name of the xfServerPlus client object (interface) that is being pooled. Notice how the code is calling the
pooling policy helper method that you created earlier, and how the values for the pool configuration settings are being obtained via `Configuration.GetValue`
which reads them from the `appsettings.json` file.

## Using Pooled Objects

Now that you have a pool of your client objects available for use in your application, all that remains is to obtain a copy of the pool, and use it to obtain
pooled instances of your client objects whenever your application needs to interact with the xfServerPlus methods. Hers is an example of doing so in an ASP.NET
MVC Controller class.

The first step is to define a class variable to represent an instance of your pool:

```
private ObjectPool<SynergyMethods> _pool;
```

Next, in the controllers constructor method, add a parameter to receive an instance of the pool, and save the object reference to the class variable you
defined earlier. Here is an example:

```
public HomeController(ILogger<HomeController> logger, ObjectPool<SynergyMethods> pool)
{
    _logger = logger;
    _pool = pool;       //Instance of pool from Dependency Injection
}
```
Now that you have an instance of the pool, you can use it to obtain a client object from the pool whenever you need to make a call to an xfServerPlus method:

```
//Get a client object from the pool
SynergyMethods client = _pool.Get();

try
{
    //Use the object to make an xfServerPlus method call
    ArrayList customers;
    client.GetAllCustomers(out customers);

    //Use the object to make a second xfServerPlus method call
    Customer c = (Customer)customers[1];
    ArrayList contacts;
    client.GetCustomerContacts(c.Customer_id, out contacts);
}
finally
{
    //When done, return the object to the pool
    _pool.Return(client);
}

```

Note how the try/finally construct is used to guarantee that the client object is always returned to the pool, regardless of the outcome of any particular method call.
