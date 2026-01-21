using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private InputAction _move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _move = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = _move.ReadValue<Vector2>();
        Vector3 vitesse = 10 * new Vector3(movement.x, 0, movement.y);
        transform.position += vitesse * Time.deltaTime;
    }
    void FixedUpdate()
    {
        
    }
}
