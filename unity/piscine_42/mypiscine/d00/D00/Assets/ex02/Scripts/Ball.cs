using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static float velocity;
    public static int power;
    public static int direction;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 0f;
        direction = 1;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (velocity != 0)
        {
            transform.Translate(0, velocity, 0);
            if (velocity < 0)
                velocity += 0.01f;
            else
                velocity -= 0.01f;
            if ((direction == -1 && velocity > 0) || (direction == 1 && velocity < 0))
                velocity = 0;
            if (gameObject.transform.position.y > 8.59 && direction == 1)
            {
                direction = -1;
                velocity = -velocity;
            }
            if (gameObject.transform.position.y < -8.59 && direction == -1)
            {
                direction = 1;
                velocity = -velocity;
            }
            if (Mathf.Clamp(gameObject.transform.position.y, 5.95f, 7.1f) == gameObject.transform.position.y
                && ((velocity >= 0 && velocity < 0.3) || (velocity <= 0 && velocity > -0.3)))
            {
                Club.score -= 5;
                Debug.Log("Score: " + Club.score);
                Destroy(gameObject);
            }
        }
        
    }
}
