namespace Lab2_2022Maui;
using Lab2_2022;

public partial class MainPage : ContentPage
{
	IUserInterface ui;
	int count = 0;

	public MainPage(UserInterface ui)
	{
		this.ui = ui;
		InitializeComponent();
		ui.DisplayMenu();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

	if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}


