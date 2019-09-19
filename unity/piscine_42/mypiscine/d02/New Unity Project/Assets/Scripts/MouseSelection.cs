using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour
{
    List<GameObject> selected;

    // Start is called before the first frame update
    void Start()
    {
        selected = new List<GameObject>();
    }

    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selected.Clear();
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == null || hit.collider.tag != "Player")
            {
                if (selected.Count != 0)
                {
                    foreach (GameObject elt in selected)
                    {
                        Footman player;
                        player = elt.GetComponent<Footman>();
                        player.mouse = cam.ScreenToWorldPoint(Input.mousePosition);
                        Debug.Log("mouse: " + cam.ScreenToWorldPoint(Input.mousePosition));
                        player.moving = 1;
                        player.initDir = 1;
                    }
                }
                else
                    selected.Clear();
            }
            if (hit.collider != null && hit.collider.tag == "Player")
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    if (selected.Contains(hit.transform.gameObject) == false)
                    {
                        selected.Add(hit.transform.gameObject);
                        Footman player;
                        player = hit.transform.gameObject.GetComponent<Footman>();
                        player.selected = 2;
                    }
                }
                else
                {
                    selected.Clear();
                    selected.Add(hit.transform.gameObject);
                    Footman player;
                    player = hit.transform.gameObject.GetComponent<Footman>();
                    player.selected = 2;
                }

            }
            foreach (GameObject elts in selected)
            {
                //Debug.Log(elts.name);
            }
        }
    }
}
