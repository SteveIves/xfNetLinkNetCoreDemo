
using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.ObjectPool;
using System.Collections.Generic;
using Synergex.xfnlnet;

namespace WebClientApp.Pool
{
    // This is the .NET Core version of PoolTester
    // For COM+ Pooling in .NET Framework, use PoolTester.cs
    internal class PoolTester
    {
        private string m_fail = "";
        private string m_where = "";
        private string m_host = "localhost";
        private int m_port = 2356;
        private int m_failedtests;
        private int m_maxlicenses;
        private BlockingPooledObjectPolicy<pooltestscoreNS.Pool1> m_poolPolicy1;
        private BlockingPooledObjectPolicy<pooltestscoreNS.Pool2> m_poolPolicy2;
        private BlockingPooledObjectPolicy<pooltestscoreNS.Pool3> m_poolPolicy3;
        private BlockingPooledObjectPolicy<pooltestscoreNS.Pool4> m_poolPolicy4;
        private BlockingPooledObjectPolicy<pooltestscoreNS.Pool5> m_poolPolicy5;
        private BlockingPooledObjectPolicy<pooltestscoreNS.Pool6> m_poolPolicy6;

        private void testFail([CallerMemberName] string methodName = "")
        {
            m_failedtests++;
            Console.WriteLine("FAILED");
            if (m_fail.Length > 0)
                m_fail = m_fail + ", " + m_where;
            else
                m_fail = m_where;

            m_fail = m_fail + " (" + methodName + ")";
        }

        public void setPoolInfo(string host, int port)
        {
            m_host = host;
            m_port = port;
        }

        private void setupPolicies(int maxlicenses)
        {
            // Pool1 interface has no pooling support methods
            m_poolPolicy1 = new BlockingPooledObjectPolicy<pooltestscoreNS.Pool1>(2, 1)
            {
                Initialize = (myPoolObject) =>
                {
                    myPoolObject.connect(m_host, m_port);
                    PoolLogger.LogConnect();
                },
                Cleanup = (myPoolObject) =>
                {
                    myPoolObject.disconnect();
                    PoolLogger.LogDisconnect();
                }
            };

            // Pool2 interface has Initialize and Cleanup pooling support methods.
            m_poolPolicy2 = new BlockingPooledObjectPolicy<pooltestscoreNS.Pool2>(2, 1)
            {
                Initialize = (myPoolObject) =>
                {
                    myPoolObject.connect(m_host, m_port);
                    PoolLogger.LogConnect();
                    myPoolObject.Initialize();
                    PoolLogger.LogInitialization();
                },
                Cleanup = (myPoolObject) =>
                {
                    myPoolObject.Cleanup();
                    PoolLogger.LogCleanup();
                    myPoolObject.disconnect();
                    PoolLogger.LogDisconnect();
                }
            };

            // Pool3 interface has Initialize, Activate, Deactivate, and Cleanup pooling support methods.
            // It's used in the license test, so the maximum pool size should be greater than the maximum
            // number of licenses
            m_poolPolicy3 = new BlockingPooledObjectPolicy<pooltestscoreNS.Pool3>(maxlicenses + 1, 1)
            {
                Initialize = (myPoolObject) =>
                {
                    myPoolObject.connect(m_host, m_port);
                    PoolLogger.LogConnect();
                    myPoolObject.Initialize();
                    PoolLogger.LogInitialization();
                },
                Activate = (myPoolObject) => {
                    myPoolObject.Activate();
                    PoolLogger.LogActivation();
                },
                Deactivate = (myPoolObject) => {
                    myPoolObject.Deactivate();
                    PoolLogger.LogDeactivation();
                },
                Cleanup = (myPoolObject) =>
                {
                    myPoolObject.Cleanup();
                    PoolLogger.LogCleanup();
                    myPoolObject.disconnect();
                    PoolLogger.LogDisconnect();
                }
            };

            // Pool4 interface has Cleanup pooling support method.
            m_poolPolicy4 = new BlockingPooledObjectPolicy<pooltestscoreNS.Pool4>(2, 1)
            {
                Initialize = (myPoolObject) =>
                {
                    myPoolObject.connect(m_host, m_port);
                    PoolLogger.LogConnect();
                },
                Cleanup = (myPoolObject) =>
                {
                    myPoolObject.Cleanup();
                    PoolLogger.LogCleanup();
                    myPoolObject.disconnect();
                    PoolLogger.LogDisconnect();
                }
            };

            // Pool5 interface has CanBePooled pooling support method.
            m_poolPolicy5 = new BlockingPooledObjectPolicy<pooltestscoreNS.Pool5>(2, 1)
            {
                Initialize = (myPoolObject) =>
                {
                    myPoolObject.connect(m_host, m_port);
                    PoolLogger.LogConnect();
                },
                CanBePooled = (myPoolObject) => {
                    PoolLogger.LogCanBePooled();
                    return myPoolObject.CanBePooled();
                },
                Cleanup = (myPoolObject) =>
                {
                    myPoolObject.disconnect();
                    PoolLogger.LogDisconnect();
                }
            };

            // Pool6 interface has Activate and Deactivate pooling support methods.
            m_poolPolicy6 = new BlockingPooledObjectPolicy<pooltestscoreNS.Pool6>(2, 1)
            {
                Initialize = (myPoolObject) =>
                {
                    myPoolObject.connect(m_host, m_port);
                    PoolLogger.LogConnect();
                },
                Activate = (myPoolObject) => {
                    myPoolObject.Activate();
                    PoolLogger.LogActivation();
                },
                Deactivate = (myPoolObject) => {
                    myPoolObject.Deactivate();
                    PoolLogger.LogDeactivation();
                },
                Cleanup = (myPoolObject) =>
                {
                    myPoolObject.disconnect();
                    PoolLogger.LogDisconnect();
                }
            };
        }

