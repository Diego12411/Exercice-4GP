using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.CharacterController;

public class MouvementJoueur : MonoBehaviour
{
    private float velociteY;
    private InputAction move;
    private InputAction sprint;
    private InputAction jump;
    private CharacterController cc;
    private float vitesseActuelle = -SingletonValeurs.Instance.vitesse;
    private Vector3 positionDepart;
    private float accelerationActuelle = SingletonValeurs.Instance.acceleration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jump = InputSystem.actions.FindAction("Jump");
        move = InputSystem.actions.FindAction("Move");
        sprint = InputSystem.actions.FindAction("Sprint");
        cc = GetComponent<CharacterController>();
        positionDepart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(vitesseActuelle);
        velociteY += Physics.gravity.y * Time.deltaTime;

        if (sprint.IsPressed())
        {
            vitesseActuelle = accelerationActuelle;
            Debug.Log("sprint");
        } else if (!sprint.IsPressed())
        {
            vitesseActuelle = SingletonValeurs.Instance.vitesse;
        }

        if (jump.IsPressed() && cc.isGrounded)
        {
            Debug.Log("jump");
            velociteY = 5;
        }

        Vector2 inputMove = move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputMove.x, 0, inputMove.y);

        Vector3 direction = transform.TransformDirection(movement * vitesseActuelle * Time.deltaTime);
        Vector3 playerMovementMoveJump = new Vector3(direction.x, velociteY * Time.deltaTime, direction.z);
        cc.Move(playerMovementMoveJump);

        if (cc.isGrounded)
        {
            velociteY = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            transform.position = positionDepart;
            Debug.Log("Touche");
        }
    }
}
