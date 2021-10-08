
using Synergex.xfnlnet;
using SynergyClient;

namespace WebClientApp
{
    internal class PoolPolicyHelper
    {
        public static BlockingPooledObjectPolicy<SynergyMethods> CreatePolicy(string host="localhost", int port=2356)
        {
            // SynergyMethods interface has all 5 pooling support methods
            return new BlockingPooledObjectPolicy<SynergyMethods>(2, 1)
            {
                //If Initialize and Cleanup are not used, include this code!

                //Initialize = (myPoolObject) =>
                //{
                //    myPoolObject.connect(host, port);
                //},
                //Cleanup = (myPoolObject) =>
                //{
                //    myPoolObject.disconnect();
                //}

                //The Initialize action should always be declared
                Initialize = (poolObject) =>
                {
                    poolObject.connect(host, port);
                    //But comment out the next line if there is no Initialize method in the interface
                    poolObject.Initialize();    
                },
                //The Cleanup action should always be declared
                Cleanup = (poolObject) =>
                {
                    //But comment out the next line if there is no Cleanup method in the interface
                    poolObject.Cleanup();
                    poolObject.disconnect();
                },
                //Only include the Activate action if there is an Activate method in the interface
                Activate = (poolObject) => {
                    poolObject.Activate();
                },
                //Only include the Deactivate action if there is a Deactivate method in the interface
                Deactivate = (poolObject) => {
                    poolObject.Deactivate();
                },
                //Only include the CanBePooled action if there is a CanBePooled method in the interface
                CanBePooled = (poolObject) => {
                    return poolObject.CanBePooled();
                }
            };
        }
    }
}