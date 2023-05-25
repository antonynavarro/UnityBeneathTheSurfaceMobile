using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombe : MonoBehaviour
{
    public float maxSpeed;
    public float X;
    private Animator animator;

    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        //maxSpeed = 3;

        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveVertical();
    }

    void MoveVertical()
    {
        transform.position = new Vector3(startPosition.x, startPosition.y + Mathf.Sin(Time.time * maxSpeed), 0);

        if (transform.position.y > 1.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.y < -1.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.Play("Explosion");
            Debug.Log("boom");
            //Destroy(gameObject);
        }
    }
}


