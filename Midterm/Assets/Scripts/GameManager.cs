using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    // set  up file path for saving data
    private const string FILE_DIR = "/SaveData/";
    private string FILE_NAME = "highScores.csv";

    private string FILE_PATH;
    
    // set up public variables for use by objects
    public static GameManager Instance;
    
    public TextMeshProUGUI display;

    public bool isInGame = false;

    public float score = 0;

    private int finalScore = 0;
    
    public int trial = 0;

    public float confidence = 0;

    public Vector3 tarPos;

    public Vector3 clickPoint;

    public static string playernametxt;
    
    // setting up public update for scores
    public float Score
    {
        get { return score; }
        set { score = value; }
    }
    
    // setting up public update for confidence
    public float Confidence
    {
        get { return confidence; }
        set { confidence = value; }
    }
    
    // setting up public update for trials
    public int Trial
    {
        get { return trial; }
        set { trial = value; }
    }
    
    // setting up public update for target postion
    public Vector3 TarPos
    {
        get { return tarPos; }
        set { tarPos = value; }
    }
    
    // setting up public update for click position
    public Vector3 ClickPoint
    {
        get { return clickPoint; }
        set { clickPoint = value; }
    }
    
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
    
    // save GameManager as a singleton on load
    void Awake()
    {
        if (Instance == null) //if the instance var has not been set
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else //if there is already a singleton of this type
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInGame)
        {
            finalScore = Mathf.RoundToInt(score);
            SetHighScore();
            display.text = "GAME OVER\nFINAL SCORE: " + finalScore +
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

            highScores = highScores.GetRange(0, 5);

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
    
}
