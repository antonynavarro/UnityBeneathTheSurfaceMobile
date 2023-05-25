﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
    public static Camera_Shake instance;
    private float shakeTimeRemaining, shakePower, shakeFadeTime;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;
            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
        }
    }
    public void StartShake (float lenght, float power)
    {
        shakeTimeRemaining = lenght;
        shakePower = power;

        shakeFadeTime = power / lenght;
    }
}
