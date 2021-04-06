using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShoot : MonoBehaviour
{
    [SerializeField] private float targetTime;
    [SerializeField] Rigidbody2D rb;
    private float startTime;
    //[SerializeField] private float throwForce;
    // [SerializeField] private GameObject player;
    [SerializeField] private Transform player;
    [SerializeField] private float BulletSpeed;
    [SerializeField] private LayerMask LM;
    [SerializeField] private float cooldown;

    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rb.velocity = (new Vector2(mPos.x - player.position.x, mPos.y - player.position.y).normalized) * BulletSpeed ;

        rb = GetComponent<Rigidbody2D>();

       // rb.velocity = new Vector2();
        
       // player = (GameObject)GameObject.FindGameObjectsWithTag("Player");
       
    }
     bool Timer() 
    {
        float timeElapsed = Time.time - startTime;
        if (timeElapsed > targetTime)
        {
            return true;
        }
        else
        {
            return false;
        }
      
    }

    // Update is called once per frame
    void Update()
  {
        
        
        if (GetComponent<CircleCollider2D>().IsTouchingLayers(LM) ||Timer())
        {
            GameObject.Destroy(gameObject);        
            




        }
      

  }
}



