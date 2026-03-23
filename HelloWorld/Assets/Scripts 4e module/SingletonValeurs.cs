public class SingletonValeurs
{
    // Instance unique de mon objet
    public static SingletonValeurs Instance { get; } = new SingletonValeurs();
    public float vitesse;
    public float acceleration;

    // Constructeur ***private*** : personne peut le creer
    private SingletonValeurs()
    {
        vitesse = 0;
        acceleration = 0;
    }

    // Methodes et attributs du singleton ...
}