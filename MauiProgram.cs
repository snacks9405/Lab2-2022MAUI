namespace Lab2_2022Maui;

/**
 * Names: Alex Rodriguez, Nick Miller
 * Date: 09/27/2022
 * Reflection: Learning the xaml component of the lab was probably the most confusing part of the lab for both of us. 
 *				It was hard to find the tools/methods we needed to make everything functional and visually appealing. 
 *	Bugs: None observed 			
 */



/**
 * creates the maui 
 */

public static class MauiProgram
{
	
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}

