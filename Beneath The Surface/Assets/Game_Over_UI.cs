using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Over_UI : MonoBehaviour
{
    public vie vie;
    public oxygene oxy;
    public GameObject GameOver;
    public joueur Joueur;
    

    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        Joueur = g.GetComponent<joueur>();
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1.0f;
    }
    public void Revive()
    {
        if (vie.Vie < 5)
        {
            vie.Vie += 5;
        }
        
        if (oxy.Oxygène < 8)
        {
            oxy.Oxygène += 8;
        }

        GameOver.SetActive(false);
        Joueur.YouDead = false;
        
    }

}
