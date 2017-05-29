using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace Motivation
{
    /// <summary>
    /// control the cursor
    /// </summary>
    public static class MyCursor
    {
        private static int clickSpan = 20;
        /// <summary>
        /// get or set cursor position
        /// </summary>
        public static Point Position
        {
            get { return Cursor.Position; }
            set { Cursor.Position = value; }
        }
        /// <summary>
        /// move cursor to specific position and then click mouse left button
        /// </summary>
        /// <param name="cursorPosition">position where the cursor move to</param>
        public static void LeftClick(Point cursorPosition)
        {
            Cursor.Position = cursorPosition;
            LeftClick();
        }
        /// <summary>
        /// move cursor to specific position and then click mouse right button
        /// </summary>
        /// <param name="cursorPosition">position where the cursor move to</param>
        public static void RightClick(Point cursorPosition)
        {
            Cursor.Position = cursorPosition;
            RightClick();
        }
        /// <summary>
        /// click mouse left button
        /// </summary>
        public static void LeftClick()
        {
            LeftDown();
            Thread.Sleep(clickSpan);
            LeftUp();
        }
        /// <summary>
        /// click mouse right button
        /// </summary>
        public static void RightClick()
        {
            RightDown();
            Thread.Sleep(clickSpan);
            RightUp();
        }
        /// <summary>
        /// press down mouse left button
        /// </summary>
        public static void LeftDown()
        {
            INPUT leftdown = new INPUT();
            leftdown.dwType = 0;
            leftdown.mi = new MOUSEINPUT();
            leftdown.mi.dwExtraInfo = IntPtr.Zero;
            leftdown.mi.dx = 0;
            leftdown.mi.dy = 0;
            leftdown.mi.time = 0;
            leftdown.mi.mouseData = 0;
            leftdown.mi.dwFlags = MOUSEFLAG.LEFTDOWN;
            SendInput(1, ref leftdown, Marshal.SizeOf(typeof(INPUT)));
        }
        /// <summary>
        /// release mouse left button
        /// </summary>
        public static void LeftUp()
        {
            INPUT leftup = new INPUT();
            leftup.dwType = 0;
            leftup.mi = new MOUSEINPUT();
            leftup.mi.dwExtraInfo = IntPtr.Zero;
            leftup.mi.dx = 0;
            leftup.mi.dy = 0;
            leftup.mi.time = 0;
            leftup.mi.mouseData = 0;
            leftup.mi.dwFlags = MOUSEFLAG.LEFTUP;
            SendInput(1, ref leftup, Marshal.SizeOf(typeof(INPUT)));
        }
        /// <summary>
        /// press down mouse right button
        /// </summary>
        public static void RightDown()
        {
            INPUT rightdown = new INPUT();
            rightdown.dwType = 0;
            rightdown.mi = new MOUSEINPUT();
            rightdown.mi.dwExtraInfo = IntPtr.Zero;
            rightdown.mi.dx = 0;
            rightdown.mi.dy = 0;
            rightdown.mi.time = 0;
            rightdown.mi.mouseData = 0;
            rightdown.mi.dwFlags = MOUSEFLAG.RIGHTDOWN;
            SendInput(1, ref rightdown, Marshal.SizeOf(typeof(INPUT)));
        }
        /// <summary>
        /// release mouse right button
        /// </summary>
        public static void RightUp()
        {
            INPUT rightup = new INPUT();
            rightup.dwType = 0;
            rightup.mi = new MOUSEINPUT();
            rightup.mi.dwExtraInfo = IntPtr.Zero;
            rightup.mi.dx = 0;
            rightup.mi.dy = 0;
            rightup.mi.time = 0;
            rightup.mi.mouseData = 0;
            rightup.mi.dwFlags = MOUSEFLAG.RIGHTUP;
            SendInput(1, ref rightup, Marshal.SizeOf(typeof(INPUT)));
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern Int32 SendInput(Int32 cInputs, ref INPUT pInputs, Int32 cbSize);
        [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 28)]
        private struct INPUT
        {
            [FieldOffset(0)]
            public INPUTTYPE dwType;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public KEYBOARDINPUT ki;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct MOUSEINPUT
        {
            public Int32 dx;
            public Int32 dy;
            public Int32 mouseData;
            public MOUSEFLAG dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct KEYBOARDINPUT
        {
            public Int16 wVk;
            public Int16 wScan;
            public KEYBOARDFLAG dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct HARDWAREINPUT
        {
            public Int32 uMsg;
            public Int16 wParamL;
            public Int16 wParamH;
        }
        private enum INPUTTYPE : int
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }
        [Flags()]
        private enum MOUSEFLAG : int
        {
            MOVE = 0x1,
            LEFTDOWN = 0x2,
            LEFTUP = 0x4,
            RIGHTDOWN = 0x8,
            RIGHTUP = 0x10,
            MIDDLEDOWN = 0x20,
            MIDDLEUP = 0x40,
            XDOWN = 0x80,
            XUP = 0x100,
            VIRTUALDESK = 0x400,
            WHEEL = 0x800,
            ABSOLUTE = 0x8000
        }
        [Flags()]
        private enum KEYBOARDFLAG : int
        {
            EXTENDEDKEY = 1,
            KEYUP = 2,
            UNICODE = 4,
            SCANCODE = 8
        }
    }
}
