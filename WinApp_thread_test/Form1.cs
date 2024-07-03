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

            this.FormClosing += Form1_FormClosing;

            groupBox_thread.Enabled = false;
        }

        bool IsThreadsAlive
        {
            get
            {
                bool ret = _threadList.Count > 0;

                return ret;

            }
        }

        private ModalLoop _modalLoop;

        protected void StartModalLoop()
        {
            _modalLoop = new ModalLoop();
            _modalLoop.Loop();
        }

        protected void EndModalLoop()
        {
            if (_modalLoop != null)
            {
                _modalLoop.Stop();
                _modalLoop = null;
            }
        }

        private bool _windowclosing = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(IsThreadsAlive)
            {
                SuspendThread();

                int threadcnt = _threadList.Count;
                DialogResult dlgret = MessageBox.Show(
                    string.Format("スレッド（残り{0}）の実行中です。\r\n中断して終了しますか？", threadcnt.ToString())
                    , "ウィンドウの終了", MessageBoxButtons.YesNo);

                if (dlgret == DialogResult.Yes)
                {
                    // 終了
                    _windowclosing = true;

                    this.Enabled = false;
                    this.Hide();
                    StopThread();
                    ResumeThread();

                    StartModalLoop();
                }
                else
                {
                    // 継続
                    e.Cancel = true;
                    ResumeThread();
                }
            }
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


            groupBox_thread.Enabled = true;

        }

        private void Thread_ThreadProgressEvent(object sender, int step, int max, int threadid)
        {
            textBox_message.AppendText(string.Format("{0}/{1} {2}", step, max, threadid) + Environment.NewLine);
        }

        private void Thread_ThreadCompleteEvent(object sender, int threadid)
        {
            _threadList.Remove((GUIThreadTest)sender);

            textBox_message.AppendText(string.Format("ThreadCompleteEvent {0}", threadid) + Environment.NewLine);

            groupBox_thread.Enabled = IsThreadsAlive;

            if (_windowclosing)
            {
                if(!IsThreadsAlive)
                {
                    EndModalLoop();
                }
            }
        }

        private void button_thread_stop_Click(object sender, EventArgs e)
        {
            StopThread();
        }

        private void button_suspend_Click(object sender, EventArgs e)
        {
            SuspendThread();
        }

        private void button_resume_Click(object sender, EventArgs e)
        {
            ResumeThread();
        }

        private void StopThread()
        {
            foreach (GUIThreadTest thread in _threadList)
            {
                thread.StopThread();
            }
        }

        private void SuspendThread()
        {
            foreach (GUIThreadTest thread in _threadList)
            {
                thread.SuspendThread();
            }
        }

        private void ResumeThread()
        {
            foreach (GUIThreadTest thread in _threadList)
            {
                thread.ResumeThread();
            }
        }

        /// <summary>
        /// デッドロックテスト
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_deadlock1_Click(object sender, EventArgs e)
        {
            foreach (GUIThreadTest thread in _threadList)
            {
                thread.Join();
            }
        }

        private void button_deadlock2_Click(object sender, EventArgs e)
        {

        }
    }
}
