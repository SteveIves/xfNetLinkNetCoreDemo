
using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.ObjectPool;
using System.Collections.Generic;
using Synergex.xfnlnet;
using SynergyClient;

namespace WebClientApp.Pool
{
    internal class PoolPolicyHelper
    {
        public static BlockingPooledObjectPolicy<SynergyMethods> SetupPolicy(string host="localhost", int port=2356)
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

                Initialize = (myPoolObject) =>
                {
                    myPoolObject.connect(host, port);
                    myPoolObject.Initialize();
                },
                Activate = (myPoolObject) => {
                    myPoolObject.Activate();
                },
                Deactivate = (myPoolObject) => {
                    myPoolObject.Deactivate();
                },
                CanBePooled = (myPoolObject) => {
                    return myPoolObject.CanBePooled();
                },
                Cleanup = (myPoolObject) =>
                {
                    myPoolObject.Cleanup();
                    myPoolObject.disconnect();
                }
            };
        }
    }
}