using UnityEngine;

public class CameraJoueur : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject joueur;
    Rigidbody rb;
    void Start()
    {
        rb = joueur.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(rb.position.x, transform.position.y, rb.position.z);  
    }
}
