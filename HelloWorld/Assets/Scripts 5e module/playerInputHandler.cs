using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class playerInputHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Animator animator;
    private Vector3 direction;
    private Vector3 objectif;
    private Quaternion rotationFinale;
    private bool peutBouger;
    private Rigidbody rb;
    NavMeshAgent myNavMeshAgent;
    void Start()
    {
        animator = GetComponent<Animator>();
        peutBouger = true;
        rb = GetComponent<Rigidbody>();
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            animator.SetTrigger("Attack");
        }


        if (Mouse.current.leftButton.wasPressedThisFrame && peutBouger)
        {
            animator.SetBool("Walk", true);
            peutBouger = false;
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 direction = (hit.point - rb.position).normalized;
                objectif = hit.point;
                myNavMeshAgent.SetDestination(objectif);
            }
        }

        if (!myNavMeshAgent.pathPending) // 1. Attendre que le chemin soit calculé
        {
            if (myNavMeshAgent.remainingDistance <= myNavMeshAgent.stoppingDistance) // 2. Vérifier la distance restante
            {
                if (!myNavMeshAgent.hasPath || myNavMeshAgent.velocity.sqrMagnitude == 0f) // 3. Confirmer l'arrêt
                {
                    Debug.Log("L'agent est arrivé à destination sur la surface.");
                    peutBouger = true;
                    animator.SetBool("Walk", false);
                    Debug.Log("Destination atteinte !");
                }
            }
        }
    }
}
