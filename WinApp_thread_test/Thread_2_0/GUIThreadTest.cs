using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WinApp_thread_test.Thread_2_0
{
    public class GUIThreadTest : GUIThreadBase
    {
        public GUIThreadTest(Control c) : base(c)
        {
        }

        public override void ThreadMethod()
        {
            OnThreadStartEvent(this);

            int step = 0;
            int max = 100;

            for (step = 0; step < max + 1; step++) 
            {
                Thread.Sleep(100);

                OnThreadProgressEvent(this, step, max);
            }

            OnThreadCompleteEvent(this);
        }

        public delegate void ThreadProgressEventHandler(object sender, int step, int max);
        public event ThreadProgressEventHandler ThreadProgressEvent;
        protected virtual void OnThreadProgressEvent(object sender, int step, int max)
        {
            if (ThreadProgressEvent != null)
            {
                _synchronizingObject.Invoke(ThreadProgressEvent, new object[] { sender, step, max });
            }
        }

        public delegate void ThreadStartEventHandler(object sender);
        public event ThreadStartEventHandler ThreadStartEvent;
        protected virtual void OnThreadStartEvent(object sender)
        {
            if (ThreadStartEvent != null)
            {
                _synchronizingObject.Invoke(ThreadStartEvent, new object[] { sender });
            }
        }

        public delegate void ThreadCompleteEventHandler(object sender);
        public event ThreadCompleteEventHandler ThreadCompleteEvent;
        protected virtual void OnThreadCompleteEvent(object sender)
        {
            if (ThreadCompleteEvent != null)
            {
                _synchronizingObject.Invoke(ThreadCompleteEvent, new object[] { sender });
            }
        }

    }
}
