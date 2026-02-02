using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private InputAction _move;
    private InputAction _jump;
    [SerializeField]private float niveauForce;
    private Rigidbody rb;
    private bool CanJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _move = InputSystem.actions.FindAction("Move");
        _jump = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = _move.ReadValue<Vector2>();
        rb.AddForce(movement.x * niveauForce, 0, movement.y * niveauForce);

        float jump = _jump.ReadValue<float>();
        if (jump == 1 && CanJump) {
            rb.AddForce(0f, 400f, 0f);
            CanJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")){
            CanJump = true;
        }
    }
}
