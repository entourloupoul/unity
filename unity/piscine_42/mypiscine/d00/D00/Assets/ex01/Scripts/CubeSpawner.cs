using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeSpawner : MonoBehaviour
{
    private int[] nCube = new int[3];
    public GameObject prefab;
    private Sprite[] sprite = new Sprite[3];
    private float delay;
    private float[] gap = new float[3];
    private float time;
    public static int alive;

    // Start is called before the first frame update
    void Start()
    {
        delay = 3f;
        alive = 0;
        InitValue();
        sprite[0] = Resources.Load<Sprite>("Sprites/a");
        sprite[1] = Resources.Load<Sprite>("Sprites/s");
        sprite[2] = Resources.Load<Sprite>("Sprites/d");
        if (sprite[0] == null || sprite[1] == null || sprite[2] == null)
            Debug.Log("fail load sprites");
    }

    void InitValue()
    {
        gap[0] = Random.Range(0f, 2f);
        gap[1] = Random.Range(0f, 2f);
        gap[2] = Random.Range(0f, 2f);
        nCube[0] = 0;
        nCube[1] = 0;
        nCube[2] = 0;
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        SpriteRenderer spriteR;
        GameObject newCube;
        Vector3 pos;

        time = time + Time.deltaTime;
        if (time >= gap[0] && nCube[0] == 0)
        {
            pos.x = -2.81f;
            pos.y = 3.5f;
            pos.z = -5f;
            newCube = Instantiate(prefab, pos, Quaternion.identity);
            newCube.name = "A";
            newCube.SetActive(true);
            spriteR = newCube.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprite[0];
            nCube[0] = 1;
            alive += 1;
        }
        if (time >= gap[1] && nCube[1] == 0)
        {
            pos.x = 0f;
            pos.y = 3.5f;
            pos.z = -5f;
            newCube = Instantiate(prefab, pos, Quaternion.identity);
            newCube.name = "S";
            newCube.SetActive(true);
            spriteR = newCube.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprite[1];
            alive += 1;
            nCube[1] = 1;
        }
        if (time >= gap[2] && nCube[2] == 0)
        {
            pos.x = 2.81f;
            pos.y = 3.5f;
            pos.z = -5f;
            newCube = Instantiate(prefab, pos, Quaternion.identity);
            newCube.name = "D"; 
            newCube.SetActive(true);
            spriteR = newCube.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprite[2];
            alive += 1;
            nCube[2] = 1;
        }
        if (nCube[0] == 1 && nCube[1] == 1 && nCube[2] == 1 && time >= delay && alive == 0)
            InitValue();
    }
}