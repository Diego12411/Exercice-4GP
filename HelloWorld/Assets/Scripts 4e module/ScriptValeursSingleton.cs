using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScriptValeursSingleton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static ScriptValeursSingleton Instance { get; } = new ScriptValeursSingleton();
    [SerializeField] private InputField vitesseInput;
    [SerializeField] private InputField accelerationInput;

    private int vitesse;
    private int acceleration;
    private ScriptValeursSingleton()
    {
        acceleration = 0;
        vitesse = 0;
    }

    public void ChangerVitesse()
    {
        if (int.TryParse(vitesseInput.text, out int result))
        {
            vitesse = result;
            Debug.Log(vitesse);
        }

        void ChangerAcceleration()
        {

        }
    }
}
   