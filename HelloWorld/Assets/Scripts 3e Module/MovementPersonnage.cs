using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPersonnage : MonoBehaviour
{
    private IEnumerator DeplacerPersonnage(Vector3 direction);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) //question, cest quoi et comment ca marche le ray, cest quoi RayCast, cest quoi
            {
                Vector3 direction = (transform.position - hit.point).normalized;
                while ((transform.position - objectif).magnitude > 0.5f){
                    transform.position += Time.deltaTime * direction;
                    yield return null;
                }
            }
        }

    }
}
