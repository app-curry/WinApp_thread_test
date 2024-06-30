using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp_thread_test.TestControl;
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

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            // col_id
            //DataGridViewTextBoxColumn col_id = new DataGridViewTextBoxColumn();
            //col_id.Name = "col_id";
            //col_id.HeaderText = "id";
            //dataGridView1.Columns.Add(col_id);

            // col_threadid
            DataGridViewTextBoxColumn col_threadid = new DataGridViewTextBoxColumn();
            col_threadid.Name = TestControl.Const.c_col_threadid;
            col_threadid.HeaderText = "threadid";
            dataGridView1.Columns.Add(col_threadid);

            // col_progress
            DataGridViewTextBoxColumn col_progress = new DataGridViewTextBoxColumn();
            col_progress.Name = TestControl.Const.c_col_progress;
            col_progress.HeaderText = "progress";
            dataGridView1.Columns.Add(col_progress);

        }

        private List<GUIThreadTest> _threadList = new List<GUIThreadTest>();

        private void button_thread_start_Click(object sender, EventArgs e)
        {
            GUIThreadTest thread = new GUIThreadTest(this);

            thread.ThreadStartEvent += Thread_ThreadStartEvent;
            thread.ThreadProgressEvent += Thread_ThreadProgressEvent;
            thread.ThreadCompleteEvent += Thread_ThreadCompleteEvent;

            DataGridViewRow row = new ActiveThreadRow(dataGridView1, thread);
            row.CreateCells(this.dataGridView1, new object[] { "", "" });
            this.dataGridView1.Rows.Add(row);


            thread.StartThread();

        }

        private void Thread_ThreadStartEvent(object sender, int threadid)
        {
            _threadList.Add((GUIThreadTest)sender);

            textBox_message.AppendText(string.Format("ThreadStartEvent {0}", threadid) + Environment.NewLine);
        }

        private void Thread_ThreadProgressEvent(object sender, int step, int max, int threadid)
        {
            textBox_message.AppendText(string.Format("{0}/{1} {2}", step, max, threadid) + Environment.NewLine);
        }

        private void Thread_ThreadCompleteEvent(object sender, int threadid)
        {
            _threadList.Remove((GUIThreadTest)sender);

            textBox_message.AppendText(string.Format("ThreadCompleteEvent {0}", threadid) + Environment.NewLine);
        }

        private void button_thread_stop_Click(object sender, EventArgs e)
        {
            foreach (GUIThreadTest thread in _threadList)
            {
                thread.Break = true;
            }
        }

        private void button_suspend_Click(object sender, EventArgs e)
        {
            foreach (GUIThreadTest thread in _threadList)
            {
                thread.SuspendThread();
            }
        }

        private void button_resume_Click(object sender, EventArgs e)
        {
            foreach (GUIThreadTest thread in _threadList)
            {
                thread.ResumeThread();
            }
        }
    }
}
