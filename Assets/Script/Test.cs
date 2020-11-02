using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] public string name_obj;
    public Inventory inven;
    bool can_click = false;
    void Start()
    {
        inven = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (can_click == true) 
        {
            if (inven.Add_item(name_obj) == "not full") 
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            can_click = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            can_click = false;
        }
    }
}
