using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class code_lab : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;
    int[] code = new int[3];
    public Text[] text = new Text[3];
    Animator anim;
    bool can_click = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
            canvas.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I))
        {
            canvas.SetActive(false);
        }

        text[0].text = code[0].ToString();
        text[1].text = code[1].ToString();
        text[2].text = code[2].ToString();
        if (code[0] == 3 && code[1] == 8 && code[2] == 4) 
        {
            anim.SetBool("open", true);
            canvas.SetActive(false);
            Destroy(this.gameObject, 2f);
        }
    }

    private void OnMouseDown()
    {
        if (can_click == true) 
        {
            canvas.SetActive(true);
        }
    }

    public void Click(int number) 
    {
        if (code[number-1] < 10)
        {
            code[number-1]++;
        }
        else if (code[number-1] == 10) 
        {
            code[number-1] = 0;
        }
    }
}
