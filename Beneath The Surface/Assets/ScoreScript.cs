using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int scorevalue = 0;
    TextMeshProUGUI score;

    private void Awake()
    {
        joueur.Bop_coffre += RunCo;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        scorevalue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scorevalue + "/10";
    }
    private IEnumerator Pulse()
    {
        for (float i = 1f; i <= 1.15f; i += 0.01f)
        {
            score.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        score.rectTransform.localScale = new Vector3(1.15f, 1.15f, 1.15f);

        for (float i = 1.15f; i >= 1f; i -= 0.01f)
        {
            score.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        score.rectTransform.localScale = new Vector3(1f, 1f, 1f);



    }
    public void RunCo()
    {
        StartCoroutine(Pulse());
    }
    private void OnDestroy()
    {
        joueur.Bop_coffre -= RunCo;
        

    }
}

