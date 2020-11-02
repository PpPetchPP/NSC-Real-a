using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Player : MonoBehaviour
{
    public Player player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Checklocalscale();
        if (player.lamp == true)
        {
            anim.SetBool("lamp", true);
        }
        else if (player.lamp == false) 
        {
            anim.SetBool("lamp", false);
        }
        if (player.moveH != 0 || player.moveV != 0)
        {
            anim.SetBool("walk", true);
            if (player.speed == 1)
            {
                anim.SetBool("run", true);               
            }
            if (player.speed == 0.5)
            {
                anim.SetBool("run", false);
            }
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }
    }

    private void Checklocalscale()
    {
        if (player.moveH < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (player.moveH > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
