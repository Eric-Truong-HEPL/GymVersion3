using BibliothequeClasse;
using Microsoft.Win32;
using System.Windows;

namespace GymVersion3
{
    public partial class InterfaceAjouterUser : Window
    {
        public ClientViewModel Client { get; set; }

        public InterfaceAjouterUser()
        {
            InitializeComponent();
            Client = new ClientViewModel();
            DataContext = Client;
        }

        private void AjouterClientBouton(object sender, RoutedEventArgs e)
        {
            if (DataContext is ClientViewModel client)
            {
                // Créez un nouveau client à partir des données entrées
                ClientViewModel nouveauClient = new ClientViewModel(
                    client.Nom,
                    client.Prenom,
                    client.DateNaissance,
                    client.PhotoPath,
                    client.Abonnement
                );

                // Affichez le contenu du nouveau client pour le débogage
                MessageBox.Show($"Nouveau client:\nNom: {nouveauClient.Nom}\nPrénom: {nouveauClient.Prenom}\nDate de naissance: {nouveauClient.DateNaissance}\nChemin de la photo: {nouveauClient.PhotoPath}\nAbonnement: {nouveauClient.Abonnement}");

                // Retourner le nouveau client
                DialogResult = true;
                Client = nouveauClient;
            }
            this.Close();
        }


        private void Parcourir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers image (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                //je veux que le fichier soit de ce format comme ca "C:\\Users\\eric3\\Downloads\\@julmre_-profile(1).jpeg"
                PhotoPathTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
