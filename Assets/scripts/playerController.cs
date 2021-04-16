using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerController : MonoBehaviour
{
   public Rigidbody2D rb; //【SerializeField】依然是私有，但是会在属性栏显示，主要用于Debug
   public Animator animator; 
   public float speed ;
   public float jumpForce;
   
   public LayerMask ground;
   private Collider2D collider;
   private int Cherry = 0;
   private int gem = 0;
   private int jumpcount = 2;

   public Text cherryNum;
   public Text gemNum;

   public bool hurted;

   public AudioSource jumpAudio,berryAudio,gemAudio;
   public BoxCollider2D head;
   public Transform cellingCheck;
   
   
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();      
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(!hurted)
        {
            Movement();
        }
       
        
        
        
        switchAnim();

    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        jump();
        Crouch();
         cherryNum.text = Cherry.ToString();
          gemNum.text = gem.ToString();
    }

//移动
    public void Movement()
    {
        
        float horizontalMove = Input.GetAxis("Horizontal");
        float faceDirection = Input.GetAxisRaw("Horizontal");
        //角色移动
        if(horizontalMove !=0f){
            rb.transform.Translate(horizontalMove*speed*Time.fixedDeltaTime,0,0);
            animator.SetFloat("running",Mathf.Abs(faceDirection));
            
        }
        if(faceDirection != 0f){
           transform.localScale = new Vector3(faceDirection,1,1);
        }
        //角色跳跃
       
  
        
    }

//切换动画
    void switchAnim(){
        // animator.SetBool("idle",false);
        if(rb.velocity.y<0.1f && !collider.IsTouchingLayers(ground)){
            animator.SetBool("falling",true);
        }
        
        if(animator.GetBool("jumping")){
            if(rb.velocity.y <0)
            {
                animator.SetBool("jumping",false);
                animator.SetBool("falling",true);
            }
        }
        else if(collider.IsTouchingLayers(ground)){
                animator.SetBool("falling",false);
                //animator.SetBool("idle",true);
        }
       

    }
//收集
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Cherry")
        {
            //Destroy(collision.gameObject);
            // Cherry +=1;
           
            collision.GetComponent<Animator>().Play("Cherry_isgot");
            collision.GetComponent<Collider2D>().enabled = false;
            berryAudio.Play();
            
        }
        if(collision.tag == "Gem")
        {
            collision.GetComponent<Animator>().Play("Gem_isGot");
            collision.GetComponent<Collider2D>().enabled = false;
            gemAudio.Play();
        }
    }
    void Crouch(){
        
        if (Input.GetButton("Crouch"))
    {
        animator.SetBool("crouching", true);
        head.enabled = false;
    }
        else
    {
            if (!Physics2D.OverlapCircle(cellingCheck.position, 0.2f, ground))
        {
            animator.SetBool("crouching", false);
            head.enabled = true;
        }
    }
        
    }
    void jump(){
         if(Input.GetButtonDown("Jump") && jumpcount>0){
           
            
            rb.velocity = new Vector2(rb.velocity.x,jumpForce*Time.fixedDeltaTime);
            animator.SetBool("jumping",true);
            jumpAudio.Play();
            jumpcount=jumpcount-1;
           
        }
        if(collider.IsTouchingLayers(ground)){
                jumpcount = 2;
            }
    }
    public void CherryCount(){
        Cherry+=1;
    }
    public void GemCount(){
        gem+=1;
    }
}
