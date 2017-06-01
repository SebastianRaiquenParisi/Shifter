using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour {
    //Tengo que pasar este codigo al playershoooting
    private Animator anim;
    bool attacking;
    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (Time.timeScale != 0)
        {
            if (Input.GetAxisRaw("Horizontal") < -0.5 || Input.GetAxisRaw("Horizontal") > 0.5 || Input.GetAxisRaw("Vertical") < -0.5 || Input.GetAxisRaw("Vertical") > 0.5)
            {
                anim.SetBool("Moving", true);
            }
            else
            {
                anim.SetBool("Moving", false);
            }
            if (Input.GetButtonDown("Fire1"))
            {
                attacking = true;
            }
            if (attacking)
            {
                anim.SetTrigger("Attack");
            }
            attacking = false;
        }
    }
}
