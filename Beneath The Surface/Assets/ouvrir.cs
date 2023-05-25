using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ouvrir : MonoBehaviour
{
    public Sprite coffre_fermé;
    public Sprite coffre_ouvert;
    public SpriteRenderer render;
    public AudioSource cling;
    public GameObject particle;

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.transform.CompareTag("Player"))
        {
            render.sprite = coffre_ouvert;
            Debug.Log("SHEEEESH");
            cling.Play();
            particle.SetActive(true);
        }
        else
        {
            render.sprite = coffre_fermé;
        }
    }
}

