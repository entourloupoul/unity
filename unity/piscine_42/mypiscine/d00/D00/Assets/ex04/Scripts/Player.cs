using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float velocity;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 0.1f;
    }

    public void UpScore()
    {
        score += 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Player1")
        {
            if (gameObject.transform.position.y < 3.55f && Input.GetKey("w"))
            {
                transform.Translate(0, velocity, 0);
            }
            if (gameObject.transform.position.y > -3.55f && Input.GetKey("s"))
            {
                transform.Translate(0, -velocity, 0);
            }
        }
        if (gameObject.name == "Player2")
        {
            if (gameObject.transform.position.y < 3.55f && Input.GetKey("up"))
            {
                transform.Translate(0, velocity, 0);
            }
            if (gameObject.transform.position.y > -3.55f && Input.GetKey("down"))
            {
                transform.Translate(0, -velocity, 0);
            }
        }
    }
}