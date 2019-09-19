using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerInfo : MonoBehaviour
{
    public GameObject gM;
    private gameManager gameMan;
    private GameObject childGO;
    private Transform child;
    private Text energyText;
    private Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        gameMan = gM.GetComponent<gameManager>();
        child = gameObject.transform.GetChild(1);
        child = child.transform.GetChild(0);
        childGO = child.gameObject;
        energyText = childGO.GetComponent<Text>();

        child = gameObject.transform.GetChild(0);
        child = child.transform.GetChild(0);
        childGO = child.gameObject;
        lifeText = childGO.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        energyText.text = gameMan.playerEnergy.ToString();
        lifeText.text = gameMan.playerHp.ToString();;
    }
}
