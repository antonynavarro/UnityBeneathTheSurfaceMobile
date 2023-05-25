using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class joueur : MonoBehaviour
{
    public float vitesse = 50f;

    Rigidbody2D rb;
    public oxygene oxy;
    public vie vie;

    public static event Action Bop = delegate { };
    public static event Action Bop_coffre = delegate { };
    public static int scorevalue = 0;

    SpriteRenderer sr;
    public Animator animator;

    CapsuleCollider2D collverti;
    BoxCollider2D collhori;
    int deja = 0;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1f;

    public GameObject lampe;
    public GameObject harpon;

    public bool YouDead = false;

    private Animator anim;

    public Joystick joystick;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oxy = GetComponent<oxygene>();
        sr = GetComponent<SpriteRenderer>();
        vie = GetComponent<vie>();
        collverti = GetComponent<CapsuleCollider2D>();
        collhori = GetComponent<BoxCollider2D>();
        InvokeRepeating("OnTriggerEnter2D", 1.0f, 1.0f);
        anim = GetComponent<Animator>();
        scorevalue = 0;

    }
   

    //  Update is called once per frame
    void FixedUpdate()
    {
        
            float moveX = joystick.Horizontal;
            float moveY = joystick.Vertical;

            Vector2 move = new Vector2(moveX, moveY);

            rb.velocity = move * vitesse * Time.deltaTime;

            animator.SetFloat("Speed", Mathf.Abs(moveX));

            if (moveX < 0)
            {
                sr.flipX = true;


            }
            if (moveX >= 0)
            {
                sr.flipX = false;
            }




            if (moveX > 0 || moveX < 0)
            {

                collhori.enabled = true;
                collverti.enabled = false;
            }
            else //if (moveY > 0 || moveY < 0)
            {
                collhori.enabled = false;
                collverti.enabled = true;

            }
        

        if (vie.Vie <= 0)
        {
            YouDead = true;
            if (YouDead == true)
            {
                dead();
               
            }
            


        }
        if (vie.Vie > 0)
        {
            YouDead = false;
            if (YouDead == false)
            {
                NotDead();
            }
        }
        if (ScoreScript.scorevalue == 10)
        {
            FindObjectOfType<Game_Manager>().GoodEnd();
            Time.timeScale = 0.0f;
        }

    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        


        if (collisionInfo.tag == "Air")
        {
            Debug.Log("coll");
            
                if (oxy.Oxygène < 8)
                {
                    oxy.Oxygène += 8;
                }
            
        }
        if (collisionInfo.tag == "Coffre")
        {
            
            ScoreScript.scorevalue += 1;
            scorevalue += 1000;
            Bop();
            Bop_coffre();
            Destroy(collisionInfo.gameObject.GetComponent<BoxCollider2D>());

        }
        if (collisionInfo.tag == "lampe")
        {

            lampe.SetActive(true);
            scorevalue += 250;
            Bop();

            Destroy(collisionInfo.gameObject);

        }
        if (collisionInfo.tag == "harpon")
        {

            harpon.SetActive(true);
            scorevalue += 250;
            Bop();
            deja = 1;

            Destroy(collisionInfo.gameObject);

        }
        if (collisionInfo.tag == "bonus_vie")
        {
            if(vie.Vie < 5)
            {
                vie.Vie += 1;
                scorevalue += 100;
                Bop();
                Destroy(collisionInfo.gameObject);
            }
           

        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "poisson")
        {
            vie.Vie -= 1;
            Destroy(collision.gameObject.GetComponent<BoxCollider2D>());
            Camera_Shake.instance.StartShake(0.2f, 0.6f);
        }
        if (collision.gameObject.tag == "bombe")
        {
            vie.Vie -= 2;
            Destroy(collision.gameObject.GetComponent<BoxCollider2D>());
            Camera_Shake.instance.StartShake(0.6f, 1f);
        }
        if (collision.gameObject.tag == "Air2")
        {
            Debug.Log("coll");

            if (oxy.Oxygène < 8)
            {
                oxy.Oxygène += 8;
            }

        }

    }
    void dead()
    {
        audioSource.PlayOneShot(audioSource.clip, volume);
        FindObjectOfType<Game_Manager>().EndGame();
        anim.Play("Anim_player_death");
        vitesse = 0f;
        harpon.SetActive(false);
        anim.SetBool("UDead", true);
        
    }
    void NotDead()
    {
        vitesse = 300f;
        if (deja > 0) 
        {
            harpon.SetActive(true);
        }
        
        anim.SetBool("UDead", false);
       

    }
    

}
   
