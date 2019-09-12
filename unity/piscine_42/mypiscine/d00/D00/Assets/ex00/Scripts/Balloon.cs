using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int breath;
    public int inspire;
    public int life;


    // Start is called before the first frame update
    void Start()
    {
        breath = 200;
        inspire = 20;
        life = 500;
    }

    void Death()
    {
        Destroy(gameObject);
        Debug.Log("Balloon lifetime: " + Mathf.RoundToInt(Time.time) + "s");
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 temp;

        if (Input.GetKeyDown("space") && breath > 0 && inspire == 20)
        {
            temp = gameObject.transform.localScale;
            temp.x += 0.05f;
            temp.y += 0.05f;
            gameObject.transform.localScale = temp;
            breath = breath - 20;
            life = 500;
        }
        else
        {
            if (breath <= 0)
                inspire = 0;
            if (breath < 200)
                breath = breath + 1;
            if (breath == 60)
                inspire = 20;
            life -= 1;
        }
        if (life == 0 || gameObject.transform.localScale.x >= 8)
            Death();

    }
}