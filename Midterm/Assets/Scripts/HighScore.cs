using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class HighScore : MonoBehaviour
{
    // set  up file path for saving data
    private const string FILE_DIR = "/SaveData/";
    private string FILE_NAME = "highScores.csv";

    private string FILE_PATH;
    
    private int finalScore = 0;
    
    public TextMeshProUGUI display;
    
    // setting up high score updates
    string highScoresString = "";
    
    List<int> highScores;
    public List<int> HighScores
    {
        get
        {
            if (highScores == null && File.Exists(FILE_PATH))
            {
                Debug.Log("got from file");
                
                highScores = new List<int>();

                highScoresString = File.ReadAllText(FILE_PATH);

                highScoresString = highScoresString.Trim();
                
                string[] highScoreArray = highScoresString.Split("\n");

                for (int i = 0; i < highScoreArray.Length; i++)
                {
                    int currentScore = Int32.Parse(highScoreArray[i]);
                    highScores.Add(currentScore);
                }
            }
            else if(highScores == null)
            {
                Debug.Log("NOPE");
                highScores = new List<int>();
                highScores.Add(3);
                highScores.Add(2);
                highScores.Add(1);
                highScores.Add(0);
            }

            return highScores;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        finalScore = Mathf.RoundToInt(GameManager.Instance.Score);
        SetHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = "GAME COMPLETE\nFINAL SCORE: " + finalScore +
                        "\nHigh Scores:\n" + highScoresString;
        
    }

    bool IsHighScore(int scoreHolder)
    {

       for (int i = 0; i < HighScores.Count; i++)
       {
           if (highScores[i] < scoreHolder)
           {
              return true;
           }
       }

       return false;
    }
   
    void SetHighScore()
    {
        if (IsHighScore(finalScore))
        {
            int highScoreSlot = -1;

            for (int i = 0; i < HighScores.Count; i++)
            {
                if (finalScore > highScores[i])
                {
                    highScoreSlot = i;
                    break;
                }
            }
                
            highScores.Insert(highScoreSlot, finalScore);

            highScores = highScores.GetRange(0, 7);

            string scoreBoardText = "";

            foreach (var highScore in highScores)
            {
                scoreBoardText += highScore + "\n";
            }

            highScoresString = scoreBoardText;
                
            File.WriteAllText(FILE_PATH, highScoresString);
        }
    }
}

