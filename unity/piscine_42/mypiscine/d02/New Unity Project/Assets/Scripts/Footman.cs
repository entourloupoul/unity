using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman : MonoBehaviour
{
    public int moving;
    public int initDir;
    Vector3 dir;
    public Vector3 mouse;
    public Animator animator;
    public int selected;
    AudioSource[] selectedSound;
    public GameObject Audio;
    
    // Start is called before the first frame update
    void Start()
    {

        moving = 0;
        mouse = Vector3.zero;
        selectedSound = Audio.GetComponents<AudioSource>();
    }

    //move character
    void Move()
    {
        if ((transform.position = Vector3.MoveTowards(gameObject.transform.position, mouse, 0.05f)) == mouse)
        {
            moving = 0;
            selected = 0;
            animator.SetFloat("Speed", 0);
        } 
        //Debug.Log(animator.GetFloat("Speed"));
        //Debug.Log(animator.GetFloat("Dir"));


    }

   
    // Set parameters to chose good movement animation
    void SetMoveAnimation()
    {
        Quaternion rot = new Quaternion();

        animator.SetFloat("Speed", 1);
        animator.SetTrigger("StartMove");
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, dir);
        if (rotation.eulerAngles.z < 22.5f || rotation.eulerAngles.z >= 337.5f)
        {
            rot = rotation;
            animator.SetInteger("Dir", 1);
        }
        if ((rotation.eulerAngles.z < 67.5f && rotation.eulerAngles.z >= 22.5f)
            || (rotation.eulerAngles.z < 337.5f && rotation.eulerAngles.z >= 292.5f))
        {
            animator.SetInteger("Dir", 2);
            rot.SetFromToRotation(new Vector3(1, 1, 0), dir);
        }
        if ((rotation.eulerAngles.z < 112.5f && rotation.eulerAngles.z >= 67.5f)
            || (rotation.eulerAngles.z < 292.5 && rotation.eulerAngles.z >= 247.5))
        {
            animator.SetInteger("Dir", 3);
            rot.SetFromToRotation(new Vector3(1, 0, 0), dir);
        }
        if ((rotation.eulerAngles.z < 157.5f && rotation.eulerAngles.z >= 112.5f)
            || (rotation.eulerAngles.z < 247.5f && rotation.eulerAngles.z >= 202.5f))
        {
            animator.SetInteger("Dir", 4);
            rot.SetFromToRotation(new Vector3(1, -1, 0), dir);
        }
        if (rotation.eulerAngles.z < 202.5f && rotation.eulerAngles.z >= 157.5f)
        {
            animator.SetInteger("Dir", 5);
            rot.SetFromToRotation(new Vector3(0, -1, 0), dir);
        }
        gameObject.transform.rotation = rot;
    }


    // Sound when unit is selected
    void SelectedSound()
    {
        selectedSound[0].Play();
        Debug.Log("lok");
        selected = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected == 2)
            SelectedSound();
        if (moving != 0)
        {
            if (initDir == 1)
            {
                dir.x = mouse.x - gameObject.transform.position.x;
                dir.y = mouse.y - gameObject.transform.position.y;
                dir.z = 0;
                mouse.z = 0f;
                initDir = 0;
                SetMoveAnimation();
            }
            Move();
        }
    }

    // stop movement on colision
    void OnCollisionEnter2D(Collision2D col)
    {
        moving = 0;
        Debug.Log("collision");
        animator.SetFloat("Speed", 0);
    }

}
