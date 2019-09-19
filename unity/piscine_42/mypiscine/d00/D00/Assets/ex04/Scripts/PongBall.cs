using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    private float posBeg;
    private float posEnd;
    public float yVelocity;
    public float xVelocity;
    private int sens;
    public Player player2;
    public Player player1;

    // Start is called before the first frame update
    void Start()
    {
        yVelocity = Random.Range(0.05f, 0.2f);
        xVelocity = 0.21f - yVelocity;
        sens = Random.Range(1, 4);
        if (sens == 2)
            yVelocity = -yVelocity;
        if (sens == 3)
            xVelocity = -xVelocity;
        if (sens == 4)
        {
            xVelocity = -xVelocity;
            yVelocity = -yVelocity;
        }
    }

    void reInit()
    {
        Vector3 pos;
        pos.x = 0;
        pos.y = 0;
        pos.z = 0;
        gameObject.transform.position = pos;
        yVelocity = Random.Range(0.05f, 0.1f);
        xVelocity = 0.21f - yVelocity;
        sens = Random.Range(1, 4);
        if (sens == 2)
            yVelocity = -yVelocity;
        if (sens == 3)
            xVelocity = -xVelocity;
        if (sens == 4)
        {
            xVelocity = -xVelocity;
            yVelocity = -yVelocity;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(xVelocity, yVelocity, 0);
        if (gameObject.transform.position.y > 4.47f && yVelocity > 0)
            yVelocity = -yVelocity;
        if (gameObject.transform.position.y < -4.47f && yVelocity < 0)
            yVelocity = -yVelocity;
        if (gameObject.transform.position.x > 9.73 && xVelocity > 0 && gameObject.transform.position.x < 9.8f
            && ((player2.transform.position.y - gameObject.transform.position.y > -1.34f)
                && (player2.transform.position.y - gameObject.transform.position.y < 1.34)))
            xVelocity = -xVelocity;
        if (gameObject.transform.position.x < -9.73 && xVelocity < 0 && gameObject.transform.position.x > -9.8f
            && ((player1.transform.position.y - gameObject.transform.position.y > -1.34f)
                && (player1.transform.position.y - gameObject.transform.position.y < 1.34)))
            xVelocity = -xVelocity;
        if (gameObject.transform.position.x > 11.1f)
        {
            player1.UpScore();
            reInit();
            Debug.Log("Player 1: " + player1.score + " | Player 2: " + player2.score);
        }
        if (gameObject.transform.position.x < -11.1f)
        {
            player2.UpScore();
            reInit();
            Debug.Log("Player 1: " + player1.score + " | Player 2: " + player2.score);
        }
    }
}
