using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_click : MonoBehaviour
{
    public GameObject player;
    public lever_check lever;
    public Animator anim;
    [SerializeField] int lever_nuber;
    bool can_click = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lever = GameObject.FindGameObjectWithTag("Lever_con").GetComponent<lever_check>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
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
            lever.check(lever_nuber);
            anim.SetTrigger("open");
        }
    }
}
