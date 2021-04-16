using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogs : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform leftPoint,rightPoint;
    private bool faceLeft = true;
    public float speed,jumpForce;
    private Animator animator;
    public bool stand;
    public GameObject Enemy;
    public LayerMask ground;
    private Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveMent();
    }
    void moveMent(){
        if(!Enemy.GetComponent<Enemy>().isDead &&collider.IsTouchingLayers(ground)){
            if(faceLeft){
            rb.velocity = new Vector2(-speed,jumpForce);
            animator.SetBool("idle",false);
            animator.SetBool("jumping",true);
        }else{
            rb.velocity = new Vector2(speed,jumpForce);
            animator.SetBool("idle",false);
            animator.SetBool("jumping",true);
        }
        }
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Left"){
            Invoke("turnLeft",2f);
            animator.SetBool("idle",true);
            animator.SetBool("jumping",false);
            Enemy.GetComponent<Enemy>().isDead= true;
        }else if(other.tag=="Right"){
            Invoke("turnRight",2f);
            animator.SetBool("idle",true);
            animator.SetBool("jumping",false);
            Enemy.GetComponent<Enemy>().isDead= true;
        }
    }
    void turnLeft(){
        transform.localScale = new Vector3(-1,1,1);
        faceLeft = false;
        Enemy.GetComponent<Enemy>().isDead = false;
    }
    void turnRight(){
        transform.localScale = new Vector3(1,1,1);
        faceLeft = true;
        Enemy.GetComponent<Enemy>().isDead = false;
    }
}
