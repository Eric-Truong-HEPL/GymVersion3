using BibliothequeClasse;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace GymVersion3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new LoginViewModel();
            DataContext = ViewModel;
        }

        public LoginViewModel ViewModel { get; set; }

        private void AfficherButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                string username = viewModel.Utilisateur;
                string password = new System.Net.NetworkCredential(string.Empty, viewModel.MotDePasse).Password;

                MessageBox.Show($"Username: {username}\nPassword: {password}", "Informations");
            }
        }

        private void EnregistrerButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                string username = viewModel.Utilisateur;
                string password = new System.Net.NetworkCredential(string.Empty, viewModel.MotDePasse).Password;

                string filePath = "DossierTopSecretPasTouche.txt";

                try
                {
                    bool fileExists = File.Exists(filePath);

                    // Utilise le StreamWriter en mode append si le fichier existe, sinon le crée
                    using (StreamWriter writer = new StreamWriter(filePath, fileExists))
                    {
                        if (fileExists)
                        {
                            // Si le fichier existe, place le curseur à la fin du fichier
                            writer.BaseStream.Seek(0, SeekOrigin.End);
                        }
                        else
                        {
                            // On le crée
                            writer.WriteLine("Format du texte");
                            writer.WriteLine("Utilisateur: MotDePasse:");
                        }

                        //si username et password ne sont pas vide
                        if (username != "" && password != "")
                        {
                            // Écrit les données de l'utilisateur
                            writer.WriteLine($"{username} {password}");
                        }
                        writer.Close();
                    }

                    MessageBox.Show("Données ajoutées au fichier texte avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'écriture dans le fichier texte : {ex.Message}");
                }
            }
        }

        private void ConnexionButtion_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                string username = viewModel.Utilisateur;
                string password = new System.Net.NetworkCredential(string.Empty, viewModel.MotDePasse).Password;

                string filePath = "DossierTopSecretPasTouche.txt";

                try
                {
                    // Vérifie si le fichier existe
                    if (File.Exists(filePath))
                    {
                        // Lit toutes les lignes du fichier et le stocke dans un index
                        string[] lines = File.ReadAllLines(filePath);

                        // Parcourt chaque ligne pour trouver les informations d'identification
                        foreach (string line in lines)
                        {
                            // Sépare la ligne en username et password car j'ai mit un espacement entre les deux
                            string[] parts = line.Split(' ');

                            // Vérifie si les informations d'identification correspondent
                            if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                            {
                                MessageBox.Show("Connexion réussie !");
                                // Instancie l'interface de gestion des clients
                                ApplicationManagementInterface applicationManagementInterface = new ApplicationManagementInterface();
                                applicationManagementInterface.Show();
                                this.Close();
                                return;
                            }
                        }
                    }

                    // Si les informations d'identification ne correspondent pas
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la lecture du fichier texte : {ex.Message}");
                }
            }
        }

        //car tu peux pas manipuler directement un SecureString en gros eric et c'est invoquer quand le mdp change
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.MotDePasse = ((PasswordBox)sender).SecurePassword;
            }
        }
    }
}
