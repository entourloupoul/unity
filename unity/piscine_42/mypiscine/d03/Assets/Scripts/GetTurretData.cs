using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTurretData : MonoBehaviour
{
    public GameObject turret;
    private towerScript tower;
    private int cost;
    private float fireRate;
    private float range;
    private float damage;
    private Transform child;
    private GameObject childGO;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        tower = turret.GetComponent<towerScript>();
        cost = tower.energy;
        fireRate = tower.fireRate;
        range = tower.range;
        damage = tower.damage;

        child = gameObject.transform.GetChild(0);
        child = child.transform.GetChild(0);
        childGO = child.gameObject;
        text = childGO.GetComponent<Text>();
        text.text = cost.ToString();

        child = gameObject.transform.GetChild(1);
        child = child.transform.GetChild(0);
        childGO = child.gameObject;
        text = childGO.GetComponent<Text>();
        text.text = damage.ToString();

        child = gameObject.transform.GetChild(2);
        child = child.transform.GetChild(0);
        childGO = child.gameObject;
        text = childGO.GetComponent<Text>();
        text.text = range.ToString();

        child = gameObject.transform.GetChild(3);
        child = child.transform.GetChild(0);
        childGO = child.gameObject;
        text = childGO.GetComponent<Text>();
        text.text = fireRate.ToString();



    }

    // Update is called once per frame
    void Update()
    {

    }
}
