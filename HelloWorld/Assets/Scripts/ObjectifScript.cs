using System;
using System.Data;
using UnityEditor;
using UnityEngine;

public class ObjectifScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject joueur;
    private Rigidbody rb;
    private bool attente;
    private float tempsAttendre = 2f;
    private float timer = 0f;
    void Start()
    {
        joueur = GameObject.Find("Sphere");
        rb = joueur.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attente && timer < tempsAttendre)
        {
            timer += Time.deltaTime;
        }
        else if (attente && timer >= tempsAttendre)
        {
            timer = 0f;
            
        joueur.transform.position = new Vector3(-24.3f, 4f, -16.7f);
        attente=false;
        }
    }

    void OnCollisionEnter()
    {
        attente=true;
        rb.linearVelocity = Vector3.zero;
    }
}
