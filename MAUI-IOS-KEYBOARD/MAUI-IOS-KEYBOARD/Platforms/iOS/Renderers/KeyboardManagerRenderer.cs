using Foundation;
using MAUI_IOS_KEYBOARD.Platforms.iOS.Managers;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using UIKit;

namespace MAUI_IOS_KEYBOARD.Platforms.iOS.Renderers
{
    public class KeyboardManagerRenderer : PageRenderer
    {
        private readonly KeyboardManager keyboardManager;

        public KeyboardManagerRenderer()
        {
            this.keyboardManager = MauiProgram.Services.GetService(typeof(KeyboardManager)) as KeyboardManager;
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
}
