using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;
    [SerializeField] bool can_click = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
    }
    private void OnMouseDown()
    {
        if (can_click == true)
        {
            canvas.SetActive(true);
        }
    }
}
