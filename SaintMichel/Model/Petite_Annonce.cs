using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.Model
{
    public class Petite_Annonce
    {
        public int IDhelp { get; set; }
        public string Libelle { get; set; }
        public string Compensation { get; set; }
        public string DescriRecompense { get; set; }
        public string Lieu { get; set; }
        public string Date { get; set; }
        public int state { get; set; }
        public int user_iduser { get; set; }
        public int categorie_annonce_idcategorie_annonce { get; set; }
        
    }
}
