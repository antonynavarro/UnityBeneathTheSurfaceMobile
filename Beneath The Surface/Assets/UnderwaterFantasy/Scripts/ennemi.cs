using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ennemi : MonoBehaviour
{

    private Animator animator;
    //Régler la vitesse de l'ennemi
    public float vitesse = 15f;

    // Déclaration du rigibody
    Rigidbody2D rb;

    // Crée une variable pour récupérer le joueur
    private Transform player;

    SpriteRenderer sr;

    public static event Action Bop_ennemi = delegate { };

    void Start()
    {
        //récupération du composant
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
            
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) < 15)
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
                    sr.flipX = true;
                    angle += 180 ;

                }
                if (moveX >= 0)
                {
                    sr.flipX = false;
                }
                
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                
            }
            
        }
        else
        {
            rb.velocity = Vector2.zero;
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.Play("fish_death");
            //Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Projectile")
        {
            animator.Play("fish_death");
            joueur.scorevalue += 50;
            Bop_ennemi();
            
            //Destroy(gameObject);
        }
    }
}