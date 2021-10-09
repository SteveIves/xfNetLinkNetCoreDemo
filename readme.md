
# xfNetLink .NET Core Pooling Example

This repository contains an example of how to implement object pooling in an ASP.NET Core client application
that is using xfNetLink .NET Core to interact with a traditional Synergy xfServerPlus environment.

## Introduction

Unlike implementing object pooling in .NET Framework applications, where COM+ Pooling is available for use, implementing
object pooling in .NET (Core) applications is something that is done within the code of the client application.

## Steps

There are several steps involved in implementing an object pooling environment within your ASP.NET Core web application. The basic steps are:

* Add pooling support methods to your traditional Synergy interface
* Define a pooling policy
* Define pool characteristics
* Create a pool service in your client application
* Use pooled client objects to make method calls

## Adding Pooling Support Methods

You may or may not need to add one or more "pooling support" methods to your traditional Synergy environment. These are methods that are 
called automatically by the pooling environment to allow you to execute code at various times during the lifetime of a pooled object. There
are five pooling support methods, all of which are optional:

* Initialize
* Activate
* Deactivate
* CanBePooled
* Cleanup

The functionality of each of these methods is discussed below.

### Adding an Initialize Method

If present, the Initialize method is called when a new object is being created and added to the pool. The purpose of the method is to perform
any early initialization code that can be executed in advance of the object being assigned to a specific client. Typically the Initialize
method is used to open data files and perform other early startup operations.

The Initialize method is a function that returns a ^VAL value:

```
    {xfMethod(interface="MyInterface",elb="EXE:MyElb")}
    function Initialize, ^val
    proc
        ;TODO: Add initialization code here

        freturn 0
    end
```

The Initialize function should return 0 if the initialization was successful, or 1 if initialization failed.

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

### Adding an Deactivate Method

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

The CanBePooled method is a function that returns a ^VAL value:

```
    {xfMethod(interface="MyInterface",elb="EXE:MyElb")}
    function CanBePooled, ^val
    proc
        ;TODO: Add code to determine of the object can be reused here

        freturn 1
    end
```

The CanBePooled function should return 1 if the object can be returned to the pool, and 0 if it should be discarded.

### Adding an Cleanup Method

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

## Defining a Pooling Policy

## Defining Pool Characteristics

## Creating a Pool Service

## Using Pooled Client Objects


