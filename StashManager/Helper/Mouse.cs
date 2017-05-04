using System;
using System.Runtime.InteropServices;

namespace StashManager.Helper
{
    public class Mouse
    {
        #region SetCursorPosition

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(
            int x,
            int y
        );

        #endregion

        #region GetCursorPosition

        // http://pinvoke.net/default.aspx/user32/GetCursorPos.html

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(
            out POINT lpPoint
            // DON'T use System.Drawing.Point, the order of the fields in System.Drawing.Point isn't guaranteed to stay the same.
        );

        #endregion

        #region mouse_event

        /*
         * http://pinvoke.net/default.aspx/user32.mouse_event
         * Note that for non-relative mouse movement (i.e. if MOUSEEVENTF_ABSOLUTE is not specified as part of dwFlags),
         * negative values for dx and dy are desirable. As such, the "uint" type specification for C# can be safely replaced with Int32.
         * 
         * dy: The mouse's absolute position along the y-axis or its amount of motion since the last mouse event was generated,
         *     depending on the setting of MOUSEEVENTF_ABSOLUTE. Absolute data is specified as the mouse's actual y-coordinate;
         *     relative data is specified as the number of mickeys moved.
         * 
         * dx: The mouse's absolute position along the x-axis or its amount of motion since the last mouse event was generated,
         *     depending on the setting of MOUSEEVENTF_ABSOLUTE. Absolute data is specified as the mouse's actual x-coordinate;
         *     relative data is specified as the number of mickeys moved.
         *     A mickey is the amount that a mouse has to move for it to report that it has moved.
         *     
         */

        [DllImport("user32.dll")]
        public static extern void mouse_event(
            MouseEventFlags dwFlags,
            uint dx,
            uint dy,
            uint dwData,
            UIntPtr dwExtraInfo
        );

        [DllImport("user32.dll")]
        public static extern void mouse_event(
            MouseEventFlags dwFlags,
            uint dx,
            uint dy,
            uint dwData,
            int dwExtraInfo);

        #endregion
    }
}