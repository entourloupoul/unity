using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject cam;
    private Ball ballScript;

    // Start is called before the first frame update
    void Start()
    {
        ballScript = ball.GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            ballScript.force = new Vector3(0, 10000, 0);
    }
}