        internal int Run(bool poolingTestsEnabled, int maxlicenses, int testnumber)
        {
            m_maxlicenses = maxlicenses;
            int testindex = 0;
            m_failedtests = 0;
            m_fail = "";
            List<String> testsToRun = new List<String> {
                "Pool component",
                "Initialize/cleanup",
                "Init/activate/deactivate/cleanup",
                "cleanup",
                "canbepooled",
                "activate/deactivate",
                "License error",
                "Load test"};

            Console.WriteLine("");
            Console.WriteLine("************************** {0,-2} - Running Pooling Tests **************************",
                (int)TestCategories.POOLING);
            Console.WriteLine("--------------------------------------------------------------------------------");

            if (!poolingTestsEnabled)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("All Pooling tests are currently skipped");
                Console.WriteLine("--------------------------------------------------------------------------------");
                return 0;
            }

            if (testnumber < 0 || testnumber > testsToRun.Count)
            {
                Console.WriteLine("Error: {0} is not a valid test number", testnumber);
                Console.WriteLine("Pooling Tests FAILED");
                return 1;
            }

            setupPolicies(maxlicenses);

            foreach (string s in testsToRun)
            {
                try
                {
                    testindex = testsToRun.IndexOf(s) + 1;
                    m_where = testindex + ". " + s;

                    // If a specific test was specified, skip all other tests
                    if (testnumber != 0 && testindex != testnumber)
                        continue;

                    Console.Write(m_where);
                    int spacing = 72 - m_where.Length;
                    for (int i = 0; i < spacing; i++)
                    {
                        Console.Write(".");
                    }

                    switch (s)
                    {
                        case "Pool component":
                            poolComponent();
                            break;
                        case "Initialize/cleanup":
                            initCleanup();
                            break;
                        case "Init/activate/deactivate/cleanup":
                            initActDeactCleanup();
                            break;
                        case "cleanup":
                            cleanItUp();
                            break;
                        case "canbepooled":
                            canBePooledMethod();
                            break;
                        case "activate/deactivate":
                            actDeactivate();
                            break;
                        case "License error":
                            LicenseError();
                            break;
                        case "Load test":
                            LoadTest();
                            break;
                        default:
                            throw new Exception("unknown test:" + s);
                    }
                }
                catch (Exception e2)
                {
                    testFail();
                    Console.WriteLine(e2.ToString());
                }

            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            if (testnumber == 0)
            {
                if (m_failedtests == 0)
                    Console.WriteLine("All {0} tests succeeded", testsToRun.Count);
                else
                    Console.WriteLine("These tests FAILED: {0}", m_fail);
            }
            else
            {
                if (m_failedtests == 0)
                    Console.WriteLine("Test {0} succeeded ({1})", testnumber, testsToRun[testnumber - 1]);
                else
                    Console.WriteLine("Test FAILED: {0}", m_fail);
            }
            Console.WriteLine("--------------------------------------------------------------------------------");

            return m_failedtests;
        }


