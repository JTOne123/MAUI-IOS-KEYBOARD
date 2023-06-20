using Foundation;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using UIKit;

namespace MAUI_IOS_KEYBOARD.Platforms.iOS.Renderers
{
    public class KeyboardManagerRenderer : PageRenderer
    {
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
}
