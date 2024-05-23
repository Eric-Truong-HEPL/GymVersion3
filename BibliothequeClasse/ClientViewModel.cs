using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;


namespace BibliothequeClasse
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        private string _nom;
        private string _prenom;
        private DateTime _dateNaissance;
        private string _photoPath;
        private AbonnementViewModel _abonnement;

        public string Nom
        {
            get { return _nom; }
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }

        public string Prenom
        {
            get { return _prenom; }
            set
            {
                if (_prenom != value)
                {
                    _prenom = value;
                    OnPropertyChanged(nameof(Prenom));
                }
            }
        }


        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set
            {
                if (_dateNaissance != value)
                {
                    _dateNaissance = value;
                    OnPropertyChanged(nameof(DateNaissance));
                }
            }
        }

        public string PhotoPath
        {
            get { return _photoPath; }
            set
            {
                if (_photoPath != value)
                {
                    _photoPath = value;
                    OnPropertyChanged(nameof(PhotoPath));
                }
            }
        }

        public AbonnementViewModel Abonnement
        {
            get { return _abonnement; }
            set
            {
                if (_abonnement != value)
                {
                    _abonnement = value;
                    OnPropertyChanged(nameof(Abonnement));
                }
            }
        }


        public ClientViewModel()
        {
            _nom = "";
            _prenom = "";
            _dateNaissance = DateTime.Now;
            _photoPath = "";
            _abonnement = new AbonnementViewModel();
        }

        public ClientViewModel(string nom, string prenom, DateTime dateNaissance, string photoPath, AbonnementViewModel abonnement)
        {
            _nom = nom;
            _prenom = prenom;
            _dateNaissance = dateNaissance;
            _photoPath = photoPath;
            _abonnement = abonnement;
        }

        public ClientViewModel Clone()
        {
            return new ClientViewModel// le return va renvoyer tout les truc a l'interieur de l'accolade
            {
                Nom = this.Nom,
                Prenom = this.Prenom,
                DateNaissance = this.DateNaissance,
                PhotoPath = this.PhotoPath,
                Abonnement = new AbonnementViewModel
                {
                    TypeAbonnement = this.Abonnement.TypeAbonnement,
                    Prix = this.Abonnement.Prix,
                    DateDebut = this.Abonnement.DateDebut,
                    DateFin = this.Abonnement.DateFin
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }   

    }
}