        // Test 1
        // This is the simplest version of the pooling test. It sends a string to the server in setGreeting(),
        // and gets back the same string in getGreeting(). No connection is explicitly made or shared, so for
        // these tests to work a pool must exist and be able to connect to the server.
        // No pooling support methods are present in the Pool1 interface.
        private void poolComponent()
        {
            try
            {
                PoolLogger.Reset();
                string astr = "Hello is your name Sam";
                string bstr = "";
                var pool = new DefaultObjectPool<pooltestscoreNS.Pool1>(m_poolPolicy1);
                var pl1 = pool.Get();

                pl1.setGreeting(astr);
                pl1.getGreeting(ref bstr);
                pool.Return(pl1);

                if (astr != bstr ||
                    PoolLogger.ConnectCalls != 1 ||
                    PoolLogger.InitializeCalls != 0 ||
                    PoolLogger.ActivateCalls != 0 ||
                    PoolLogger.CanBePooledCalls != 0 ||
                    PoolLogger.DeactivateCalls != 0 ||
                    PoolLogger.CleanupCalls != 0 ||
                    PoolLogger.DisconnectCalls != 0)
                    testFail();
                else
                    Console.WriteLine("Passed");

            }
            catch (Exception ea)
            {
                testFail();
                Console.WriteLine(ea.Message);
            }
        }


        // Test 2
        // This test behaves the same as poolComponent(), except that the Pool2 interface includes
        // the Initialize and Cleanup pooling support methods.
        // These methods may not actually be called. For example, Initialize() won't be run if the
        // pool is already started, and Cleanup() won't be run if the object is returned to the
        // pool. 
        private void initCleanup()
        {
            try
            {
                PoolLogger.Reset();

                string astr = "Hello is your name Sam";
                string bstr = "";
                var pool = new DefaultObjectPool<pooltestscoreNS.Pool2>(m_poolPolicy2);
                var pl2 = pool.Get();

                pl2.setGreeting(astr);
                pl2.getGreeting(ref bstr);
                pool.Return(pl2);

                if (astr != bstr ||
                    PoolLogger.ConnectCalls != 1 ||
                    PoolLogger.InitializeCalls != 1 ||
                    PoolLogger.ActivateCalls != 0 ||
                    PoolLogger.CanBePooledCalls != 0 ||
                    PoolLogger.DeactivateCalls != 0 ||
                    PoolLogger.CleanupCalls < 0 ||
                    PoolLogger.CleanupCalls > 1 ||
                    PoolLogger.DisconnectCalls != 0)
                    testFail();
                else
                    Console.WriteLine("Passed");

            }
            catch (Exception ea)
            {
                testFail();
                Console.WriteLine(ea.Message);
            }

        }

        // Test 3
        // This test behaves the same as poolComponent() and initCleanup(), except that the Pool3
        // interface includes the Activate and Deactivate  pooling support methods, as well as 
        // Initialize and Cleanup. To add additional verification that the Activate() method
        // is being called, this test now also checks that the initial greeting matches a value
        // that the Activate() method now sets.
        private void initActDeactCleanup()
        {
            try
            {
                PoolLogger.Reset(); 

                string astr = "Hello is your name Sam";
                string bstr = "";
                string cstr = "";

                var pool = new DefaultObjectPool<pooltestscoreNS.Pool3>(m_poolPolicy3);
                var pl3 = pool.Get();
                pl3.getGreeting(ref cstr);
                pl3.setGreeting(astr);
                pl3.getGreeting(ref bstr);
                pool.Return(pl3);
                if ((astr != bstr) || (cstr != "Activate method called") ||
                    PoolLogger.ConnectCalls != 1 ||
                    PoolLogger.InitializeCalls != 1 ||
                    PoolLogger.ActivateCalls != 1 ||
                    PoolLogger.CanBePooledCalls != 0 ||
                    PoolLogger.DeactivateCalls != 1 ||
                    PoolLogger.CleanupCalls < 0 ||
                    PoolLogger.CleanupCalls > 1 ||
                    PoolLogger.DisconnectCalls != 0)
                    testFail();
                else
                    Console.WriteLine("Passed");
            }
            catch (Exception e)
            {
                string spcr = " | ";
                string errmsg = e.Message + spcr;
                if (e.InnerException != null)
                {
                    errmsg += e.InnerException.Message + spcr;
                    if (e.InnerException is System.Net.Sockets.SocketException)
                    {
                        System.Net.Sockets.SocketException se = (System.Net.Sockets.SocketException)e.InnerException;
                        errmsg += se.ErrorCode;
                    }
                }
                testFail();
                Console.WriteLine(e.Message);
            }
        }


