using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    private Transform child;
    private GameObject childGO;
    private gameManager gameMan;
    public GameObject gM;
    public bool resume;

    // Start is called before the first frame update
    void Start()
    {
        resume = false;
        gameMan = gM.GetComponent<gameManager>();
        child = gameObject.transform.GetChild(0);
        childGO = child.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            childGO.SetActive(!childGO.activeSelf);
            gameMan.pause(childGO.activeSelf);
        }
        if (resume == true)
        {
            childGO.SetActive(false);
            gameMan.pause(false);
            resume = false;
        }
    }
}
