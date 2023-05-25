using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class oxygene : MonoBehaviour
{
    public int Oxygène;
    public int numOfOxygene;

    public Image[] bulle;
    public Sprite bullePlaine;
    public Sprite bullevide;
    
    public bool plusDeR = false;




    void Start()
    {
        InvokeRepeating("decreaseOxygène", 5.0f, 5.0f);

        GameObject thePlayer = GameObject.Find("ThePlayer");
        
    }
   


    void Update()
    {
        if (Oxygène > numOfOxygene)
        {
            Oxygène = numOfOxygene;
        }
        if (Oxygène == 0) 
        {
           
            plusDeR = true;


        }
        if (Oxygène > 0)
        {
            plusDeR = false;
        }

        for (int i = 0; i < bulle.Length; i++)
        {
            if (i < Oxygène)
            {
                bulle[i].sprite = bullePlaine;
            }
            else
            {
                bulle[i].sprite = bullevide;
            }
            if (i < numOfOxygene)
            {
                bulle[i].enabled = true;
            }
            else
            {
                bulle[i].enabled = false;
            }

        }

    }
    void decreaseOxygène()
    {
        if (Oxygène > 0)
        {
            Oxygène -= 1;
        }

    }
    
}
