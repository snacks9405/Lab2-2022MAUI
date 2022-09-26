namespace Lab2_2022Maui;
using Lab2_2022;

public partial class MainPage : ContentPage
{
	IUserInterface ui;
	BusinessLogic bl;

	public MainPage()
	{
		ui = new UserInterface(bl);
		InitializeComponent();
		//ui.DisplayMenu();
	}


}