        // Test 4
        // This test behaves the same as poolComponent(), initCleanup(), and initActDeactCleanup(),
        // except that the Pool4 interface includes Cleanup but none of the otherpooling support methods.
        // Cleanup() may not be run (e.g. if poolreturn is enabled and the object is returned to the 
        // pool), so this test doesn't actually verify whether the Cleanup method is called, but simply
        // tests that the pooled object works as expected when the interface includes the Cleanup support
        // method.
        private void cleanItUp()
        {
            try
            {
                PoolLogger.Reset();
                string astr = "Hello is your name Sam";
                string bstr = "";
                var pool = new DefaultObjectPool<pooltestscoreNS.Pool4>(m_poolPolicy4);
                var pl4 = pool.Get();
                pl4.setGreeting(astr);
                pl4.getGreeting(ref bstr);

                if (astr != bstr ||
                    PoolLogger.ConnectCalls != 1 ||
                    PoolLogger.InitializeCalls != 0 ||
                    PoolLogger.ActivateCalls != 0 ||
                    PoolLogger.CanBePooledCalls != 0 ||
                    PoolLogger.DeactivateCalls != 0 ||
                    PoolLogger.CleanupCalls < 0 ||
                    PoolLogger.CleanupCalls > 1 ||
                    PoolLogger.DisconnectCalls != 0)
                    testFail();
                else
                    Console.WriteLine("Passed");
                pool.Return(pl4);

            }
            catch (Exception e)
            {
                testFail();
                Console.WriteLine(e.Message);
            }
        }

        // Test 5
        // This test behaves the same as poolComponent(), initCleanup(), initActDeactCleanup(), and 
        // cleanItUp(), except that the Pool5 interface includes CanBePooled but none of the other pooling
        // support methods.
        // CanBePooled should be called each time a Pool5 object is released. Previously, it always returned 1,
        // indicating that the object should always be returned to the pool, even if the poolreturn is
        // true. This test verifies this by allocating a new object after finishing with the first one.
        // If the previous object was returned to the pool, it should be re-used as the new object. And
        // because the object doesn't clean up its memory, the greeting set in the previous object should
        // still be valid. The test gets the message without setting it and confirms that it's the same as
        // before.
        // The server-side CanBePooled routine has been updated to return 0 if the greeting in the object
        // is set to "Do not return".  Otherwise, it reutrns 1 as before.  This allows the client to control the
        // behavior of CanBePooled and determine whether the object is returned to the pool or not. This test now
        // verifies that the first allocated object is returned to the pool, and the second one isn't.
        private void canBePooledMethod()
        {
            try
            {
                PoolLogger.Reset();
                string astr = "Hello is your name Sam";
                string bstr = "";
                string cstr = "";
                string dstr = "Do not return";
                string estr = "";

                var pool = new DefaultObjectPool<pooltestscoreNS.Pool5>(m_poolPolicy5);
                Pool5 pl5 = pool.Get();
                pl5.setGreeting(astr);
                pl5.getGreeting(ref bstr);
                pool.Return(pl5);

                if (astr != bstr)
                    testFail();
                else
                {
                    pl5 = pool.Get();
                    pl5.getGreeting(ref cstr);
                    pl5.setGreeting(dstr);

                    //cstr should be the same as the greeting we set in the previous object, because CanBePooled
                    // should have returned 1 and the object should have been returned to the pool.
                    if (astr != cstr ||
                        PoolLogger.ConnectCalls != 1 ||
                        PoolLogger.InitializeCalls != 0 ||
                        PoolLogger.ActivateCalls != 0 ||
                        PoolLogger.CanBePooledCalls != 1 ||
                        PoolLogger.DeactivateCalls != 0 ||
                        PoolLogger.CleanupCalls != 0 ||
                        PoolLogger.DisconnectCalls != 0)
                        testFail();
                    else
                    {
                        pool.Return(pl5);
                        pl5 = pool.Get();
                        pl5.getGreeting(ref cstr);
                        pool.Return(pl5);

                        //estr should NOT be the same as the greeting we set in the previous object, because
                        // CanBePooled should have returned 0 and the object should have been discarded.
                        if (dstr == estr ||
                            PoolLogger.ConnectCalls != 2 ||
                            PoolLogger.InitializeCalls != 0 ||
                            PoolLogger.ActivateCalls != 0 ||
                            PoolLogger.CanBePooledCalls != 3 ||
                            PoolLogger.DeactivateCalls != 0 ||
                            PoolLogger.CleanupCalls != 0 ||
                            PoolLogger.DisconnectCalls != 1)
                            testFail();
                        else
                            Console.WriteLine("Passed");
                    }
                }
            }
            catch (Exception e)
            {
                testFail();
                Console.WriteLine(e.Message);
            }
        }

