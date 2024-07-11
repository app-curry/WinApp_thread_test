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
    public class GUIThreadTest : GUIThreadBase
    {
        public GUIThreadTest(DispatcherObject c) : base(c)
        {
        }

        //private int _threadid;

        //public int Threadid
        //{
        //    get { return _threadid; }
        //}

        #region デッドロックテスト用
        private Thread _activethread = null;

        public override Thread StartThread()
        {
            Thread thread = base.StartThread();

            _activethread = thread;

            return thread;
        }

        public void Join()
        {
            if (_activethread != null)
            {
                _activethread.Join();
            }
        }

        #endregion

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

                Thread.Sleep(50);

                OnThreadProgressEvent(this, step, max, threadid);
            }

            OnThreadCompleteEvent(this, threadid);
        }

        public delegate void ThreadProgressEventHandler(object sender, int step, int max, int threadid);
        public event ThreadProgressEventHandler ThreadProgressEvent;
        protected virtual void OnThreadProgressEvent(object sender, int step, int max, int threadid)
        {
            if (ThreadProgressEvent != null)
            {
                _synchronizingObject.Dispatcher.Invoke(ThreadProgressEvent, new object[] { sender, step, max, threadid });
            }
        }

        public delegate void ThreadStartEventHandler(object sender, int threadid);
        public event ThreadStartEventHandler ThreadStartEvent;
        protected virtual void OnThreadStartEvent(object sender, int threadid)
        {
            if (ThreadStartEvent != null)
            {
                _synchronizingObject.Dispatcher.Invoke(ThreadStartEvent, new object[] { sender, threadid });
            }
        }

        public delegate void ThreadCompleteEventHandler(object sender, int threadid);
        public event ThreadCompleteEventHandler ThreadCompleteEvent;
        protected virtual void OnThreadCompleteEvent(object sender, int threadid)
        {
            if (ThreadCompleteEvent != null)
            {
                _synchronizingObject.Dispatcher.Invoke(ThreadCompleteEvent, new object[] { sender, threadid });
            }
        }

    }
}
