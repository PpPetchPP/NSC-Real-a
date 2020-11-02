using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_light : MonoBehaviour
{
    public GameObject player;
    public GameObject light;
    public Animator anim;
    public Player player_script;
    bool can_click = false;
    bool open_light = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_script = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(this.transform.position, player.transform.position);
        if (dis < 0.3f)
        {
            can_click = true;
        }
        else if (dis >= 0.3f)
        {
            can_click = false;
        }

        click();
    }

    void click() 
    {
        if (Input.GetKeyDown(KeyCode.F) && can_click == true)
        {
            if (open_light == true) 
            {
                light.SetActive(false);
                open_light = false;
                anim.SetTrigger("onoff");
            }
            else if (open_light == false)
            {
                light.SetActive(true);
                open_light = true;
                anim.SetTrigger("onoff");
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && can_click == true) 
        {
            player_script.Use_lamp();
            Destroy(this.gameObject);
        }
    }
}
