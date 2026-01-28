using System;
using TMPro;
using UnityEngine;

public class ZoneObjectif : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject joueur;
    public event Action OnEvenement;
 

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnEvenement();
    }
}
