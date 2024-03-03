using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float timer = 0;

   private int maxTime = 2;
   

    // Update is called once per frame
    void Update()
    {
        //add the fraction of a second between frames to timer
        timer += Time.deltaTime;
        
        //if timer is >= maxTime
        if (timer >= maxTime)
        {
            if (GameManager.Instance.Trial <= 5)
            {
                SceneManager.LoadScene("Game0");
            }
            else
            {
                //GameManager.Instance.isInGame = true;
                SceneManager.LoadScene("EndPage");
                //SetHighScore();
            }
            
        }
    }
}
