using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    float pullVelocity;
    float strikeVelocity;
    int power;
    float delta;
    int ready;
    float strikeDist;
    public GameObject ball;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 15;
        pullVelocity = -0.1f;
        strikeVelocity = 0.3f;
        delta = -1.4f;
        power = 0;
        ready = 1;
        ball = GameObject.Find("ball");
        Debug.Log("Score: " + score);
    }

    // GetReady is called to initiate the club pos and value after each strike
    void GetReady()
    {
        Vector3 scale;
        Vector3 pos;

        score -= 5;
        ball = GameObject.Find("ball");
        if (ball.transform.position.y > 7.1)
        {
            delta = 1.4f;
            scale = new Vector3(2f, -2f, 1f);
            pos = new Vector3(-0.38f, ball.transform.position.y + delta, -2f);
            gameObject.transform.localScale = scale;
            gameObject.transform.position = pos;
            pullVelocity = 0.1f;
            strikeVelocity = -0.3f;
            Ball.direction = -1;
        }
        if (ball.transform.position.y < 5.95)
        {
            delta = -1.4f;
            scale = new Vector3(2f, 2f, 1f);
            gameObject.transform.localScale = scale;
            pos = new Vector3(-0.38f, ball.transform.position.y + delta, -2f);
            gameObject.transform.position = pos;
            pullVelocity = -0.1f;
            strikeVelocity = 0.3f;
            Ball.direction = 1;
        }
        Debug.Log("Score: " + score);
        ready = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Ball.velocity == 0)
        {
            if (power == 0 && ready == 0)
            {
                GetReady();
            }
            if (Input.GetKey("space") && ready == 1)
            {
                transform.Translate(0, pullVelocity, 0);
                power += 1;
            }
            if (Input.GetKey("space") == false && power > 0)
            {
                ready = -1;
                strikeDist = gameObject.transform.position.y - ball.transform.position.y;
                if ((strikeDist < 0 && strikeDist < delta) || (strikeDist > 0 && strikeDist > delta))
                {
                    transform.Translate(0, strikeVelocity, 0);
                    if (strikeVelocity > 0)
                        strikeVelocity += 0.05f;
                    else
                        strikeVelocity -= 0.05f;
                }
                else
                {
                    Ball.velocity = strikeVelocity;
                    power = 0;
                    ready = 0;
                }
            }
        }

    }
}
