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
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current.leftButton.wasPressedThisFrame) {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 direction = (hit.point - transform.position).normalized;
                objectif = hit.point;
                rotationFinale = Quaternion.LookRotation(direction);
                Coroutine coDeplace = StartCoroutine(DeplacerPersonnage(direction));
                Coroutine coRotation = StartCoroutine(RotaterPersonnage(rotationFinale));
            }
        }

    }
        IEnumerator DeplacerPersonnage(Vector3 direction) {
        while ((transform.position - objectif).magnitude > 0.5f)
        {
            transform.position += Time.deltaTime * direction;
            yield return null;
        }
        StopCoroutine(DeplacerPersonnage(direction));
    }

        IEnumerator RotaterPersonnage(Quaternion rotationFinale)
    {
        while (transform.rotation != rotationFinale)
        {
            var rotate = 50 * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationFinale, rotate);
            yield return null;
        }
        StopCoroutine(RotaterPersonnage(rotationFinale));
    }
 }
