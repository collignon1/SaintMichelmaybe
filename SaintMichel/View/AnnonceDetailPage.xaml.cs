namespace SaintMichel.View;

public partial class AnnonceDetailPage : ContentPage
{
	public AnnonceDetailPage(AnnonceDetailPageViewModel ViewModel)
	{
		InitializeComponent();
        BindingContext = ViewModel;

    }
}