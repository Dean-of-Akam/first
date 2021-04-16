using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    protected AudioSource deathAudio;
    public GameObject enemy;
    private bool fall;
    private Rigidbody2D Playerrb;
    private Animator Playeranim;
    private float PlayerJumpforce;
    public bool isHurt;
    private Animator animator;
    public bool isDead;
    public AudioSource hurtAudio;
    void Start()
    {
        Playerrb = player.GetComponent<playerController>().rb;
        Playeranim = player.GetComponent<playerController>().animator;
        PlayerJumpforce = player.GetComponent<playerController>().jumpForce;
        animator = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
     void FixedUpdate()
    {
       
        fall =Playeranim.GetBool("falling");
        if(isHurt){
            player.GetComponent<playerController>().hurted = true;
           
            if(Mathf.Abs(Playerrb.velocity.x)<0.1f){
                isHurt = false;
                player.GetComponent<playerController>().hurted = false;
                Playeranim.SetBool("hurting",false);
                Playeranim.SetFloat("running",0);
            }
            
        }
    }

    private /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    { 
        if(other.gameObject.tag == "Player"){
         if(fall && player.GetComponent<playerController>().transform.position.y>this.gameObject.transform.position.y){
            animator.SetBool("dead",true);
            deathAudio.Play();
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().simulated = false;
            isDead = true;
            Invoke("Dead",0.5f);
            Playerrb.velocity = new Vector2(Playerrb.velocity.x,PlayerJumpforce*Time.fixedDeltaTime);
            Playeranim.SetBool("jumping",true);
        }else if(player.GetComponent<playerController>().transform.position.x > transform.position.x){
            Playeranim.SetBool("hurting",true);
            hurtAudio.Play();
            isHurt = true; 
            Playerrb.velocity =new  Vector2(10,Playerrb.velocity.y+3);
             
        }else if(player.GetComponent<playerController>().transform.position.x < transform.position.x){
            Playeranim.SetBool("hurting",true);
            hurtAudio.Play();
            isHurt = true;
            Playerrb.velocity =new  Vector2(-10,Playerrb.velocity.y+3);
             
        }
        }
        
    }
    void Dead(){
        this.gameObject.SetActive(false) ;
    }
}
