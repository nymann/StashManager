namespace StashManager.Helper
{
    public enum MouseEventFlags
    {
        /*
         * MOUSEEVENTF_ABSOLUTE
         * The dx and dy parameters contain normalized absolute coordinates. If not set,
         * those parameters contain relative data: the change in position since the last reported position.
         * This flag can be set, or not set, regardless of what kind of mouse or mouse-like device, if any,
         * is connected to the system. For further information about relative mouse motion,
         * see the following Remarks section.
         */
        MouseeventfAbsolute = 0x8000,
        MouseeventfLeftdown = 0x2,     // The left button is down.
        MouseeventfLeftup = 0x4,       // The left button is up.
        MouseeventfMiddledown = 0x20,  // The middle button is down.
        MouseeventfMiddleup = 0x40,    // The middle button is up.
        MouseeventfMove = 0x1,         // Movement occurred.
        MouseeventfRightdown = 0x8,    // The right button is down.
        MouseeventfRightup = 0x10,     // The right button is up.
        MouseeventfXdown = 0x80,       // An X button was pressed.
        MouseeventfXup = 0x100,        // An X button was released.
        MouseeventfWheel = 0x800, 	    // The wheel button is rotated.
        MouseeventfHwheel = 0x1000, 	// The wheel button is tilted
    }
}