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

        private void button_thread_start_Click(object sender, EventArgs e)
        {
            GUIThreadTest thread = new GUIThreadTest(this);

            thread.ThreadStartEvent += Thread_ThreadStartEvent;
            thread.ThreadCompleteEvent += Thread_ThreadCompleteEvent;
            thread.ThreadProgressEvent += Thread_ThreadProgressEvent;

            thread.StartThread();

        }

        private void Thread_ThreadProgressEvent(object sender, int step, int max)
        {
            textBox_message.AppendText(string.Format("{0}/{1}", step, max) + Environment.NewLine);
        }

        private void Thread_ThreadStartEvent(object sender)
        {
            textBox_message.AppendText("ThreadStart" + Environment.NewLine);
        }

        private void Thread_ThreadCompleteEvent(object sender)
        {
            textBox_message.AppendText("ThreadComplete" + Environment.NewLine);
        }

    }
}
