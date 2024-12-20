

namespace SaintMichel.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        // Private field with camelCase (btnText) 
        [ObservableProperty]
        private string? btnText = "rff";  // This generates a property BtnText


        [ObservableProperty]
        private string? headtxt = "click bot";



        int count = 0;

        [RelayCommand]
        async void CounterBtn()
        {
            count++;

            if (count == 1)
                BtnText = $"Clicked {count} timeeeeeeeeeeeee";
            else
                BtnText = $"Clicked {count} timessssssssssssss";

            SemanticScreenReader.Announce(BtnText);
        }

        [RelayCommand]
        async Task GotoTodoView()
        {
            if (IsBusy) return;
            IsBusy = true;
            await Shell.Current.GoToAsync("ItemPage");
            IsBusy = false;
        }

        [RelayCommand]
        async Task GotoAnnonceView()
        {
            if (IsBusy) return;
            IsBusy = true;
            PetitesAnnonces_API param1Value = new PetitesAnnonces_API();
            await Shell.Current.GoToAsync($"AnnoncePage?param1={param1Value}"); 
            IsBusy = false;
        }
    }
}


