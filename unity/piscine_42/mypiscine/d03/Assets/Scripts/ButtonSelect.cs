using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSelect : MonoBehaviour
{
    Outline outline;
    private bool over;

    // Start is called before the first frame update
    void Start()
    {
        over = false;
        outline = gameObject.GetComponent<Outline>();
    }

    // detect if mouse is over button
    void OnMouseEnter()
    {
        over = false;
        outline.enabled = true;
    }

    void OnMouseOver()
    {
        outline.enabled = true;
        over = true;
    }

    void OnMouseExit()
    {
        over = false;
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(SceneManager.sceneCount);
            //Debug.Log("click");
            if (over == true)
            {
                //Debug.Log("true");
                if (gameObject.name == "PlaySquare")
                {
                    SceneManager.LoadScene("ex01", LoadSceneMode.Single);
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("ex01"));
                }
                if (gameObject.name == "QuitSquare")
                {
                    Debug.Log("quit");
                    Application.Quit();
                }
            }
        }
    }
}
