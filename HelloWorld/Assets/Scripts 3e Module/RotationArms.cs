using Unity.VisualScripting;
using UnityEngine;

public class RotationArms : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject arm;
    private float angle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += 50f * Time.deltaTime;
        arm.transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }
}
