using CommunityToolkit.Maui.Views;

namespace TicTacToe.Popups;

public partial class InfoPopup : Popup
{
    public static readonly BindableProperty InfoTextProperty = BindableProperty.Create(
        nameof(InfoText),
        typeof(string),
        typeof(InfoPopup));

    public string InfoText 
    {
        get => (string)GetValue(InfoTextProperty);
        set => SetValue(InfoTextProperty, value);
    }

    public InfoPopup()
	{
		InitializeComponent();
        Content.BindingContext = this;
	}

    private void OKButtonClicked(object sender, EventArgs e) => Close();
}