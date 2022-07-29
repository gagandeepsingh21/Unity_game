using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            anim.Play("walk");
        }
        if (Input.GetKey("r"))
        {
            anim.Play("sprint");
        }
        if (Input.GetKey("j"))
        {
            anim.Play("jump");
        }
        if (Input.GetKey("g"))
        {
            anim.Play("gathering");
        }
    }
}
