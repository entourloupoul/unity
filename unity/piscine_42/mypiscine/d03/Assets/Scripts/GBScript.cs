using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBScript : MonoBehaviour
{
    public GameObject escMenu;
    private EscapeMenu escapeScript;
    public bool over;
    private Color initColor;
    private Color secondColor;
    private SpriteRenderer spriteRend;


    // Start is called before the first frame update
    void Start()
    {
        escapeScript = escMenu.GetComponent<EscapeMenu>();
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        initColor = spriteRend.color;
        secondColor = Color.green;
        over = false;
    }

    void OnMouseOver()
    {
        over = true;
    }

    void OnMouseExit()
    {
        over = false;
    }


    void OnDisable()
    {
        over = false;
        spriteRend.color = initColor;

    }

    // Update is called once per frame
    void Update()
    {
        if (over == true && spriteRend.color != secondColor)
        {
            spriteRend.color = secondColor;
        }
        if (over == false && spriteRend.color != initColor)
        {
            spriteRend.color = initColor;
        }
        if (over == true && Input.GetMouseButtonDown(0))
        {
            escapeScript.resume = true;

        }
    }
}
