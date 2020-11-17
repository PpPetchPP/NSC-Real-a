using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public end loser;
    public Animator anim;
    public Inventory inven;
    public GameObject pic1, pic2, pic3,key,pos;
    protected bool can_click = false;
    protected bool key1,key2,key3,pic1_bool,pic2_bool,pic3_bool = false;
    [SerializeField] public bool use_key = false;
    [SerializeField] protected int Door_number;
    protected void Start()
    {
        anim = this.GetComponent<Animator>();
        inven = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    public void open(int key_number)
    {
        if (can_click == true && Door_number == key_number)
        {
            anim.SetTrigger("open");
            Destroy(this.gameObject, 2f);
        }
    }
    public void open2(int key_number)
    {
        if (can_click == true)
        {
            if (key_number == 1) 
            {
                key1 = true;
            }
            else if (key_number == 2)
            {
                key2 = true;
            }
            else if (key_number == 3)
            {
                key3 = true;
            }
            if (key1 == true && key2 == true && key3 == true ) 
            {
                anim.SetTrigger("open");
                Destroy(this.gameObject, 2f);
            }
        }
    }
    public void check_pic(int pic_number) 
    {
        if (can_click == true)
        {
            if (pic_number == 1) 
            {
                pic1.gameObject.SetActive(true);
                pic1_bool = true;
            }
            else if (pic_number == 2)
            {
                pic2.gameObject.SetActive(true);
                pic2_bool = true;
            }
            else if (pic_number == 3)
            {
                pic3.gameObject.SetActive(true);
                pic3_bool = true;
            }
            if (pic1_bool == true && pic2_bool == true && pic3_bool == true ) 
            {
                Instantiate(key, pos.transform.position, pos.transform.rotation);
            }
        }
    }

    public void check_book()
    {
        if (can_click == true)
        {
            anim.SetBool("open",true);
            Destroy(this.gameObject, 2f);
        }
    }

    public void dust() 
    {
        loser.lose();
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inven.can_use_key = true;
            can_click = true;
            inven.check_door(this.gameObject);
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inven.can_use_key = false;
            inven.this_door = null;
            can_click = false;
        }
    }
}
