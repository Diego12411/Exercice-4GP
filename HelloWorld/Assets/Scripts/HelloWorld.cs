using System.Xml;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    private bool EstGrandissant;
    private int Max = 8;
    private int Min = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(3, 3, 3);
        Debug.Log(transform.localScale.magnitude);
        if (transform.localScale.magnitude < Max)
        {
            EstGrandissant = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EstGrandissant)
        {
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            if (transform.localScale.magnitude >= Max){
                EstGrandissant= false;
            }
        } else if (!EstGrandissant)
        {
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
        }
        if (transform.localScale.magnitude >= Max)
        {
            EstGrandissant = false;
        }
        else  if (transform.localScale.magnitude <= Min)
        {
            EstGrandissant = true;
        }
    }
}
