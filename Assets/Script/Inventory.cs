using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas_file;
    public GameObject this_door;
    public Status_Player status;

    List<string> item = new List<string>();
    string[] name_items = new string[11] { "apple", "key1", "key2", "key3", "pic1", "pic2", "pic3","key4","book","tra","Lastbook" };
    string[] name_file = new string[9] { "001", "002", "003", "004", "005", "006", "007", "008", "009"};
    public Sprite[] item_sprite = new Sprite[12];
    public Image[] inven_pic = new Image[4];
    public Button[] button = new Button[4];
    public Button[] button_file = new Button[9];
    public bool can_use_pic;
    public bool can_use_key;
    public bool openInven = false;
    public string check_not_full;
    Door door_script;
    void Start()
    {
        status = GameObject.FindGameObjectWithTag("Player").GetComponent<Status_Player>();
        canvas = GameObject.FindGameObjectWithTag("Canvas_inven");
        canvas_file.SetActive(false);
        canvas.SetActive(false);
        Check();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && openInven == false) 
        {
            canvas.SetActive(true);
            openInven = true;
            canvas_file.SetActive(false);
        }
        else if ((Input.GetKeyDown(KeyCode.I) && openInven == true) || (Input.GetKeyDown(KeyCode.Escape)/* && openInven == true*/))
        {
            canvas.SetActive(false);
            openInven = false;
            canvas_file.SetActive(false);
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

    public string Add_item(string name_item,string type) 
    {
        if (type == "item")
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
        else if (type == "file") 
        {
            Debug.Log("Run");
            for (int i = 0; i<9;i++) 
            {
                if (name_item == name_file[i]) 
                {
                    button_file[int.Parse(name_file[i])-1].image.sprite = item_sprite[item_sprite.Length-1];
                    button_file[int.Parse(name_file[i]) - 1].interactable = true;
                    break;
                }
            }
        }
        Debug.Log(name_item);
        return name_item;
    }

    public void Use_item1(string name_bot)
    {
        if (name_bot == "1")
        {
            use_button(0);
        }
        else if (name_bot == "2")
        {
            use_button(1);
        }
        else if (name_bot == "3")
        {
            use_button(2);
        }
        else if (name_bot == "4")
        {
            use_button(3);
        }
        Check();
    }

    void use_button(int slot) 
    {
        if (item[slot] == name_items[0])
        {
            status.add_hunger(5);
            item.Remove(item[slot]);
        }
        else if ((item[slot] == name_items[1]) && can_use_key == true)
        {
            if (door_script.use_key == true)
            {
                item.Remove(item[slot]);
                door_script.open2(1);
            }
            else door_script.open(1);
        }
        else if ((item[slot] == name_items[2]) && can_use_key == true)
        {
            if (door_script.use_key == true)
            {
                item.Remove(item[slot]);
                door_script.open2(2);
            }
            else door_script.open(2);
        }
        else if ((item[slot] == name_items[3]) && can_use_key == true)
        {
            if (door_script.use_key == true)
            {
                item.Remove(item[slot]);
                door_script.open2(3);
            }
            else door_script.open(3);
        }
        else if ((item[slot] == name_items[4]) && this_door.gameObject.tag == "pic")
        {
            door_script.check_pic(1);
            item.Remove(item[slot]);
        }
        else if ((item[slot] == name_items[5]) && this_door.gameObject.tag == "pic")
        {
            door_script.check_pic(2);
            item.Remove(item[slot]);
        }
        else if ((item[slot] == name_items[6]) && this_door.gameObject.tag == "pic")
        {
            door_script.check_pic(3);
            item.Remove(item[slot]);
        }
        else if ((item[slot] == name_items[7]) && this_door.gameObject.tag == "door2")
        {
            door_script.open(4);
            item.Remove(item[slot]);
        }
        else if ((item[slot] == name_items[8]) && this_door.gameObject.tag == "hide_wall")
        {
            door_script.check_book();
            item.Remove(item[slot]);
        }
        else if ((item[slot] == name_items[9]) && this_door.gameObject.tag == "door3")
        {
            door_script.open(5);
        }
        else if ((item[slot] == name_items[10]) && (this_door.gameObject.tag == "NPC" || this_door.gameObject.tag == "door4"))
        {
            if (this_door.gameObject.tag == "NPC") 
            {
                door_script.dust();
                item.Remove(item[slot]);
            }
            else if (this_door.gameObject.tag == "door4")
            {
                door_script.open(0);
            }
        }
    }
    public void check_door(GameObject this_door2) 
    {
        door_script = this_door2.GetComponent<Door>();
        this_door = this_door2;
    }

    public void click_icon() 
    {
        if (openInven == false) 
        {
            canvas.SetActive(true);
            openInven = true;
            canvas_file.SetActive(false);
        }
        else if (openInven == true)
        {
            canvas.SetActive(false);
            openInven = false;
            canvas_file.SetActive(false);
        }
    }

    public void open_file()
    {
        if (openInven == true)
        {
            canvas.SetActive(false);
            openInven = false;
            canvas_file.SetActive(true);
        }
    }
}