        // Test 6
        // This test behaves the same as poolComponent(), initCleanup(), initActDeactCleanup(),
        // cleanItUp(), and canBePooledMethod(), except that the Pool6 interface includes Activate and
        // Deactivate but none of the other pooling support methods.
        // As with initActDeactCleanup(), previously, this test simply ran setGreeting and getGreeting
        // like the previous tests. But to add additional verification that the Activate() method
        // is being called, this test now also checks that the initial greeting matches a value
        // that the Activate() method now sets.
        private void actDeactivate()
        {
            try
            {
                PoolLogger.Reset();
                string astr = "Hello is your name Sam";
                string bstr = "";
                string cstr = "";
                var pool = new DefaultObjectPool<pooltestscoreNS.Pool6>(m_poolPolicy6);
                var pl6 = pool.Get();
                pl6.getGreeting(ref cstr);
                pl6.setGreeting(astr);
                pl6.getGreeting(ref bstr);
                pool.Return(pl6);
                if ((astr != bstr) || (cstr != "Activate method called") ||
                    PoolLogger.ConnectCalls != 1 ||
                    PoolLogger.InitializeCalls != 0 ||
                    PoolLogger.ActivateCalls != 1 ||
                    PoolLogger.CanBePooledCalls != 0 ||
                    PoolLogger.DeactivateCalls != 1 ||
                    PoolLogger.CleanupCalls != 0 ||
                    PoolLogger.DisconnectCalls != 0)
                    testFail();
                else
                    Console.WriteLine("Passed");

            }
            catch (Exception e)
            {
                testFail();
                Console.WriteLine(e.Message);
            }
        }


        // Test 7
        // This test uses the same Pool3 interface as initActDeactCleanup() IADCuseDsp() (test 3).
        // Unlike that test, the goal of this test is to start enough Pool3 objects to exhaust the XFSP
        // licenses on the server and verify the error message. So while this test runs the setGreeting()
        // and getGreeting() methods, it doesn't try to validate the results.
        // The test will attempt to create up to m_maxlicenses + 1 connections (where m_maxlicenses is the
        // same value used by ErrorTester.ExceedLicensesTest(), and defaults to 20 unless the test app
        // determines a different number of XFSP licenses from localhost lmu, or a different value is
        // specified on the command line).
        private void LicenseError()
        {
            int loopCnt = m_maxlicenses + 1;
            Pool3[] conAry = new Pool3[loopCnt];
            var pool = new DefaultObjectPool<pooltestscoreNS.Pool3>(m_poolPolicy3);

            try
            {
                PoolLogger.Reset();

                string astr = "Hello is your name Sam";
                string bstr = "";
                

                for (int i = 0; i < loopCnt; i++)
                {
                    Pool3 itm = pool.Get();
                    conAry[i] = itm;
                    itm.setGreeting(astr);
                    itm.getGreeting(ref bstr);
                }

                testFail();

            }
            catch (Exception e)
            {
                // The expected error message is "COM+ activation failed because the activation could not
                //  be completed in the specified amount of time." If the test detects that error, it passes.
                // Otherwise, the error message is displayed and the test fails.
                // From testing, it looks like "The text associated with this error code could not be found."
                // is also a possible error message when an attempted connection times out, but that's
                // generic enough that we're not testing for it directly.
                if (e.Message.Contains("xfServerPlus license count exceeded.") && 
                    e.InnerException == null &&
                    PoolLogger.ConnectCalls > 0 &&
                    PoolLogger.ConnectCalls <= m_maxlicenses &&
                    PoolLogger.InitializeCalls > 0 &&
                    PoolLogger.InitializeCalls <= m_maxlicenses &&
                    PoolLogger.ActivateCalls > 0 &&
                    PoolLogger.ActivateCalls <= m_maxlicenses &&
                    PoolLogger.CanBePooledCalls == 0 &&
                    PoolLogger.DeactivateCalls == 0 &&
                    PoolLogger.CleanupCalls == 0 &&
                    PoolLogger.DisconnectCalls == 0)
                {
                    Console.WriteLine("Passed");
                }
                else
                {
                    string spcr = " | ";
                    string errmsg = e.Message + spcr;
                    if (e.InnerException != null)
                    {
                        errmsg += e.InnerException.Message + spcr;
                        if (e.InnerException is System.Net.Sockets.SocketException)
                        {
                            System.Net.Sockets.SocketException se = (System.Net.Sockets.SocketException)e.InnerException;
                            errmsg += se.ErrorCode;
                        }
                    }
                    testFail();
                    Console.WriteLine("{0}", errmsg);
                }
            }
            finally
            {
                for (int i = 0; i < (m_maxlicenses + 1); i++)
                {
                    //if (conAry[i] != null) conAry[i].Cleanup();
                    if (conAry[i] != null) pool.Return(conAry[i]);

                }
                System.GC.Collect();
            }
        }

