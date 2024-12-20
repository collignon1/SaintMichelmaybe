using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SaintMichel.Services
{
    public class PetitesAnnonces_API
    {
        private readonly string _baseURL;
        readonly List<Petite_Annonce> lsPetite_Annonce;
        public PetitesAnnonces_API()
        {

            _baseURL = "http://saintmichel.alwaysdata.net/";
        }

        public async Task<Petite_Annonce> GetAnnonceAsync(int id)
        {
            return await Task.FromResult(lsPetite_Annonce.FirstOrDefault(s => s.IDhelp == id));
        }

        public async Task<IEnumerable<Petite_Annonce>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(lsPetite_Annonce);
        }

        public async Task<List<Petite_Annonce>> GetAnnonceAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string requestUrl = $"{_baseURL}/GetAllAnnonceHorsDons";
                    HttpResponseMessage responseMessage = await client.GetAsync(requestUrl);
                    responseMessage.EnsureSuccessStatusCode();
                    string json = await responseMessage.Content.ReadAsStringAsync();
                    List<Petite_Annonce> annonces = JsonConvert.DeserializeObject<List<Petite_Annonce>>(json);
                    return annonces;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"erreur lors de la récupération des annonces : {e.Message}");
                    return null;
                }


            }
        }
    }
}
