using GameController;
using UIKit;

namespace MAUI_IOS_KEYBOARD.Platforms.iOS.Managers
{
    public class KeyboardManager
    {
        public enum KeyEventType
        {
            KeyDown,
            KeyUp
        }

        public class KeyboardEventArgs : EventArgs
        {
            public string Characters { get; set; }
            public KeyEventType KeyEventType { get; set; }
        }

        public event EventHandler<KeyboardEventArgs> KeyboardEvent;

        public void InvokeKeyboardEvent(string characters, KeyEventType keyEventType)
        {
            KeyboardEvent?.Invoke(null, new KeyboardEventArgs { Characters = characters, KeyEventType = keyEventType });
        }

        public bool HasHardwareKeyboard { get; }

        public KeyboardManager()
        {
            HasHardwareKeyboard = GCKeyboard.CoalescedKeyboard != null;
        }

        public void HideSoftKeyboard(View view)
        {
            if (view != null)
            {
                var nativeView = view.Handler?.PlatformView as UIView;
                if (nativeView != null)
                    nativeView.EndEditing(true);
            }
            else
            {
                UIApplication.SharedApplication.KeyWindow.EndEditing(true);
            }

            UIApplication.SharedApplication.KeyWindow.BecomeFirstResponder();
        }

        public void ShowSoftKeyboard(View view)
        {
            if (view != null)
            {
                var nativeView = view.Handler?.PlatformView as UIView;
                if (nativeView != null)
                    nativeView.BecomeFirstResponder();
            }
        }

    }
}
