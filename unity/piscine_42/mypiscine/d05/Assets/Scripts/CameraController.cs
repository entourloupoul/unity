using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool freeCam;
    public bool waitRelease;
    public Vector2 rotation;
    public bool click;
    public GameObject ball;
    public GameObject hole;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(ball.transform);
        freeCam = false;
        click = true;

    }

    void OnCollisionEnter(Collision col)
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (freeCam == false && Input.GetKeyDown("e"))
        {
            waitRelease = true;
        }
        if (waitRelease == true && Input.GetKeyUp("e"))
        {
           

            rotation.y =  transform.eulerAngles.y -Input.GetAxis("Mouse X");
            rotation.x = transform.eulerAngles.x + Input.GetAxis("Mouse Y");


            waitRelease = false;
            freeCam = true;
            click = true;
        }
        if (freeCam == true && Input.GetKeyDown("space"))
        {
            freeCam = false;
            transform.LookAt(ball.transform);
            click = false;

        }
  
        if (freeCam == false)
            transform.LookAt(ball.transform);

        if (freeCam == true)
        {
            if (click == true)
            {
                rotation.y += Input.GetAxis("Mouse X");
                rotation.x += -Input.GetAxis("Mouse Y");
                transform.eulerAngles = rotation;
            }
            if (Input.GetKey("w"))
                gameObject.transform.Translate(Vector3.forward, Space.Self);
            if (Input.GetKey("s"))
                gameObject.transform.Translate(Vector3.back, Space.Self);
            if (Input.GetKey("a"))
                gameObject.transform.Translate(Vector3.left, Space.Self);
            if (Input.GetKey("d"))
                gameObject.transform.Translate(Vector3.right, Space.Self);
            if (Input.GetKey("e"))
                gameObject.transform.Translate(Vector3.up, Space.Self);
            if (Input.GetKey("q"))
                gameObject.transform.Translate(Vector3.down, Space.Self);

        }
    }
}
