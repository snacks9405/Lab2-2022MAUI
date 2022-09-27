namespace Lab2_2022Maui;
using Lab2_2022;
using System.Threading.Tasks;

public partial class MainPage : ContentPage
{
	IBusinessLogic bl = new BusinessLogic();

    public MainPage()
	{
		
		InitializeComponent();
        EntriesList.ItemsSource = bl.GetEntries();
    }

	void OnAddEntryClicked(Object sender, EventArgs e)
	{

		String clue = Clue.Text;
		String answer = Answer.Text;
		String date = Date.Text;
		String difficulty = Difficulty.Text;
		int intDifficulty;

		if (CheckDifficulty(difficulty)) { int.TryParse(difficulty, out intDifficulty); }
		else { DisplayAlert("Oopsies", "Difficulty must be an integer", "OK"); return; }
		InvalidFieldError result = bl.AddEntry(clue, answer, intDifficulty, date);

        EntriesList.ItemsSource = bl.GetEntries();
    }

	bool CheckDifficulty(String difficulty)
	{
		int diff;
		return (int.TryParse(difficulty, out diff));
	}

	void OnDeleteTaskClicked(Object sender, EventArgs e)
	{
		Entry entry = (Entry)EntriesList.SelectedItem;
        bl.DeleteEntry(entry.Id);

        EntriesList.ItemsSource = bl.GetEntries();
    }
}