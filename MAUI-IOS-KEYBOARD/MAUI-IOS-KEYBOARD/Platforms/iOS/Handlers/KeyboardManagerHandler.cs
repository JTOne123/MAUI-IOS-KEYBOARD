using Foundation;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace MAUI_IOS_KEYBOARD.Platforms.iOS.Handlers
{
    public class KeyboardManagerHandler : PageHandler
	{
        class MyPageViewController : PageViewController
        {
            public MyPageViewController(IView page, IMauiContext mauiContext)
                : base(page, mauiContext)
            {
            }

            public override bool CanBecomeFirstResponder => true;

            public override void PressesBegan(NSSet<UIPress> presses, UIPressesEvent evt)
            {
                base.PressesBegan(presses, evt);

                var array = presses.ToArray();
                if (array.Length == 0)
                    return;

                var first = array[0];
                var key = first.Key;

                if (key == null)
                    return;

                var keyCode = key.KeyCode;

                System.Diagnostics.Debug.WriteLine($"key down {keyCode} {key.Characters}");
            }

            public override void PressesEnded(NSSet<UIPress> presses, UIPressesEvent evt)
            {
                base.PressesEnded(presses, evt);

                var array = presses.ToArray();
                if (array.Length == 0)
                    return;

                var first = array[0];
                var key = first.Key;

                if (key == null)
                    return;

                var keyCode = key.KeyCode;

                System.Diagnostics.Debug.WriteLine($"key up {keyCode} {key.Characters}");
            }
        }

        protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
        {
            _ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a LayoutView");
            _ = MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null");

            if (ViewController == null)
                ViewController = new MyPageViewController(VirtualView, MauiContext);

            if (ViewController is PageViewController pc && pc.CurrentPlatformView is Microsoft.Maui.Platform.ContentView pv)
                return pv;

            if (ViewController.View is Microsoft.Maui.Platform.ContentView cv)
                return cv;

            throw new InvalidOperationException($"PageViewController.View must be a {nameof(Microsoft.Maui.Platform.ContentView)}");
        }
    }
}

