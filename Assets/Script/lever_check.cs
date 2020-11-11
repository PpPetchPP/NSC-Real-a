using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_check : MonoBehaviour
{
    public GameObject key, pos;
    bool[] lever_number_bool = new bool[9] { false,false,true,true,false,true,true,true,false};
    int get = 0;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void check(int lever_number)
    {
        if (lever_number == 0 && lever_number_bool[0] == false) 
        {
            lever_number_bool[lever_number] = true;
        }
        else if (lever_number == 1 && lever_number_bool[1] == false)
        {
            lever_number_bool[lever_number] = true;
        }
        else if (lever_number == 2 && lever_number_bool[2] == true)
        {
            lever_number_bool[lever_number] = false;
        }
        else if (lever_number == 3 && lever_number_bool[3] == true)
        {
            lever_number_bool[lever_number] = false;
        }
        else if (lever_number == 4 && lever_number_bool[4] == false)
        {
            lever_number_bool[lever_number] = true;
        }
        else if (lever_number == 5 && lever_number_bool[5] == true)
        {
            lever_number_bool[lever_number] = false;
        }
        else if (lever_number == 6 && lever_number_bool[6] == true)
        {
            lever_number_bool[lever_number] = false;
        }
        else if (lever_number == 7 && lever_number_bool[7] == true)
        {
            lever_number_bool[lever_number] = false;
        }
        else if (lever_number == 8 && lever_number_bool[8] == false)
        {
            lever_number_bool[lever_number] = true;
        }
        else if (lever_number == 0 && lever_number_bool[0] == true) //swap
        {
            lever_number_bool[lever_number] = false;
        }
        else if (lever_number == 1 && lever_number_bool[1] == true)
        {
            lever_number_bool[lever_number] = false;
        }
        else if (lever_number == 2 && lever_number_bool[2] == false)
        {
            lever_number_bool[lever_number] = true;
        }
        else if (lever_number == 3 && lever_number_bool[3] == false)
        {
            lever_number_bool[lever_number] = true;
        }
        else if (lever_number == 4 && lever_number_bool[4] == true)
        {
            lever_number_bool[lever_number] = false;
        }
        else if (lever_number == 5 && lever_number_bool[5] == false)
        {
            lever_number_bool[lever_number] = true;
        }
        else if (lever_number == 6 && lever_number_bool[6] == false)
        {
            lever_number_bool[lever_number] = true;
        }
        else if (lever_number == 7 && lever_number_bool[7] == false)
        {
            lever_number_bool[lever_number] = true;
        }
        else if (lever_number == 8 && lever_number_bool[8] == true)
        {
            lever_number_bool[lever_number] = false;
        }

        if (lever_number_bool[0] == true &&
            lever_number_bool[1] == true &&
            lever_number_bool[2] == true &&
            lever_number_bool[3] == true &&
            lever_number_bool[4] == true &&
            lever_number_bool[5] == true &&
            lever_number_bool[6] == true &&
            lever_number_bool[7] == true &&
            lever_number_bool[8] == true &&
            get == 0
            ) 
        {
            Instantiate(key,pos.transform.position,pos.transform.rotation);
            get++;
        }
    }
}
