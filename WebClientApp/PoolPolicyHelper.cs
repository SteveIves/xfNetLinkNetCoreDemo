
using Synergex.xfnlnet;
using SynergyClient;

namespace WebClientApp
{
    internal class PoolPolicyHelper
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