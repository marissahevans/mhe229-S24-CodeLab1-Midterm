using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    // set up public variables for use by objects
    public static GameManager Instance;

    //public bool isInGame = false;

    public float score = 0;
    
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
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
