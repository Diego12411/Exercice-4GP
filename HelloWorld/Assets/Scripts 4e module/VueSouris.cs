using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class VueSouris : MonoBehaviour
{
    private InputAction look;
    private GameObject player;
    private Vector3 rotationPlayer;
    private Vector3 rotationCamera;
    [SerializeField] private int forceRotation;
    private float rotationActuelleCamera;
    private int force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        look = InputSystem.actions.FindAction("Look");
        player = transform.parent.gameObject;
        force = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputSouris = look.ReadValue<Vector2>();
        rotationPlayer = new Vector3(0, inputSouris.x, 0) * Time.deltaTime * forceRotation;
        rotationCamera = new Vector3(-inputSouris.y, 0, 0) * Time.deltaTime * forceRotation;
        player.transform.Rotate(rotationPlayer*force);

        if (rotationActuelleCamera <= 30 && rotationActuelleCamera >= -30)
        {
            transform.Rotate(rotationCamera*force);
            rotationActuelleCamera += rotationCamera.x*force;

        }
        if (rotationActuelleCamera > 30)
        {
            rotationActuelleCamera = 30;
            transform.localEulerAngles = new Vector3(30,0,0);
        }
        else if (rotationActuelleCamera < -30)
        {
            rotationActuelleCamera = -30;
            transform.localEulerAngles = new Vector3(-30, 0, 0);
        }
    }
}
