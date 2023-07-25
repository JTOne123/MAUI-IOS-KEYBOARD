using MAUI_IOS_KEYBOARD.Platforms.iOS.Managers;

namespace MAUI_IOS_KEYBOARD;

public partial class MainPage : ContentPage
{
    private readonly KeyboardManager keyboardManager;

    public string KeyboardInput { get; set; }

    public MainPage(KeyboardManager keyboardManager)
	{
		InitializeComponent();

		this.keyboardManager = keyboardManager;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        keyboardManager.KeyboardEvent += KeyboardManager_KeyboardEvent;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        keyboardManager.KeyboardEvent -= KeyboardManager_KeyboardEvent;
    }

    private void KeyboardManager_KeyboardEvent(object sender, KeyboardManager.KeyboardEventArgs e)
    {
        KeyboardInput = e.Characters;
        OnPropertyChanged(nameof(KeyboardInput));
    }
}