        // Test 8
        // TODO: Adapt this test from HarmonyCore to work with this test suite.
        // Original at https://github.com/Synergex/HarmonyCore/blob/master/Services.Test.CS/ObjectPoolTests.cs
        // Allocate a larger number of objects, which may or may not be returned to the pool (can be controlled
        // in a Pool5 object by randomly calling setGreeting() with "Do not return" or some other value, so
        // CanBePooled returns 0 or 1). Once all objects are finished, verify that the pool size is at or below
        // the maximum (4).
        private void LoadTest()
        {
            Console.WriteLine("Skipped");
            //var tasks = new List<Task>();
            //BlockingPoolContextFactory<MyTestContext> contextFactory = new BlockingPoolContextFactory<MyTestContext>((sp) => new MyTestContext(), 6, 4, TimeSpan.FromSeconds(30), true);
            //for (int i = 0; i < 8; i++)
            //{
            //    tasks.Add(Task.Run(async () =>
            //    {s
            //        for (int ii = 0; ii < 1000; ii++)
            //        {
            //            var madeContext = contextFactory.MakeContext(null);
            //            await madeContext.EnsureReady();
            //            contextFactory.ReturnContext(madeContext);
            //            await Task.Yield();
            //        }
            //    }));
            //}
            //Task.WhenAll(tasks).Wait();
            //Assert.IsTrue(MyTestContext._instanceCount <= 4);
            //contextFactory.TrimPool(0).Wait();
            //Assert.AreEqual(MyTestContext._instanceCount, 0);
        }
    }

    /// <summary>
    /// This class simulates user-implemented pool logging, by providing methods that can be invoked 
    /// by the pooling policy. The class will record the number of times each method is called, so that
    /// the tests can verify the number of calls against the expected values. The class also provides
    /// a reset method.
    /// </summary>
    internal static class PoolLogger
    {
        private static int m_NumConnectCalls = 0;
        private static int m_NumInitializeCalls = 0;
        private static int m_NumActivateCalls = 0;
        private static int m_NumCanBePooledCalls = 0;
        private static int m_NumDeactivateCalls = 0;
        private static int m_NumCleanupCalls = 0;
        private static int m_NumDisconnectCalls = 0;

        internal static void Reset()
        {
            m_NumConnectCalls = 0;
            m_NumInitializeCalls = 0;
            m_NumActivateCalls = 0;
            m_NumCanBePooledCalls = 0;
            m_NumDeactivateCalls = 0;
            m_NumCleanupCalls = 0;
            m_NumDisconnectCalls = 0;
        }

        internal static void LogConnect()
        {
            m_NumConnectCalls++;
        }
        internal static void LogInitialization()
        {
            m_NumInitializeCalls++;
        }
        internal static void LogActivation()
        {
            m_NumActivateCalls++;
        }
        internal static void LogCanBePooled()
        {
            m_NumCanBePooledCalls++;
        }

        internal static void LogDeactivation()
        {
            m_NumDeactivateCalls++;
        }
        internal static void LogCleanup()
        {
            m_NumCleanupCalls++;
        }
        internal static void LogDisconnect()
        {
            m_NumDisconnectCalls++;
        }

        internal static int ConnectCalls { get { return m_NumConnectCalls; } }
        internal static int InitializeCalls { get { return m_NumInitializeCalls; } }
        internal static int ActivateCalls { get { return m_NumActivateCalls; } }
        internal static int CanBePooledCalls { get { return m_NumCanBePooledCalls; } }
        internal static int DeactivateCalls { get { return m_NumDeactivateCalls; } }
        internal static int CleanupCalls { get { return m_NumCleanupCalls; } }
        internal static int DisconnectCalls { get { return m_NumDisconnectCalls; } }
    }
}