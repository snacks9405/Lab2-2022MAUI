namespace Lab2_2022Maui;
using Lab2_2022;

public partial class MainPage : ContentPage
{


    public MainPage()
	{
		
		InitializeComponent();
        
    }

	void OnAddEntryClicked(Object sender, EventArgs e)
	{
		IBusinessLogic bl = new BusinessLogic();
		String clue = Clue.Text;
		String answer = Answer.Text;
		String date = Date.Text;
		String difficulty = Difficulty.Text;
		int intDifficulty;

		if (checkDifficulty(difficulty)) { int.TryParse(difficulty, out intDifficulty); }
		else { DisplayAlert("Oopsies", "Difficulty must be an integer", "OK"); return; }
		InvalidFieldError result = bl.AddEntry(clue, answer, intDifficulty, date);
	}

	bool checkDifficulty(String difficulty)
	{
		int diff;
		return (int.TryParse(difficulty, out diff));
	}



}