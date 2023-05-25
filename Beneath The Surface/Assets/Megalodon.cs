using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megalodon : MonoBehaviour
{
    private Animator animator;
    //Régler la vitesse de l'ennemi
    public float vitesse = 15f;
    public float LaDistance = 15f;
    public static float healthAmount;
    public float attackRange = 3f;
    public vie vie;


    // Déclaration du rigibody
    Rigidbody2D rb;

    // Crée une variable pour récupérer le joueur
    private Transform player;

    SpriteRenderer sr;

   

    void Start()
    {
        //récupération du composant
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        vie = FindObjectOfType<vie>();
        healthAmount = 1;

    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) < LaDistance)
        {

            // On récuper les valeur x et y de l'ennemi
            float xE = transform.position.x;
            float yE = transform.position.y;

            // On récuper les valeur x et y du joueur
            float xJ = player.transform.position.x;
            float yJ = player.transform.position.y;

            //force sur rigidbody
            float moveX = xJ - xE;
            float moveY = yJ - yE;

            Vector2 move = new Vector2(moveX, moveY);

            rb.velocity = move.normalized * vitesse * Time.deltaTime;
            if (move != Vector2.zero)
            {
                float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;

                if (moveX < 0)
                {
                    sr.flipX = false;
                    angle += 180;


                }
                if (moveX > 0)
                {
                    sr.flipX = true;

                }

                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }

        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (healthAmount <= 0)
        {
            animator.Play("fish_death");
        }
        if (Vector2.Distance(player.position, rb.position)<= attackRange)
        {
            animator.SetTrigger("Attack");
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
           
            //animator.Play("fish_death");
            //Destroy(gameObject);
       // }
        if (collision.gameObject.tag == "Projectile")
        {

            healthAmount -= 0.2f;
            

            //Destroy(gameObject);
        }
    }
    void degat()
    {
        vie.Vie -= 1;
    }

}