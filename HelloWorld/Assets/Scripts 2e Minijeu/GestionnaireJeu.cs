using UnityEngine;

public class GestionnaireJeu : MonoBehaviour
{
    private GameObject joueur;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joueur = GameObject.Find("Sphere");
        rb = joueur.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float posYJoueur = joueur.transform.position.y;
        if (posYJoueur < -2)
        {
            joueur.transform.position = new Vector3(-20.53f, 0.43f, 0.29f);
            rb.linearVelocity = new Vector3(0,0,0);
            rb.angularVelocity = new Vector3(0,0,0);
        }
    }
}
