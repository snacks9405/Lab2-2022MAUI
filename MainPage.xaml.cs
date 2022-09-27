namespace Lab2_2022Maui;
using Lab2_2022;
using System.Threading.Tasks;

public partial class MainPage : ContentPage
{
	IBusinessLogic bl = new BusinessLogic();
    public MainPage()
	{
		
		InitializeComponent();
        //EntriesList.ItemsSource = bl.GetEntries();
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
	}

	bool CheckDifficulty(String difficulty)
	{
		int diff;
		return (int.TryParse(difficulty, out diff));
	}

 //   async Task OnDeleteEntryClicked(Object sender, EventArgs e)
 //   {
	//	String numEntry = GetEntryID();
	//	if (!int.TryParse(numEntry, out intNumEntry)) { await DisplayAlert("Invalid Entry ID", "Entry {0} does not exist.", numEntry);}

 //       EntryDeletionError result = bl.DeleteEntry(intNumEntry);
 //       if (result != EntryDeletionError.NoError)
 //       {
 //           Console.WriteLine("Error while deleting entry: {0}", result);
 //       }
 //   }
	
	//async Task GetEntryID()
	//{
 //       String numEntry = await DisplayPromptAsync("Delete Entry", "Enter entry ID to delete: ");
	//	return numEntry;
 //   }
}