using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public end loser;
    Transform trans_target;
    int i_waypointIndex = 0;
    float f_enemySpeed = 0.75f;
    public Waypoint waypoint;
    bool found_player = false;

    public Transform target;
    public Animator anim;
    public Transform Player;
    // Start is called before the first frame update
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        loser = GameObject.FindGameObjectWithTag("END").GetComponent<end>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        trans_target = waypoint.point[0];
        target = trans_target;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * f_enemySpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, trans_target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
        if (target.position.x < this.transform.position.x) 
        {
            this.transform.localScale = new Vector2(-1, 1);
        }
        else if (target.position.x > this.transform.position.x)
        {
            this.transform.localScale = new Vector2(1, 1);
        }

        if (found_player == false)
        {
            target = trans_target;
        }
        else if (found_player == true) 
        {
            target = Player;
        }
        //if (Vector3.Distance(this.transform.position, target.transform.position) >= 3 && found_player == true)
        //{
        //    found_player = false;
        //}
    }

    void GetNextWayPoint()
    {
        if (i_waypointIndex >= waypoint.point.Length - 1) //Check if there are any WayPoint left to go, if not Destroy themself
        {
            i_waypointIndex = -1;
            return;
        }
        i_waypointIndex++;
        trans_target = waypoint.point[i_waypointIndex];

        if (this.transform.position.x > waypoint.point[i_waypointIndex].position.x)
        {
            this.transform.localScale = new Vector2(-1, 1);
        }
        else if (this.transform.position.x < waypoint.point[i_waypointIndex].position.x)
        {
            this.transform.localScale = new Vector2(1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            found_player = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            loser.lose();
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        found_player = false;
    //    }
    //}
}
