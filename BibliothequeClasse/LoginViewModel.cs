namespace BibliothequeClasse;
using System.ComponentModel;
using System.Security;

public class LoginViewModel : INotifyPropertyChanged
{
    private string _utilisateur;
    private SecureString _motDePasse;

    public string Utilisateur
    {
        get { return _utilisateur; }
        set
        {
            if (_utilisateur != value)
            {
                _utilisateur = value;
                OnPropertyChanged(nameof(Utilisateur));
            }
        }
    }

    public SecureString MotDePasse
    {
        get { return _motDePasse; }
        set
        {
            if (_motDePasse != value)
            {
                _motDePasse = value;
                OnPropertyChanged(nameof(MotDePasse));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}
