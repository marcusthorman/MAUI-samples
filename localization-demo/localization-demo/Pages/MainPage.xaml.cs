using localization_demo.Resources.Strings;

namespace localization_demo.Pages;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		UpdateCounterLabelText(); // set CounterLabel text
	}

	private void UpdateCounterLabelText()
    {
		CounterLabel.Text = $"{AppResource.Current_count} {count}";
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		UpdateCounterLabelText();

		SemanticScreenReader.Announce(CounterLabel.Text);
	}
}

