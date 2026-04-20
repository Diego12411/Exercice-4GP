using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class playerInputHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject[] TableauPointsPatrouille;
    Animator animator;
    private bool peutBouger;
    private Vector3 cible;
    NavMeshAgent myNavMeshAgent;
    void Start()
    {
        animator = GetComponent<Animator>();
        peutBouger = true;
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        cible = TableauPointsPatrouille[Random.Range(0,4)].transform.position;
        myNavMeshAgent.SetDestination(cible);

    }

    // Update is called once per frame
    void Update()
    {
        if (!myNavMeshAgent.pathPending) // 1. Attendre que le chemin soit calcul�
        {
            animator.SetBool("Walk", true);
            if (myNavMeshAgent.remainingDistance <= myNavMeshAgent.stoppingDistance) // 2. V�rifier la distance restante
            {
                if (!myNavMeshAgent.hasPath || myNavMeshAgent.velocity.sqrMagnitude == 0f) // 3. Confirmer l'arr�t
                {
                    Debug.Log("L'agent est arrive a destination sur la surface.");
                    peutBouger = true;
                    animator.SetBool("Walk", false);
                    Debug.Log("Destination atteinte !");
                    cible = TableauPointsPatrouille[Random.Range(0,4)].transform.position;
        myNavMeshAgent.SetDestination(cible);
                }
            }
        }
    }
}
