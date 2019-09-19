using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretSelect : MonoBehaviour
{
    public GameObject newTurret;
    private towerScript towerSc;
    private OutlineScript outline;
    private bool over;
    private Vector3 initialPos;
    private Vector3 mousePos;
    private int moving;
    private bool selected;
    public GameObject gameMan;
    private gameManager gM;
    private int cost;
    private Transform child;
    private GameObject childGO;
    private bool selectable;
    private SpriteRenderer spriteRend;


    // Start is called before the first frame update
    void Start()
    {
        gM = gameMan.GetComponent<gameManager>();
        towerSc = newTurret.GetComponent<towerScript>();
        selected = false;
        over = false;
        selectable = true;
        moving = 0;
        initialPos = gameObject.transform.position;
        outline = gameObject.GetComponent<OutlineScript>();
        cost = towerSc.energy;
        child = gameObject.transform.GetChild(0);
        childGO = child.gameObject;
        spriteRend = childGO.GetComponent<SpriteRenderer>();
    }

    // 3 functions ro now if the mouse is over the UI componenent
    void OnMouseEnter()
    {
        over = true;
        if (selected)
            return;
        outline.color = Color.yellow;
        over = true;
        outline.enabled = true;
    }

    void OnMouseOver()
    {
        over = true;
        if (selected)
            return;
        outline.color = Color.yellow;
        outline.enabled = true;
        over = true;
    }

    void OnMouseExit()
    {
        over = false;
        if (selected)
            return;
        outline.color = Color.clear;
        outline.enabled = false;
    }

    // Verification de l'emplacement et creation de la tour
    private void InstantiateTurret()
    {
        Debug.Log("coucou");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.tag == "empty")
        {
            Debug.Log("instantiate");
            GameObject obj = Instantiate(newTurret, hit.collider.transform.position, Quaternion.identity);
            obj.SetActive(true);
            hit.collider.transform.tag = "tower";
            gM.playerEnergy -= cost;
        }
    }

    // move sprite with mouse
    void Move()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = Vector3.MoveTowards(gameObject.transform.position, mousePos, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gM.playerEnergy < cost)
        {
            spriteRend.color = Color.red;
            selectable = false;
        }
        if (gM.playerEnergy >= cost && selectable == false)
        {
            selectable = true;
            spriteRend.color = Color.white;
        }
        if (Input.GetMouseButtonDown(0) && selectable == true)
        {
            if (over == true)
            {
                selected = true;
                moving = 1;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            moving = 0;
            outline.color = Color.clear;
            outline.enabled = false;
            if (gameObject.transform.position != initialPos)
                gameObject.transform.position = initialPos;
            if (selected == true)
                InstantiateTurret();
            selected = false;
        }
        if (moving == 1)
            Move();
    }
}
