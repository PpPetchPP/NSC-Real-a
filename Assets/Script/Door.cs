using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    public Inventory inven;
    [SerializeField] public string name_obj;
    bool can_click = false;
    [SerializeField] int Door_number;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        inven = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void open(int key_number)
    {
        if (can_click == true && Door_number == key_number)
        {
            anim.SetBool("open",can_click);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inven.can_use_key = true;
            can_click = true;
            inven.check_door(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inven.can_use_key = false;
            can_click = false;
        }
    }
}
