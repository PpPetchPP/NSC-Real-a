using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject canvas;
    public Status_Player status;

    List<string> item = new List<string>();
    string[] name_items = new string[7] { "apple", "key1", "key2", "key3", "pic1", "pic2", "pic3" };
    public Sprite[] item_sprite = new Sprite[7];
    public Image[] inven_pic = new Image[4];
    public Button[] button = new Button[4];
    public bool can_use_pic;
    public bool can_use_key;
    public bool openInven = false;
    public string check_not_full;
    Door door_script;
    void Start()
    {
        status = GameObject.FindGameObjectWithTag("Player").GetComponent<Status_Player>();
        canvas = GameObject.FindGameObjectWithTag("Canvas_inven");
        canvas.SetActive(false);
        Check();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && openInven == false) 
        {
            canvas.SetActive(true);
            openInven = true;
        }
        else if ((Input.GetKeyDown(KeyCode.I) && openInven == true) || (Input.GetKeyDown(KeyCode.Escape) && openInven == true))
        {
            canvas.SetActive(false);
            openInven = false;
        }
    }

    void Check() 
    {
        Debug.Log(item.Count);
        for (int i = 0; i < item.Count; i++) 
        {
            if (item[i] != null) 
            {
                for (int x = 0; x < name_items.Length; x++)
                {
                    if (item[i] == name_items[x])
                    {
                        Debug.Log("Checked");
                        inven_pic[i].sprite = item_sprite[x];
                        button[i].enabled = true;
                        break;
                    }
                }
            }
        }
        if (item.Count == 0) 
        {
            inven_pic[0].sprite = null;
            inven_pic[1].sprite = null;
            inven_pic[2].sprite = null;
            inven_pic[3].sprite = null;
            button[0].enabled = false;
            button[1].enabled = false;
            button[2].enabled = false;
            button[3].enabled = false;
        }
        else if (item.Count == 1)
        {
            inven_pic[1].sprite = null;
            inven_pic[2].sprite = null;
            inven_pic[3].sprite = null;
            button[1].enabled = false;
            button[2].enabled = false;
            button[3].enabled = false;
        }
        else if (item.Count == 2)
        {
            inven_pic[2].sprite = null;
            inven_pic[3].sprite = null;
            button[2].enabled = false;
            button[3].enabled = false;
        }
        else if (item.Count == 3)
        {
            inven_pic[3].sprite = null;
            button[3].enabled = false;
        }
    }

    public string Add_item(string name_item) 
    {
        if (item.Count < 4)
        {
            item.Add(name_item);
            Check();
            check_not_full = "not full";
        }
        else 
        {
            check_not_full = "Inventory full";
        }
        return check_not_full;
    }

    public void Use_item1(string name_bot)
    {
        if (name_bot == "1")
        {
            Debug.Log("can use key : " + can_use_key);
            if (item[0] == name_items[0]) 
            {
                status.add_hunger(5);
                item.Remove(item[0]);
            }
            else if (item[0] == name_items[1] && can_use_key == true)
            {
                door_script.open(1);
                item.Remove(item[0]);
                Debug.Log("can use key succese");
            }
        }
        else if (name_bot == "2")
        {
            if (item[1] == name_items[0])
            {
                status.add_hunger(5);
                item.Remove(item[1]);
            }
            else if (item[1] == name_items[1] && can_use_key == true)
            {
                door_script.open(1);
                item.Remove(item[0]);
                Debug.Log("can use key succese");
            }
        }
        else if (name_bot == "3")
        {
            if (item[2] == name_items[0])
            {
                status.add_hunger(5);
                item.Remove(item[2]);
            }
            else if (item[2] == name_items[1] && can_use_key == true)
            {
                door_script.open(1);
                item.Remove(item[0]);
                Debug.Log("can use key succese");
            }
        }
        else if (name_bot == "4")
        {
            if (item[3] == name_items[0])
            {
                status.add_hunger(5);
                item.Remove(item[3]);
            }
            else if (item[3] == name_items[1] && can_use_key == true)
            {
                door_script.open(1);
                item.Remove(item[0]);
                Debug.Log("can use key succese");
            }
        }
        Check();
    }

    public void check_door(GameObject this_door) 
    {
        Debug.Log("Check");
        door_script = this_door.GetComponent<Door>();
    }

    public void click_icon() 
    {
        if (openInven == false) 
        {
            canvas.SetActive(true);
            openInven = true;
        }
        else if (openInven == true)
        {
            canvas.SetActive(false);
            openInven = false;
        }
    }
}
