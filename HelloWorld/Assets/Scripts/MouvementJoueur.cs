using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private InputAction _move;
    [SerializeField]private float niveauForce;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _move = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = _move.ReadValue<Vector2>();
        rb.AddForce(movement.x * niveauForce, 0, movement.y * niveauForce);
    }
}
