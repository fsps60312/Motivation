using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Motivation
{
    /// <summary>
    /// processings of screen capture
    /// </summary>
    public static class MyScreen
    {
        /// <summary>
        /// if function didn't find specific point, it would return failedPoint
        /// </summary>
        public static Point failedPoint { get { return MyBitmap.failedPoint; } }
        /// <summary>
        /// return screen capture as Bitmap
        /// </summary>
        /// <returns></returns>
        public static Bitmap CaptureScreen()
        {
            Bitmap answer = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(answer);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), answer.Size);
            g.ReleaseHdc(g.GetHdc());
            g.Dispose();
            return answer;
        }
        /// <summary>
        /// find the location of specific image on the screen
        /// </summary>
        /// <param name="target">the image to find</param>
        /// <returns>the location of specific image on the screen, failedPoint would be returned if such point didn't exist</returns>
        public static Point FindImage(Bitmap target)
        {
            Bitmap src = CaptureScreen();
            Point answer= MyBitmap.FindImage(src, target);
            src.Dispose();
            return answer;
        }
        /// <summary>
        /// Check whether a image is match at specific location on the screen capture
        /// </summary>
        /// <param name="target">The image</param>
        /// <param name="p">The location on the screen capture</param>
        /// <returns></returns>
        public static bool IsMatch(Bitmap target,Point p)
        {
            Bitmap src = CaptureScreen();
            bool answer = MyBitmap.IsMatch(src, target, p);
            src.Dispose();
            return answer;
        }
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        /// <summary>
        /// Turn on the screen
        /// </summary>
        public static void TurnOn()
        {
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, -1);
        }
        /// <summary>
        /// Turn off the screen
        /// </summary>
        public static void TurnOff()
        {
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
        }
        static readonly IntPtr HWND_BROADCAST = new IntPtr(0xffff);
        const uint WM_SYSCOMMAND = 0x0112;
        const int SC_MONITORPOWER = 0xf170;
    }

}
