using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read_File : MonoBehaviour
{
    public GameObject[] pic_file = new GameObject[9];
    public GameObject menu;
    public bool open = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I) || Input.GetMouseButton(0)) && open == true) 
        {
            open = false;
            pic_file[0].SetActive(false);
            pic_file[1].SetActive(false);
            pic_file[2].SetActive(false);
            pic_file[3].SetActive(false);
            pic_file[4].SetActive(false);
            pic_file[5].SetActive(false);
            pic_file[6].SetActive(false);
            pic_file[7].SetActive(false);
            pic_file[8].SetActive(false);
        }
    }

    public void but_click(int number)
    {
        open = true;
        if (number == 1) 
        {
            pic_file[number - 1].SetActive(true);
            menu.SetActive(false);
        }
        else if (number == 2)
        {
            pic_file[number - 1].SetActive(true);
            menu.SetActive(false);
        }
        else if (number == 3)
        {
            pic_file[number - 1].SetActive(true);
            menu.SetActive(false);
        }
        else if (number == 4)
        {
            pic_file[number - 1].SetActive(true);
            menu.SetActive(false);
        }
        else if (number == 5)
        {
            pic_file[number - 1].SetActive(true);
            menu.SetActive(false);
        }
        else if (number == 6)
        {
            pic_file[number - 1].SetActive(true);
            menu.SetActive(false);
        }
        else if (number == 7)
        {
            pic_file[number - 1].SetActive(true);
            menu.SetActive(false);
        }
        else if (number == 8)
        {
            pic_file[number - 1].SetActive(true);
            menu.SetActive(false);
        }
        else if (number == 9)
        {
            pic_file[number - 1].SetActive(true);
            menu.SetActive(false);
        }
    }
}
