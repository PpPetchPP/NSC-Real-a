using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] public string name_obj;
    [SerializeField] public string type;
    public GameObject player;
    public Inventory inven;
    bool can_click = false;
    void Start()
    {
        inven = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        float dis = Vector2.Distance(this.transform.position, player.transform.position);
        if (dis < 1f)
        {
            can_click = true;
        }
        else if (dis >= 1f && can_click == true)
        {
            can_click = false;
        }
    }

    private void OnMouseDown()
    {
        if (can_click == true)
        {
            if (type == "item" && inven.Add_item(name_obj, type) == "not full")
            {
                Destroy(this.gameObject);
            }
            else if (inven.Add_item(name_obj, type) != "" && type == "file")
            {
                Destroy(this.gameObject);
            }
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        can_click = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        can_click = false;
    //    }
    //}
}
