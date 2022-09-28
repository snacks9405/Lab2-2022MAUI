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
		
		if (!int.TryParse(difficulty, out intDifficulty)) { DisplayAlert("Oopsies", "Difficulty must be an integer", "my bad"); return; }
        InvalidFieldError result = bl.AddEntry(clue, answer, intDifficulty, date);
		if (result != InvalidFieldError.NoError){ InvalidFieldReporter(result); }

      // EntriesList.ItemsSource = bl.GetEntries();
    }

	bool CheckDifficulty(String difficulty)
	{
		int diff;
		return (int.TryParse(difficulty, out diff));
	}

	void OnDeleteClicked(Object sender, EventArgs e)
	{
		
		Entry entry = (Entry)EntriesList.SelectedItem;
        if (entry == null){return;}
        EntryDeletionError result = bl.DeleteEntry(entry.Id);

		if (result != EntryDeletionError.NoError) { EntryDeletionReporter(result); }
       //EntriesList.ItemsSource = bl.GetEntries();

	
    }

	void OnEditClicked(Object sender, EventArgs e)
    {
        String clue = Clue.Text;
        String answer = Answer.Text;
        String date = Date.Text;
        String difficulty = Difficulty.Text;
		int intDifficulty;

        if (!int.TryParse(difficulty, out intDifficulty)) { DisplayAlert("Oopsies", "Difficulty must be an integer", "my bad"); return; }
        Entry entry = (Entry)EntriesList.SelectedItem;
        if (entry == null) {return;}
        EntryEditError result = bl.EditEntry(clue, answer, intDifficulty, date, entry.Id);
		if (result != EntryEditError.NoError) { EntryEditReporter(result); }
		//EntriesList.ItemsSource = bl.GetEntries();
    }

	void InvalidFieldReporter(InvalidFieldError e)
    {
		DisplayAlert("Oopsies", e.ToString(), "my bad");

    }

	void EntryDeletionReporter(EntryDeletionError e)
    {
		DisplayAlert("Oopsies", e.ToString(), "my bad");
    }

	void EntryEditReporter(EntryEditError e)
    {
		DisplayAlert("Oopsies", e.ToString(), "my bad");
    }
	
}