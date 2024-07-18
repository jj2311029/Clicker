using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TitleController: MonoBehaviour
{
    [SerializeField] private Text PressText;
    [SerializeField] private float fadingInterval;
    private float elapsedTime;
    private bool isFadeIn=false;



    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(isFadeIn)
        {
            float alpha= Mathf.Lerp(0.0f, 1.0f, elapsedTime/fadingInterval);
            SetTextAlpha(alpha);

            if(elapsedTime > fadingInterval)
            {
                isFadeIn = false;
                elapsedTime = 0.0f;
            }
        }
        else
        {
            float alpha=Mathf.Lerp(1.0f,0.0f, elapsedTime/fadingInterval);
            SetTextAlpha(alpha);

            if(elapsedTime > fadingInterval)
            {
                isFadeIn = true;
                elapsedTime = 0.0f;
            }
        }
    }

    private void SetTextAlpha(float alpha)
    {
        Color color=PressText.color;
        color.a = alpha;
        PressText.color = color;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main");
    }    
}
