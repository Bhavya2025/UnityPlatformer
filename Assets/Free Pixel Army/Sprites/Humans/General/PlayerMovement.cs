using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float walkSpeed;
    

    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Transform trans;
    [SerializeField] private Transform bottomRight;
    [SerializeField] private Transform bottomLeft;
    [SerializeField] private LayerMask ground;

    //fireball
    private float startTime;
    private float elaspedTime;
    [SerializeField] private float cooldown;


    //private floa targetDir;

    Object refe;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
        
        refe = Resources.Load("FireBall");
       
        startTime = Time.time;
        elaspedTime = cooldown + 1;

    }
    bool OnEdge() 
    {
        
        bool collisionRight = Physics2D.Linecast(new Vector2(bottomRight.position.x, trans.position.y), bottomRight.position, ground);
        bool collisionLeft = Physics2D.Linecast(new Vector2(bottomLeft.position.x, trans.position.y), bottomLeft.position, ground);
        Debug.Log(collisionRight);
        Debug.Log(collisionLeft);
        if (collisionLeft | collisionRight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    // Update is called once per frame
   
  void FixedUpdate()
    {

        
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        

        if (hMove > 0) 
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
        else if(hMove < 0) 
        {
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }
        else 
        {
            rb.velocity = (new Vector2(0, rb.velocity.y))*Time.deltaTime;
        }
        
        if (Input.GetButton("Fire1"))
        {
            elaspedTime = Time.time - startTime;
            
            if (elaspedTime > cooldown)
            {
                startTime = Time.time;
                GameObject fireballLoad = (GameObject)Instantiate(refe);
                fireballLoad.transform.position = new Vector2(trans.position.x, trans.position.y);
           }
        }



        if (vMove > 0)
        {
            Debug.Log("Input jump");
            if (OnEdge())
            {
                rb.velocity = Vector2.up * jumpSpeed;
                Debug.DrawRay(bottomLeft.position, Vector2.down, Color.red);
                Debug.DrawRay(bottomRight.position, Vector2.down, Color.red);
            }
            else
            {
                Debug.DrawRay(bottomLeft.position, Vector2.down, Color.green);
                Debug.DrawRay(bottomRight.position, Vector2.down , Color.green);
            }
        }
    }
    void Update()
    {
       
        Debug.DrawLine(trans.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));       
    }










}
