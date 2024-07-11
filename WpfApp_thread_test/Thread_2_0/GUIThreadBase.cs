using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using ThreadTestLibrary.Thread_2_0;

namespace WpfApp_thread_test.Thread_2_0
{
    abstract public class GUIThreadBase : SuspendableThreadBase
    {
        public GUIThreadBase(DispatcherObject syncobj)
        {
            _synchronizingObject = syncobj;
        }

        protected DispatcherObject _synchronizingObject;
        public DispatcherObject SynchronizingObject
        {
            get { return _synchronizingObject; }
        }

    }
}
