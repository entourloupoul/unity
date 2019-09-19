using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.1f, 0.2f);    
    }

    // Update is called once per frame
    void Update()
    {
        float precision;

        transform.Translate(0,-speed,0);
        if (Input.GetKeyDown("a") && gameObject.name == "A")
        {
            precision = (-2 - gameObject.transform.position.y) * 100 / 5.5f;
            if (precision < 0)
                precision = -precision;
            Debug.Log("Precision: " + precision);
            CubeSpawner.alive -= 1;
            Destroy(gameObject);
        }
        if (Input.GetKeyDown("s") && gameObject.name == "S")
        {
            precision = (-2 - gameObject.transform.position.y) * 100 / 5.5f;
            if (precision < 0)
                precision = -precision;
            Debug.Log("Precision: " + precision);
            CubeSpawner.alive -= 1;
            Destroy(gameObject);
        }
        if (Input.GetKeyDown("d") && gameObject.name == "D")
        {
            precision = (-2 - gameObject.transform.position.y) * 100 / 5.5f;
            if (precision < 0)
                precision = -precision;
            Debug.Log("Precision: " + precision);
            CubeSpawner.alive -= 1;
            Destroy(gameObject);
        }
        if (gameObject.transform.position.y < -5)
        {
            CubeSpawner.alive -= 1;
            Destroy(gameObject);
        }
    }
}
