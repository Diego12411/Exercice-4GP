using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPersonnage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Vector3 direction;
    private Vector3 objectif;
    private Quaternion rotationFinale;
    private bool peutBouger;
    private Rigidbody rb;
    void Start()
    {
        peutBouger = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current.leftButton.wasPressedThisFrame && peutBouger) {
            peutBouger = false;
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 direction = (hit.point - rb.position).normalized;
                objectif = hit.point;
                rotationFinale = Quaternion.LookRotation(direction);
                Coroutine coDeplace = StartCoroutine(DeplacerPersonnage(direction));
                Coroutine coRotation = StartCoroutine(RotaterPersonnage(rotationFinale));
            }
        }

    }
        IEnumerator DeplacerPersonnage(Vector3 direction) {
        while ((rb.position - objectif).magnitude > 0.5f)
        {
            rb.position += Time.deltaTime * direction;
            yield return null;
        }
        StopCoroutine(DeplacerPersonnage(direction));
        peutBouger = true;
    }

        IEnumerator RotaterPersonnage(Quaternion rotationFinale)
    {
        while (rb.rotation != rotationFinale)
        {
            var rotate = 50 * Time.deltaTime;
            rb.rotation = Quaternion.RotateTowards(rb.rotation, rotationFinale, rotate);
            yield return null;
        }
        StopCoroutine(RotaterPersonnage(rotationFinale));
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopAllCoroutines();
        peutBouger = true;
    }
}
