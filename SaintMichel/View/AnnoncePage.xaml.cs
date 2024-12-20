namespace SaintMichel.View;

public partial class AnnoncePage : ContentPage
{
	public AnnoncePage(AnnoncePageViewModel ViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel;

    }

}