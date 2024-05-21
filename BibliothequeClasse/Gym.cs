using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BibliothequeClasse
{
    public class Gym : INotifyPropertyChanged
    {
        private ObservableCollection<ClientViewModel> _clients;

        public ObservableCollection<ClientViewModel> Clients
        {
            get { return _clients; }
            set
            {
                if (_clients != value)
                {
                    _clients = value;
                    OnPropertyChanged(nameof(Clients));
                }
            }
        }

        public Gym()
        {
            _clients = new ObservableCollection<ClientViewModel>();
        }

        public void AjouterClient(ClientViewModel client)
        {
            _clients.Add(client);
            OnPropertyChanged(nameof(Clients));
        }

        public void SupprimerClient(ClientViewModel client)
        {
            _clients.Remove(client);
            OnPropertyChanged(nameof(Clients));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
