using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public Status_Player status;

    public GameObject pos,lamp_obj;

    public bool lamp,check_lamp = false;
    public float moveH, moveV;
    [SerializeField] public float speed = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * speed;
        moveV = Input.GetAxisRaw("Vertical") * speed;

        if (Input.GetKey(KeyCode.LeftShift) && status.stamina > 0) 
        {
            speed = 1;
            status.use_stamina();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || status.stamina <= 0)
        {
            speed = 0.5f;
        }
        if (!Input.GetKey(KeyCode.LeftShift) && status.stamina <= 10)
        {
            status.regen_stamina();
        }
        if (Input.GetKeyDown(KeyCode.E) && lamp == true && check_lamp == true)
        {
            lamp = false;
            StartCoroutine(delay(0.5f));
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);
    }

    public void Use_lamp() 
    {
        if (lamp == false)
        {
            lamp = true;
            Invoke("delay_lamp", 0.5f);
        }
    }
    private void delay_lamp() 
    {
        check_lamp = true;
    }

    IEnumerator delay(float sec) 
    {
        yield return new WaitForSeconds(sec);
        Instantiate(lamp_obj, pos.transform.position, pos.transform.rotation);
    }
}
