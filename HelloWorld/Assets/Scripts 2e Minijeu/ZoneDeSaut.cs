using UnityEngine;

public class ZoneDeSaut : MonoBehaviour
{
    [SerializeField]
    private GameObject joueur;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = joueur.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.AddForce(0f, 700f, 0f);
    }
}
