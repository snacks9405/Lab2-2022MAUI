namespace Lab2_2022Maui;
using Lab2_2022;
/**
 * nick and alex
 * lab 2
 * 9.27.22
 * bugs:	the list doesn't scroll it just stretches to fit the entries.
 *			I think we used observable object wrong. should have pointed to the 
 *			original in database or something. that could have been better.
 *			date validation was rushed as we discovered that it wasn't included at the very
 *			last minute. 
 *			couldn't find how to change the bar across the top that just says HOME
 *			entry fields don't clear on add/delete/modify
 *			keyboard covers up difficulty and date when deployed
 * reflection: took a while to figure out the visual components. pretty cool how we're just
 * putting our old projects into the new ones. 
 * 
 */
public partial class MainPage : ContentPage
{
	IBusinessLogic bl = new BusinessLogic();

	public MainPage()
	{

		InitializeComponent();
		EntriesList.ItemsSource = bl.GetEntries();
	}

	/// <summary>
	/// when add is clicked, this quickly checks the validity of the difficulty and sends it to logic
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	void OnAddEntryClicked(Object sender, EventArgs e)
	{

		String clue = Clue.Text;
		String answer = Answer.Text;
		String date = Date.Text;
		String difficulty = Difficulty.Text;
		int intDifficulty;

		if (!int.TryParse(difficulty, out intDifficulty)) { DisplayAlert("Oopsies", "Difficulty must be an integer", "my bad"); return; }
		InvalidFieldError result = bl.AddEntry(clue, answer, intDifficulty, date);
		if (result != InvalidFieldError.NoError) { InvalidFieldReporter(result); }

		EntriesList.ItemsSource = bl.GetEntries();
	}

	/// <summary>
	/// simple tool to make sure it's an integer
	/// </summary>
	/// <param name="difficulty"></param>
	/// <returns></returns>
	bool CheckDifficulty(String difficulty)
	{
		int diff;
		return (int.TryParse(difficulty, out diff));
	}

	/// <summary>
	/// when delete is clicked, the selected item of the list is deleted
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	void OnDeleteClicked(Object sender, EventArgs e)
	{

		Entry entry = (Entry)EntriesList.SelectedItem;
		if (entry == null) { return; }
		EntryDeletionError result = bl.DeleteEntry(entry.Id);

		if (result != EntryDeletionError.NoError) { EntryDeletionReporter(result); }
		EntriesList.ItemsSource = bl.GetEntries();


	}

	/// <summary>
	/// when edit is clicked, the selected item of the list will grab the fields at the bottom 
	/// and insert the new values into the old entry
	/// 
	/// 
	/// as I'm typing this comment I realized I could have done this easier by reusing the delete/add methods above
	/// OOPS
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	void OnEditClicked(Object sender, EventArgs e)
	{
		String clue = Clue.Text;
		String answer = Answer.Text;
		String date = Date.Text;
		String difficulty = Difficulty.Text;
		int intDifficulty;

		if (!int.TryParse(difficulty, out intDifficulty)) { DisplayAlert("Oopsies", "Difficulty must be an integer", "my bad"); return; }
		Entry entry = (Entry)EntriesList.SelectedItem;
		if (entry == null) { return; }
		EntryEditError result = bl.EditEntry(clue, answer, intDifficulty, date, entry.Id);
		if (result != EntryEditError.NoError) { EntryEditReporter(result); }
		EntriesList.ItemsSource = bl.GetEntries();
	}

	/// <summary>
	/// the three following sections just grab up all of those errors your original solution was throwing and puts them
	/// up as alerts for the user. 
	/// </summary>
	/// <param name="e"></param>
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