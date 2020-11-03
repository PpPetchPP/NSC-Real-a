using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_hide : MonoBehaviour
{
    [SerializeField] private float hunger_value = 1f;
    public Rigidbody2D Player_rb;
    public Player player;
    public SpriteRenderer playerSprit;
    public CapsuleCollider2D capPlayer;
    public Status_Player status;
    public Animator anim;
    bool can_click = false;
    bool hide = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Player_rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerSprit = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        capPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        status = GameObject.FindGameObjectWithTag("Player").GetComponent<Status_Player>();
        anim = this.gameObject.GetComponent<Animator>();
    }

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

        if (hide == true && status.stamina <= 10f)
        {
            status.regen_stamina();
        }

        if (Input.GetMouseButtonDown(0) && can_click == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, LayerMask.NameToLayer("Obj"));
            if (hit.collider != null)
            {
                Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
                if (can_click == true && hide == false && player.lamp == false)
                {
                    anim.SetTrigger("open");
                    Invoke("get_in", 0.5f);
                }
                else if (can_click == true && hide == true)
                {
                    anim.SetTrigger("open");
                    Invoke("get_out", 0.5f);
                }
            }
        }
    }

    void get_in() 
    {
        Debug.Log("hide");
        Player_rb.isKinematic = true;
        Player_rb.velocity = Vector2.zero;
        player.enabled = false;
        playerSprit.enabled = false;
        capPlayer.enabled = false;
        hide = true;
    }

    void get_out()
    {
        Debug.Log("out");
        player.speed = 0.5f;
        Player_rb.isKinematic = false;
        player.enabled = true;
        playerSprit.enabled = true;
        capPlayer.enabled = true;
        hide = false;
    }
}
