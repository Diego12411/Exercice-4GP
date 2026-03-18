using UnityEngine;
using UnityEngine.SceneManagement;
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
}
