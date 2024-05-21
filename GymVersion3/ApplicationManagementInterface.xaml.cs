using BibliothequeClasse;
using System;
using System.Windows;

namespace GymVersion3
{
    public partial class ApplicationManagementInterface : Window
    {
        public Gym ViewModel { get; set; }

        public ApplicationManagementInterface()
        {
            InitializeComponent();
            ViewModel = new Gym();
            // Remplir avec des données fictives pour le test
            ViewModel.AjouterClient(new ClientViewModel("Doe", "John", "123 Main St", new DateTime(1990, 1, 1), "path/to/photo.jpg", new AbonnementViewModel("Premium", 100, DateTime.Now, DateTime.Now.AddYears(1))));
            ViewModel.AjouterClient(new ClientViewModel("Smith", "Jane", "456 Elm St", new DateTime(1985, 5, 10), "path/to/photo2.jpg", new AbonnementViewModel("Basic", 50, DateTime.Now, DateTime.Now.AddMonths(6))));
            DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
