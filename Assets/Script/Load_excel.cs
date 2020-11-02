using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_excel : MonoBehaviour
{
    public List<NPC_Script_talk> npc_sc_talk = new List<NPC_Script_talk>();
    // Start is called before the first frame update
    void Start()
    {
        TextAsset npc_script = Resources.Load<TextAsset>("npc_script");
        string[] data = npc_script.text.Split(new char[] { '\n' } );
        Debug.Log(data.Length);
        for (int i = 1;i < data.Length - 1 ;i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            if (row[1] != "") 
            {
                NPC_Script_talk npc_sc = new NPC_Script_talk();
                npc_sc.name = row[0];
                int.TryParse(row[1], out npc_sc.scene);
                npc_sc.script1 = row[2];
                npc_sc.script2 = row[3];
                npc_sc.script3 = row[4];

                npc_sc_talk.Add(npc_sc);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
