using BibliothequeClasse;
using Microsoft.Win32;//registery
using System;
using System.Text.Json;//pour la sérialisation des fichierzs json
using System.Windows;//pour la textbox
using System.IO;//pour la lecture et l'écriture des fichiers


namespace GymVersion3
{
    public partial class ApplicationManagementInterface : Window
    {
        public Gym ViewModel { get; set; }

        // Clé de registre pour stocker la position de la fenêtre
        private const string RegKey = "Software\\GymVersion3";
        private const string RegValueTop = "Top";
        private const string RegValueLeft = "Left";

        public ApplicationManagementInterface()
        {
            InitializeComponent();
            LoadWindowPosition();
            ViewModel = new Gym();
            // Remplir avec des données fictives pour le test
            ViewModel.AjouterClient(new ClientViewModel("Doe", "John", new DateTime(1990, 1, 1), "C:\\Users\\eric3\\Downloads\\@julmre_-profile(1).jpeg", new AbonnementViewModel("Premium", 100, DateTime.Now, DateTime.Now.AddYears(1))));
            ViewModel.AjouterClient(new ClientViewModel("Smith", "Jane", new DateTime(1985, 5, 10), "path/to/photo2.jpg", new AbonnementViewModel("Basic", 50, DateTime.Now, DateTime.Now.AddMonths(6))));
            DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)//debug a remove par la suite
        {
            this.Close();
        }
        private void InterfaceAjouterUser_Click(object sender, RoutedEventArgs e)
        {
            InterfaceAjouterUser interfaceAjouterUser = new InterfaceAjouterUser();
            bool? result = interfaceAjouterUser.ShowDialog();

            // Vérifiez si la fenêtre d'ajout de client a été fermée correctement et si un nouveau client a été créé
            if (result == true)
            {
                // Ajoutez le nouveau client à la liste dans le ViewModel
                ViewModel.AjouterClient(interfaceAjouterUser.Client);
            }
        }

        private void Sup_Click(object sender, RoutedEventArgs e)
        {
            int IndexASupprimer = 0;
            bool EstUnChiffre = false;

            while (!EstUnChiffre)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Entrez l'index du client à supprimer :", "Supprimer un client", "0");

                if (input == "")
                {
                    return;
                }

                EstUnChiffre = int.TryParse(input, out IndexASupprimer);//convertir la chaine en entier si EstUnChiffre est convertir alors indexASupprimer prend la valeur de la chaine converti sinon il prend 0 

                if (!EstUnChiffre)
                {
                    MessageBox.Show("Veuillez entrer un nombre valide.");
                }
            }

            
            if (IndexASupprimer >= 0 && IndexASupprimer < ViewModel.Clients.Count)
            {
                // Supprimez le client à l'index spécifié
                ViewModel.SupprimerClient(ViewModel.Clients[IndexASupprimer]);
            }
            else
            {
                MessageBox.Show("Chiffre invalide il y a aucun client qui correspondant a ce chiffre dans la liste stp entre un chiffre correct.");
            }
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Clients.Clear();
        }


        private void EnregistrerJson(object sender, RoutedEventArgs e)
        {
            string jsonString = JsonSerializer.Serialize(ViewModel.Clients);


            string filePath = "clients.json";


            File.WriteAllText(filePath, jsonString);


            MessageBox.Show("Liste des clients sauvegardée avec succès dans le fichier clients.json.");
        }

        private void ChargerJson(object sender, RoutedEventArgs e)
        {
            string filePath = "clients.json";

            if (File.Exists(filePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(filePath);

                    // Désérialiser le JSON en une liste de clients
                    List<ClientViewModel> clients = JsonSerializer.Deserialize<List<ClientViewModel>>(jsonString);

                    // Effacer la liste actuelle et ajouter les clients chargés
                    ViewModel.Clients.Clear();
                    foreach (var client in clients)
                    {
                        ViewModel.AjouterClient(client);
                    }

                    MessageBox.Show("Liste des clients chargée avec succès depuis le fichier clients.json.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite lors du chargement du fichier JSON : " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Le fichier clients.json n'existe pas.");
            }
        }


        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            // Demandez à l'utilisateur l'index de l'utilisateur à modifier
            int indexAModifier = -1;
            bool estUnChiffre = false;

            while (!estUnChiffre)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Entrez l'index de l'utilisateur à modifier :", "Modifier un utilisateur", "");

                if (input == "")
                {
                    return;
                }

                estUnChiffre = int.TryParse(input, out indexAModifier);

                if (!estUnChiffre)
                {
                    MessageBox.Show("Veuillez entrer un nombre valide.");
                }
            }

            // Vérifiez si l'index est valide
            if (indexAModifier >= 0 && indexAModifier < ViewModel.Clients.Count)
            {
                // Affichez la fenêtre de modification d'utilisateur avec les détails de l'utilisateur sélectionné
                InterfaceModifierUser interfaceModifierUser = new InterfaceModifierUser(ViewModel.Clients[indexAModifier]);
                bool? result = interfaceModifierUser.ShowDialog();

                // Vérifiez si l'utilisateur a confirmé les modifications
                if (result == true)
                {
                    // Mettez à jour les informations de l'utilisateur dans la liste
                    ViewModel.Clients[indexAModifier] = interfaceModifierUser.ModifiedClient;
                }
            }
            else
            {
                MessageBox.Show("Index invalide. Veuillez entrer un index valide.");
            }
        }




        private void SaveWindowPosition()
        {
            // Enregistrer la position de la fenêtre dans le registre
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RegKey);
            if (key != null)
            {
                key.SetValue(RegValueTop, Top);
                key.SetValue(RegValueLeft, Left);
                key.Close();
            }
        }

        private void LoadWindowPosition()
        {
            // Charger la position de la fenêtre à partir du registre
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegKey);
            if (key != null)
            {
                double top = Convert.ToDouble(key.GetValue(RegValueTop, Top));
                double left = Convert.ToDouble(key.GetValue(RegValueLeft, Left));
                Top = top;
                Left = left;
                key.Close();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            SaveWindowPosition();
        }
    }
}
