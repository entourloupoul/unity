using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 force;
    private Rigidbody rB;

    // Start is called before the first frame update
    void Start()
    {
        force = Vector3.zero;
        rB = gameObject.GetComponent<Rigidbody>();
    }

    void move()
    {
        rB.AddForce(force, ForceMode.Acceleration);
        force = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (force != Vector3.zero)
        {
            Debug.Log("move");
            move();
        }
    }
}
