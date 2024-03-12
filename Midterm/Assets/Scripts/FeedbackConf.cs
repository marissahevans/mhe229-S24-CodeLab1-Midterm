using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FeedbackConf : MonoBehaviour
{
    private float newScale;
    float pointsPossible; 
    public TextMeshProUGUI display;
    void Awake()
    {
        
        newScale = GameManager.Instance.Confidence;
        pointsPossible = 10 - newScale * 2;
        Vector3 errorDist = GameManager.Instance.TarPos - GameManager.Instance.ClickPoint;
        float sqrLen = errorDist.sqrMagnitude;
        //Debug.Log("error distance:" + sqrLen);
        //Debug.Log("confidence:" + (newScale/2 * newScale/2));
        if (sqrLen > (newScale/2 * newScale/2))
        {
            GameManager.Instance.Score += 0;
            display.text = "Points earned: " + 0;
        }
        else
        {
            GameManager.Instance.Score += pointsPossible;
            display.text = "Points earned: " + Math.Round(pointsPossible,2);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameManager.Instance.TarPos;
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }

   
}
