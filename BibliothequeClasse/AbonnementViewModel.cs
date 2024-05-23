using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeClasse
{
    public class AbonnementViewModel : INotifyPropertyChanged
    {
        private string _typeAbonnement;
        private int prix;
        private DateTime _dateDebut;
        private DateTime _dateFin;

        public string TypeAbonnement
        {
            get { return _typeAbonnement; }
            set
            {
                if (_typeAbonnement != value)
                {
                    _typeAbonnement = value;
                    OnPropertyChanged(nameof(TypeAbonnement));
                }
            }
        }

        public int Prix
        {
            get { return prix; }
            set
            {
                if (prix != value)
                {
                    prix = value;
                    OnPropertyChanged(nameof(Prix));
                }
            }
        }

        public DateTime DateDebut
        {
            get { return _dateDebut; }
            set
            {
                if (_dateDebut != value)
                {
                    _dateDebut = value;
                    OnPropertyChanged(nameof(DateDebut));
                }
            }
        }

        public DateTime DateFin
        {
            get { return _dateFin; }
            set
            {
                if (_dateFin != value)
                {
                    _dateFin = value;
                    OnPropertyChanged(nameof(DateFin));
                }
            }
        }
        

        public AbonnementViewModel()
        {
            TypeAbonnement = "INCONNU";
            Prix = 69;
            DateDebut = DateTime.Now;
            DateFin = DateTime.Now;
        }

        public AbonnementViewModel(string typeAbonnement, int prix, DateTime dateDebut, DateTime dateFin)
        {
            TypeAbonnement = typeAbonnement;
            Prix = prix;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }

        public override string ToString()
        {
            return $"{TypeAbonnement} - {Prix} - {DateDebut} - {DateFin}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
