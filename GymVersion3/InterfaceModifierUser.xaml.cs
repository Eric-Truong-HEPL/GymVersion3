using BibliothequeClasse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GymVersion3
{
    /// <summary>
    /// Logique d'interaction pour InterfaceModifierUser.xaml
    /// </summary>
    public partial class InterfaceModifierUser : Window
    {
        public ClientViewModel ModifiedClient { get; set; }

        public InterfaceModifierUser(ClientViewModel client)
        {
            InitializeComponent();
            ModifiedClient = client.Clone(); // Clonez l'utilisateur pour éviter de modifier l'utilisateur original directement
            DataContext = ModifiedClient;
        }

        private void ModifierClientBouton(object sender, RoutedEventArgs e)
        {
            // Confirmez les modifications
            DialogResult = true;
            this.Close();
        }

        // Gérez les événements de parcours et autres fonctionnalités nécessaires
    }

}
