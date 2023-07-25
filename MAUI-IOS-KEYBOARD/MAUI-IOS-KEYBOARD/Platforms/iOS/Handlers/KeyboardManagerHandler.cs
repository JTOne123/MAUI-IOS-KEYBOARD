using Foundation;
using MAUI_IOS_KEYBOARD.Platforms.iOS.Managers;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace MAUI_IOS_KEYBOARD.Platforms.iOS.Handlers
{
    public class KeyboardManagerHandler : PageHandler
	{
        private readonly KeyboardManager keyboardManager;

        public KeyboardManagerHandler(KeyboardManager keyboardManager)
        {
            this.keyboardManager = keyboardManager;
        }

        class MyCustomView : Microsoft.Maui.Platform.ContentView
        {
            private readonly KeyboardManager keyboardManager;

            public MyCustomView(KeyboardManager keyboardManager)
            {
                this.keyboardManager = keyboardManager;
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

                System.Diagnostics.Debug.WriteLine($"MAUI key down {keyCode} {key.Characters}");

                keyboardManager.InvokeKeyboardEvent(key.Characters, KeyboardManager.KeyEventType.KeyDown);
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

                System.Diagnostics.Debug.WriteLine($"MAUI key up {keyCode} {key.Characters}");

                keyboardManager.InvokeKeyboardEvent(key.Characters, KeyboardManager.KeyEventType.KeyUp);
            }
        }

        class MyPageViewController : PageViewController
        {
            private readonly KeyboardManager keyboardManager;

            public MyPageViewController(IView page, IMauiContext mauiContext, KeyboardManager keyboardManager)
                : base(page, mauiContext)
            {
                this.keyboardManager = keyboardManager;
            }

            protected override UIView CreatePlatformView(IElement view)
            {
                return new MyCustomView(keyboardManager);
            }
        }

        protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
        {
            _ = VirtualView ?? throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a LayoutView");
            _ = MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null");

            if (ViewController == null)
                ViewController = new MyPageViewController(VirtualView, MauiContext, keyboardManager);

            if (ViewController is PageViewController pc && pc.CurrentPlatformView is Microsoft.Maui.Platform.ContentView pv)
                return pv;

            if (ViewController.View is Microsoft.Maui.Platform.ContentView cv)
                return cv;

            throw new InvalidOperationException($"PageViewController.View must be a {nameof(Microsoft.Maui.Platform.ContentView)}");
        }
    }
}

