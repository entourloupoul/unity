using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RBScript : MonoBehaviour
{
    public GameObject escMenu;
    private EscapeMenu escapeScript;
    public bool over;
    private Color initColor;
    private Color secondColor;
    private SpriteRenderer spriteRend;
    public GameObject gbTextGO;
    public GameObject rbTextGO;
    private Text rbText;
    private Text gbText;
    public GameObject textQuit;


    // Start is called before the first frame update
    void Start()
    {
        escapeScript = escMenu.GetComponent<EscapeMenu>();
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        initColor = spriteRend.color;
        secondColor = Color.red;
        over = false;
        rbText = rbTextGO.GetComponent<Text>();
        gbText = gbTextGO.GetComponent<Text>();

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
            gbText.text = "YEEESSS";
            rbText.text = "NOOOOOO";
            textQuit.SetActive(true);
        }
    }
}
