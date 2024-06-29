using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp_thread_test.Thread_2_0;

namespace WinApp_thread_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            init();
        }

        void init()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private List<ThreadBase> _threadList = new List<ThreadBase>();

        private void button_thread_start_Click(object sender, EventArgs e)
        {
            GUIThreadTest thread = new GUIThreadTest(this);

            thread.ThreadStartEvent += Thread_ThreadStartEvent;
            thread.ThreadProgressEvent += Thread_ThreadProgressEvent;
            thread.ThreadCompleteEvent += Thread_ThreadCompleteEvent;

            thread.StartThread();

        }

        private void Thread_ThreadStartEvent(object sender, int threadid)
        {
            _threadList.Add((ThreadBase)sender);

            textBox_message.AppendText(string.Format("ThreadStartEvent {0}", threadid) + Environment.NewLine);
        }

        private void Thread_ThreadProgressEvent(object sender, int step, int max, int threadid)
        {
            textBox_message.AppendText(string.Format("{0}/{1} {2}", step, max, threadid) + Environment.NewLine);
        }

        private void Thread_ThreadCompleteEvent(object sender, int threadid)
        {
            _threadList.Remove((ThreadBase)sender);

            textBox_message.AppendText(string.Format("ThreadCompleteEvent {0}", threadid) + Environment.NewLine);
        }

        private void button_thread_stop_Click(object sender, EventArgs e)
        {
            foreach (ThreadBase thread in _threadList) 
            {
                thread.Break = true;
            }
        }
    }
}
