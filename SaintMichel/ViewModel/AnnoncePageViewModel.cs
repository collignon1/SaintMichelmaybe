using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core.Views;
using SaintMichel.Model;
using SaintMichel.Services;
//using Android.Media;

namespace SaintMichel.ViewModel
{
    public partial class AnnoncePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Petite_Annonce _selectedItem;
        public List<int> CategoriePicker { get; set; }
        public List<string> renumerationPicker { get; set; }

        private int _selectedCategory;
        public int SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (value != _selectedCategory)
                {
                    _selectedCategory = value;
                    OnPropertyChanged();
                    FilterAnnoncebyCategory();
                }
            }

        }

        private string _selectedRemuneration;
        public string SelectedRemuneration
        {
            get => _selectedRemuneration;
            set
            {
                if (value != _selectedRemuneration)
                {
                    _selectedRemuneration = value;
                    OnPropertyChanged();
                    FilterAnnoncebyRemuneration();
                }
            }
        }

        [ObservableProperty]
        private ObservableCollection<Petite_Annonce> _obsItems; // Les items à afficher dans le ListView

        PetitesAnnonces_API _API;

        public AnnoncePageViewModel(PetitesAnnonces_API api)
        {
            _API = api;
            ObsItems = new ObservableCollection<Petite_Annonce>(); // Initialisation de la collection Observable
            ObsItems.Clear();
            OnAppearing();
            renumerationPicker = new List<string>
            {
                "aucun filtre choisi","OUI","NON"
            };
            SelectedRemuneration = "aucun filtre choisi";

            //string[] categorie = {"Soutien Scolaire", "Baby Sitting", "Livreur", "Animateur", "Bénévolat", "Mentorat", "Bibliothèque", "Jardinage", "ménage", "Enquêtes", "Bricolage", "Test Produit", "Dons" };

            CategoriePicker = new List<int>
            { 
                0, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 
            };

            SelectedCategory = 0;

        }


        // Méthode pour charger les éléments depuis l'API
        async void OnAppearing()
        {
            ObsItems.Clear();
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

                foreach (var itemm in items)
                {
                    ObsItems.Add(itemm);
                }
            }
            catch (Exception ex)
            {
                ObsItems.Clear();
                Console.WriteLine($"Erreur: {ex.Message}"); // Afficher les erreurs dans la console
                await Application.Current.MainPage.DisplayAlert("Erreur", "Une erreur est survenue.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        
        async void FilterAnnoncebyCategory()
        {
            await LoadItems();

            if (SelectedCategory != 0 && SelectedRemuneration != "aucun filtre choisi")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.Compensation == SelectedRemuneration && o.categorie_annonce_idcategorie_annonce == SelectedCategory).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            // Si aucun secteur n'est sélectionné, afficher toutes les offres
            else if (SelectedCategory != 0 && SelectedRemuneration == "aucun filtre choisi")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.categorie_annonce_idcategorie_annonce == SelectedCategory).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            else if (SelectedCategory == 0 && SelectedRemuneration != "aucun filtre choisi")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.Compensation == SelectedRemuneration).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            else
            {
                ObsItems.Clear();
                await LoadItems();
                //return;
            }


        }

        async void FilterAnnoncebyRemuneration()
        {
            await LoadItems();

            if (SelectedCategory != 0 && SelectedRemuneration != "aucun filtre choisi")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.Compensation == SelectedRemuneration && o.categorie_annonce_idcategorie_annonce == SelectedCategory).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            // Si aucun secteur n'est sélectionné, afficher toutes les offres
            else if (SelectedCategory != 0 && SelectedRemuneration == "aucun filtre choisi")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.categorie_annonce_idcategorie_annonce == SelectedCategory).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            else if (SelectedCategory == 0 && SelectedRemuneration != "aucun filtre choisi")
            {
                // Filtrer les offres pour ne garder que celles correspondant au secteur sélectionné
                var filteredItems = ObsItems.Where(o => o.Compensation == SelectedRemuneration).ToList();


                // Vider la collection observable et ajouter les éléments filtrés
                ObsItems.Clear();
                foreach (var itemm in filteredItems)
                {
                    ObsItems.Add(itemm);
                }
            }
            else
            {
                ObsItems.Clear();
                await LoadItems();
                //return;
            }


        }

        [RelayCommand]
        async Task EventSelected()
        {
            if (SelectedItem == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(AnnonceDetailPage)}?{nameof(AnnonceDetailPageViewModel.IDhelp)}={SelectedItem.IDhelp}");
        }
    }
}
