using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_scene : MonoBehaviour
{
    public GameObject player;
    public GameObject pos;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            player.transform.position = pos.transform.position;
        }
    }
}
