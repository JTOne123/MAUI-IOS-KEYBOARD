using Foundation;
using UIKit;
using XAM_IOS_KEYBOARD.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(KeyboardManagerRenderer))]
namespace XAM_IOS_KEYBOARD.iOS.Renderers
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

            System.Diagnostics.Debug.WriteLine($"XAM key down {keyCode} {key.Characters}");
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

            System.Diagnostics.Debug.WriteLine($"XAM key up {keyCode} {key.Characters}");
        }
    }
}
