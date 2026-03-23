using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using System;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class ControleurInterface : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Quitter()
    {
#if UNITY_EDITOR
    EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void NouvellePartie()
    {
        SceneManager.LoadScene("Labyrinthe");
    }

public void LireVitesse(string valeur)
{
    if (float.TryParse(valeur, out float v))
        SingletonValeurs.Instance.vitesse = v;
        Debug.Log(valeur);
}
public void LireAcceleration(string valeur)
{
    if (float.TryParse(valeur, out float a))
        SingletonValeurs.Instance.acceleration = a;
        Debug.Log(valeur);
}
}
