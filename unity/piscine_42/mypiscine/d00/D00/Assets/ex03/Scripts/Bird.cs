using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private float upVelocity;
    private float downVelocity;
    public static float velocity;
    public static int alive;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        upVelocity = 0.2f;
        alive = 1;
        score = 0;
    }

    void Death()
    {
        Debug.Log("Score: " + score);
        Debug.Log("Time: " + Mathf.RoundToInt(Time.time));
        alive = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && alive == 1)
        {
            velocity = upVelocity;
        }
        if (gameObject.transform.position.y >= 4.62f)
            velocity = 0;
        if (gameObject.transform.position.y < -3.64f)
        {
            velocity = 0;
            if (alive == 1)
            {
                alive = 0;
            }
        }
        if (alive == 0)
            Death();
        if (alive == 1)
        {
            velocity -= 0.01f;
            transform.Translate(0, velocity, 0);

        }
    }
}
