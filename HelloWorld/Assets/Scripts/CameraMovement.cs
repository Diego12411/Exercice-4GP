using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject joueur;
    private float hauteurCamera;
    private float positionCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joueur = GameObject.Find("Sphere");
    }

    // LateUpdate is called once per frame after all Update methods have been called
    void LateUpdate()
    {
        transform.position = new Vector3(joueur.transform.position.x, 5, joueur.transform.position.z );
    }
}
