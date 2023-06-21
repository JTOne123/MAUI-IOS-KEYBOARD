using GameController;
using UIKit;

namespace MAUI_IOS_KEYBOARD.Platforms.iOS.Managers
{
    public class KeyboardManager
    {
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
