using System.Collections;
using UnityEngine;

public class MovementHead : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject head;
    private float speed = 2.0f;
    private int direction;
    void Start()
    {
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        head.transform.localPosition = new Vector3(head.transform.localPosition.x + (speed * Time.deltaTime * direction), head.transform.localPosition.y, head.transform.localPosition.z);
        if (head.transform.localPosition.x >= 5f) {
            direction = -1;
        }
        else if (head.transform.localPosition.x <= -5f) {
            direction = 1;
        }
    }
}
