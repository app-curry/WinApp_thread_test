using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;

namespace WpfApp_thread_test.Thread_2_0
{
    public class DeadlockThreadTest : GUIThreadTest
    {
        public DeadlockThreadTest(DispatcherObject c) : base(c)
        {
        }

        public override void ThreadMethod()
        {
            int threadid = Thread.CurrentThread.ManagedThreadId;

            OnThreadStartEvent(this, threadid);

            int step = 0;
            int max = 100;

            for (step = 0; step < max + 1; step++) 
            {
                if (_isBreak)
                    break;

                if (_isSuspend)
                    Suspend();

                Thread.Sleep(30);

                Resource.RequestResourceA();
                Resource.RequestResourceB();

                OnThreadProgressEvent(this, step, max, threadid);
            }

            OnThreadCompleteEvent(this, threadid);
        }

    }

    public static class Resource
    {
        private static readonly object _lockobjA = new object();
        private static readonly object _lockobjB = new object();

        public static void RequestResourceA()
        {
            lock (_lockobjA)
            {
                Thread.Sleep(5);

                lock (_lockobjB)
                {
                    Thread.Sleep(5);
                }
            }
        }

        public static void RequestResourceB()
        {
            lock (_lockobjB)
            {
                Thread.Sleep(5);

                lock (_lockobjA)
                {
                    Thread.Sleep(5);
                }
            }
        }
    }


}
