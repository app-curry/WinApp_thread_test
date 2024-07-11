using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp_thread_test.TestControl;
using WpfApp_thread_test.Thread_2_0;

namespace WpfApp_thread_test
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            init();
        }

        void init()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            panel_thread.IsEnabled = IsThreadsAlive;

            this.Closing += MainWindow_Closing;
        }

        private List<GUIThreadTest> _threadList = new List<GUIThreadTest>();

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

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;

            if (IsThreadsAlive)
            {
                SuspendThread();

                int threadcnt = _threadList.Count;

                MessageBoxResult dlgret = MessageBox.Show(
                    string.Format("スレッド（残り{0}）の実行中です。\r\n中断して終了しますか？", threadcnt),
                    "ウィンドウの終了",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.None,
                    MessageBoxResult.No);

                if (dlgret == MessageBoxResult.Yes)
                {
                    // 終了
                    _windowclosing = true;

                    this.IsEnabled = false;
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

        private void button_thread_start_Click(object sender, RoutedEventArgs e)
        {
            GUIThreadTest thread = new GUIThreadTest(this);

            thread.ThreadStartEvent += Thread_ThreadStartEvent;
            thread.ThreadProgressEvent += Thread_ThreadProgressEvent;
            thread.ThreadCompleteEvent += Thread_ThreadCompleteEvent;

            thread.StartThread();
        }

        private void Thread_ThreadStartEvent(object sender, int threadid)
        {
            _threadList.Add((GUIThreadTest)sender);

            textbox_info.AppendText(string.Format("ThreadStartEvent {0}", threadid) + Environment.NewLine);

            panel_thread.IsEnabled = true;
        }

        private void Thread_ThreadProgressEvent(object sender, int step, int max, int threadid)
        {
            textbox_info.AppendText(string.Format("{0}/{1} {2}", step, max, threadid) + Environment.NewLine);

            textbox_info.ScrollToEnd();

        }

        private void Thread_ThreadCompleteEvent(object sender, int threadid)
        {
            _threadList.Remove((GUIThreadTest)sender);

            textbox_info.AppendText(string.Format("ThreadCompleteEvent {0}", threadid) + Environment.NewLine);

            panel_thread.IsEnabled = IsThreadsAlive;

            if (_windowclosing)
            {
                if (!IsThreadsAlive)
                {
                    EndModalLoop();
                }
            }
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

        private void button_thread_stop_Click(object sender, RoutedEventArgs e)
        {
            StopThread();
        }

        private void button_thread_suspend_Click(object sender, RoutedEventArgs e)
        {
            SuspendThread();
        }

        private void button_thread_resume_Click(object sender, RoutedEventArgs e)
        {
            ResumeThread();
        }

        private void button_gui_deadlock_Click(object sender, RoutedEventArgs e)
        {
            foreach (GUIThreadTest thread in _threadList)
            {
                thread.Join();
            }
        }
    }
}
