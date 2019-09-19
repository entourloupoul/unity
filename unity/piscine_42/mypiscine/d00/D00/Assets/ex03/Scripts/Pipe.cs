using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float velocity;
    private int upScore;
    public GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        velocity = -0.1f;
        upScore = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;

        if (Bird.alive == 1)
        {
            transform.Translate(velocity, 0, 0);
            velocity -= 0.0001f;
        }
        if (gameObject.transform.position.x <= -5.2)
        {
            pos = new Vector3(5, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = pos;
            upScore = 1;
        }
        if (gameObject.transform.position.x <= -1.49 && Bird.alive == 1 && upScore == 1)
        {
            Bird.score += 5;
            upScore = 0;
        }
        if (gameObject.transform.position.x < 1.2f && gameObject.transform.position.x > -1.41f
            && (bird.transform.position.y < -0.55f || bird.transform.position.y > 2.41f) && Bird.alive == 1)
        {
            Bird.alive = 0;
        }
    }
}
