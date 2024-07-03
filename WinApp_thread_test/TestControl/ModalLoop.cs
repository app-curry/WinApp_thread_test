using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp_thread_test.TestControl
{
    //abstract public class ThreadWaitFormBase : Form
    //{
    //    protected ModalLoop _modalLoop;

    //    protected void StartModalLoop()
    //    {
    //        _modalLoop = new ModalLoop();
    //        _modalLoop.Loop();
    //    }

    //    protected void EndModalLoop()
    //    {
    //        if (_modalLoop != null)
    //        {
    //            _modalLoop.Stop();
    //            _modalLoop = null;
    //        }
    //    }

    //}

    /// <summary>
    /// ウィンドウ終了時にデッドロックを回避してスレッド全部の終了を待機するループ処理
    /// </summary>
    public class ModalLoop
    {
        private bool _isStop = false;
        public void Stop()
        {
            _isStop = true;
        }

        public void Loop()
        {
            WinMsg msg = new WinMsg();
            while (!_isStop)
            {
                if (!Win32API.GetMessage(out msg, IntPtr.Zero, 0, 0))
                    continue;

                Win32API.DispatchMessage(ref msg);
            }
        }


    }

    internal class Win32API
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMessage(out WinMsg lpMsg, IntPtr hWnd, uint wMsgFilterMin,
           uint wMsgFilterMax);

        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage([In] ref WinMsg lpmsg);

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WinMsg
    {
        public IntPtr hwnd;
        public UInt32 message;
        public IntPtr wParam;
        public IntPtr lParam;
        public UInt32 time;
        public POINT pt;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static implicit operator System.Drawing.Point(POINT p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }

        public static implicit operator POINT(System.Drawing.Point p)
        {
            return new POINT(p.X, p.Y);
        }
    }


}
