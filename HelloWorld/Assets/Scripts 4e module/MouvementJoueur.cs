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
    private int force = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jump = InputSystem.actions.FindAction("Jump");
        move = InputSystem.actions.FindAction("Move");
        sprint = InputSystem.actions.FindAction("Sprint");
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        velociteY += Physics.gravity.y * Time.deltaTime;

        if (sprint.IsPressed())
        {
            force = 2;
            Debug.Log("sprint");
        } else if (!sprint.IsPressed())
        {
            force = 1;
        }

        if (jump.IsPressed() && cc.isGrounded)
        {
            Debug.Log("jump");
            velociteY = 5;
        }

        Vector2 inputMove = move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputMove.x, 0, inputMove.y);

        Vector3 direction = transform.TransformDirection(movement * force * Time.deltaTime);
        Vector3 playerMovementMoveJump = new Vector3(direction.x, velociteY * Time.deltaTime, direction.z);
        cc.Move(playerMovementMoveJump);

        if (cc.isGrounded)
        {
            velociteY = 0;
        }
    }
}
