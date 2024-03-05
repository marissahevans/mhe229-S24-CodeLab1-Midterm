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
    private string FILE_NAME2 = "highScoreName.csv";

    private string FILE_PATH;
    private string FILE_PATH2;
    
    private int finalScore = 0;
    
    public TextMeshProUGUI display;
    public TextMeshProUGUI dispScore;
    public TextMeshProUGUI dispName;
    
    // setting up high score updates
    string highScoresString = "";
    private string highScoreNames = "";
    
    List<int> highScores;
    private List<string> names;
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
                highScores.Add(0);
                highScores.Add(0);
                highScores.Add(0);
            }

            return highScores;
        }
    }
    
    public List<string> Names
    {
        get
        {
            if (names == null && File.Exists(FILE_PATH2))
            {
                Debug.Log("got from file");
                
                names = new List<string>();

                highScoreNames = File.ReadAllText(FILE_PATH2);

                highScoreNames = highScoreNames.Trim();
                
            }
            else if(names == null)
            {
                Debug.Log("NOPE");
                names = new List<string>();
                names.Add("AAA");
                names.Add("AAA");
                names.Add("AAA");
                names.Add("AAA");
                names.Add("AAA");
                names.Add("AAA");
                names.Add("AAA");
                
            }

            return names;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        FILE_PATH2 = Application.dataPath + FILE_DIR + FILE_NAME2;
        finalScore = Mathf.RoundToInt(GameManager.Instance.Score);
        SetHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = "GAME COMPLETE\nFINAL SCORE: " + finalScore +
                        "\nHigh Scores:\n";
        dispScore.text =  highScoresString;
        dispName.text =  highScoreNames;
        
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

            for (int i = 0; i < Names.Count; i++)
            {
                if (finalScore > highScores[i])
                {
                    highScoreSlot = i;
                    break;
                }
            }
                
            highScores.Insert(highScoreSlot, finalScore);
            names.Insert(highScoreSlot, GameManager.playernametxt.ToUpper());

            highScores = highScores.GetRange(0, 7);
            names = names.GetRange(0, 7);

            string scoreBoardText1 = "";
            string scoreBoardText2 = "";

            foreach (var highScore in highScores)
            {
                scoreBoardText1 += highScore + "\n";
            }
            foreach (var playName in names)
            {
                scoreBoardText2 += playName + "\n";
            }

            highScoresString = scoreBoardText1;
            highScoreNames = scoreBoardText2;
                
            File.WriteAllText(FILE_PATH, highScoresString);
            File.WriteAllText(FILE_PATH2, highScoreNames);
        }
    }
}

