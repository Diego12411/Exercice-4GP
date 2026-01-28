using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GestionnaireJeu : MonoBehaviour
{
    private GameObject joueur;
    private Rigidbody rb;
    public ZoneObjectif zoneObjectif;
    [SerializeField]
    private TMP_Text affichagePoints;
    private int points = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joueur = GameObject.Find("Sphere");
        rb = joueur.GetComponent<Rigidbody>();
        zoneObjectif.OnEvenement += MecanismeArrive;
    }

    // Update is called once per frame
    void Update()
    { 
        float posYJoueur = joueur.transform.position.y;
        if (posYJoueur < -2)
        {
            joueur.transform.position = new Vector3(-20.53f, 0.43f, 0.29f);
            rb.linearVelocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
    }
    private void MecanismeArrive() {
        Debug.Log(joueur);
        float x = joueur.transform.position.x;
        float y = joueur.transform.position.y;
        float z = joueur.transform.position.z;

        GameObject clone = Instantiate(joueur);
        clone.GetComponent<Rigidbody>().isKinematic = true;
        points++;
        affichagePoints.text = "           " + points.ToString();
        joueur.transform.position = new Vector3(-24.3f, 1f, -16.7f);
    }
}
