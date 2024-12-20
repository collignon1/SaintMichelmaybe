using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.ViewModel
{
    [QueryProperty(nameof(IDhelp), nameof(IDhelp))]
    public partial class AnnonceDetailPageViewModel : BaseViewModel
    {
        public int IDhelp { get; set; }
        int nombre_offre = 0;
        
        [ObservableProperty]
        private ObservableCollection<Petite_Annonce> _obsItems; // Les items à afficher dans le ListView

        PetitesAnnonces_API _API;

        public AnnonceDetailPageViewModel(PetitesAnnonces_API api)
        {
            
            _API = api;
            ObsItems = new ObservableCollection<Petite_Annonce>(); // Initialisation de la collection Observable
            OnAppearing();
        }
        // Méthode pour charger les éléments depuis l'API
        async void OnAppearing()
        {

            await LoadItems();
        }

        [RelayCommand]
        async Task LoadItems()
        {
            IsBusy = true;
            try
            {
                ObsItems.Clear();
                var items = await _API.GetAnnonceAsync(); // Appel API pour récupérer les données
                if (0 > nombre_offre) // Vérifier qu'il y a au moins deux éléments
                {
                    ObsItems.Add(items.First()); // Ignorer le premier élément et ajouter le deuxième
                }
                else if (items.Count() <= nombre_offre) // Vérifier qu'il y a au moins deux éléments
                {
                    nombre_offre = items.Count() - 1;
                    ObsItems.Add(items.Skip(nombre_offre).First()); // Ignorer le premier élément et ajouter le deuxième
                }
                else if (items.Count() > nombre_offre) // Vérifier qu'il y a au moins deux éléments
                {
                    ObsItems.Add(items.Skip(nombre_offre).First()); // Ignorer le premier élément et ajouter le deuxième
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}"); // Afficher les erreurs dans la console
                await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur est survenue.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        //async Task LoadItems()
        //{
        //    IsBusy = true;
        //    try
        //    {
        //        ObsItems.Clear();
        //        var items = (await _API.GetAnnonceAsync()).FirstOrDefault(item >= item.IDhelp == IDhelp); // Appel API pour récupérer les données
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erreur: {ex.Message}"); // Afficher les erreurs dans la console
        //        await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur est survenue.", "OK");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        
    }
}
