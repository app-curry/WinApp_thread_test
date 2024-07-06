using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp_thread_test.Thread_2_0;

namespace WinApp_thread_test.TestControl
{
    public class ActiveThreadRow : DataGridViewRow
    {
        private DataGridView _dgview;
        private GUIThreadTest _thread;

        public ActiveThreadRow(DataGridView dgview, GUIThreadTest thread)
        {
            _dgview = dgview;
            _thread = thread;

            _thread.ThreadStartEvent += _thread_ThreadStartEvent;
            _thread.ThreadProgressEvent += _thread_ThreadProgressEvent;
            _thread.ThreadCompleteEvent += _thread_ThreadCompleteEvent;
        }

        private void _thread_ThreadStartEvent(object sender, int threadid)
        {
            this.Cells[TestControl.Const.c_col_threadid].Value = threadid;
        }

        private void _thread_ThreadProgressEvent(object sender, int step, int max, int threadid)
        {
            this.Cells[TestControl.Const.c_col_progress].Value = string.Format("{0}/{1}", step, max);
        }
        private void _thread_ThreadCompleteEvent(object sender, int threadid)
        {
            _dgview.Rows.Remove(this);
        }

    }
}
