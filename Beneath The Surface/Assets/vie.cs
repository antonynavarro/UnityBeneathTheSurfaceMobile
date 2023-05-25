using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vie : MonoBehaviour
{
    public int Vie;
    public int numOfVie;

    public Image[] heart;
    public Sprite heartfull;
    public Sprite heartempty;
    public oxygene oxy;
    
    


    // Start is called before the first frame update
    void Start()
    {
        
        GameObject thePlayer = GameObject.Find("ThePlayer");
        InvokeRepeating("noyade", 1f, 1f);


    }
    private void Awake()
    {
        oxy = GetComponent<oxygene>();
    }

    void Update()
    {
        
        if (Vie > numOfVie)
        {
            Vie = numOfVie;
        }
       

        for (int i = 0; i < heart.Length; i++)
        {
            if (i < Vie)
            {
                heart[i].sprite = heartfull;
            }
            else
            {
                heart[i].sprite = heartempty;
            }
            if (i < numOfVie)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }

        }

    }
    public void noyade()
    {
        if (oxy.plusDeR == true)
        {


            if (Vie > 0)
            {
                
                
                
                Vie -= 1;
                
            }
        }
    }
}
