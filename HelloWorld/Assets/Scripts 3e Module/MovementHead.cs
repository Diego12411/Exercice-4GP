using System.Collections;
using UnityEngine;

public class MovementHead : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 2.0f;
    private int direction;
    void Start()
    {
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //*
        //transform.localPosition = new Vector3(transform.localPosition.x + (speed * Time.deltaTime * direction), transform.localPosition.y, transform.localPosition.z);
        //if (transform.localPosition.x >= 3f) {
            //direction = -1;
        //}
        //else if (transform.localPosition.x <= -3f) {
            //direction = 1;
        //}
    }
}
