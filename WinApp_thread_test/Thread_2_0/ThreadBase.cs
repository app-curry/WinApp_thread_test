using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinApp_thread_test.Thread_2_0
{

    abstract public class ThreadBase
    {
        protected volatile bool _break = false;
        public bool Break
        {
            set
            {
                _break = value;
            }
            get { return _break; }
        }

        public virtual Thread StartThread()
        {
            Thread thread = new Thread(ThreadMethod);

            thread.Start();

            return thread;
        }


        public abstract void ThreadMethod();
    }



}


