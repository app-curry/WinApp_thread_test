﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp_thread_test.Thread_2_0
{
    abstract public class GUIThreadBase : ThreadBase
    {
        public GUIThreadBase(ISynchronizeInvoke syncobj)
        {
            _synchronizingObject = syncobj;
        }

        protected ISynchronizeInvoke _synchronizingObject;
        public ISynchronizeInvoke SynchronizingObject
        {
            get { return _synchronizingObject; }
        }

    }
}
