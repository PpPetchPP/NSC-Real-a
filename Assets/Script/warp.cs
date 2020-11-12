using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    public GameObject pos;
    public GameObject player;
    bool can_click = false;
    void Start()
    {
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
            player.transform.position = pos.transform.position;
        }
    }
}
