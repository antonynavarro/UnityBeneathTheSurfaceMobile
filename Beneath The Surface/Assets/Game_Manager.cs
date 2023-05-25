using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Win;
    bool gameHasEnded = false;
    bool win = false;

    public void EndGame()
    {
        
        
            gameHasEnded = true;
            Debug.Log("Game Over");
            GameOver.SetActive(true);


        

    }
    public void GoodEnd()
    {
        if(win==false)
        {
            win = true;
            Debug.Log("Gagné");
            Win.SetActive(true);
        }
    }
}
