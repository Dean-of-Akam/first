using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isup = true;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
    }

    // Update is called once per frame
    void Update()
    {
        moveMent();
    }
    void moveMent(){
        
            if(isup)
            {
                rb.velocity = new Vector2(rb.velocity.x,speed);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x,-speed);
            }
        
        
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Top"){
            isup = false;
        }else if(other.tag == "Bottom"){
            isup = true;
        }

    }
}
