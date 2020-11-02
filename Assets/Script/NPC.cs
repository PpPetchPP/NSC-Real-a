using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Load_excel load_sc;
    public GameObject player;
    public GameObject panel;
    [SerializeField] public string name_charactor = "npc";
    [SerializeField] public int scene_script = 1;
    public Text name, script_text;
    List<string> script = new List<string>();
    bool can_click,now_talk = false;
    int next_script = 0;
    int scene;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        panel = GameObject.FindGameObjectWithTag("Panel");
        load_sc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Load_excel>();
        name = GameObject.FindGameObjectWithTag("Npc_Name").GetComponent<Text>();
        script_text = GameObject.FindGameObjectWithTag("Npc_script").GetComponent<Text>();
    }
    void Start()
    {
        panel.SetActive(false);
        name.text = "";
        script_text.text = "";
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
            panel.SetActive(false);
            now_talk = false;
            name.text = "";
            script_text.text = "";
            next_script = 0;
            script.Clear();
        }


        if (Input.GetMouseButtonDown(0) && now_talk == true)
        {           
            if (next_script < load_sc.npc_sc_talk.Count)
            {
                script_text.text = script[next_script];
                next_script++;
                Debug.Log("next_script = "+next_script);
            }
            else
            {
                Debug.Log("Runnnn");
                panel.SetActive(false);
                now_talk = false;
                name.text = "";
                script_text.text = "";
                next_script = 0;
                script.Clear();
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, LayerMask.NameToLayer("Obj"));
            if (hit.collider != null)
            {
                Debug.Log("Target tag : " + hit.collider.tag);
                if (can_click == true && hit.collider.tag == "NPC")
                {
                    if (player.transform.position.x <= this.transform.position.x)
                    {
                        this.transform.localScale = new Vector2(-1, 1);
                        talk();
                    }
                    else if (player.transform.position.x >= this.transform.position.x)
                    {
                        this.transform.localScale = new Vector2(1, 1);
                        talk();
                    }
                }
            }
        }
    }

    void talk() 
    {
        now_talk = true;
        panel.SetActive(true);
        for (int i = 0; i < load_sc.npc_sc_talk.Count;i++) 
        {
            if (load_sc.npc_sc_talk[i].name == name_charactor)
            {
                if (load_sc.npc_sc_talk[i].scene == scene_script ) 
                {
                    scene = i;
                    name.text = load_sc.npc_sc_talk[i].name;
                    script_text.text = load_sc.npc_sc_talk[i].script1;
                    script.Add(load_sc.npc_sc_talk[i].script2);
                    script.Add(load_sc.npc_sc_talk[i].script3);
                }
            }
        }
    }
}
