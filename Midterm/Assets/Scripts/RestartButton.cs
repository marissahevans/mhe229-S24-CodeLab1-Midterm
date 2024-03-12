using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("StartPage");
        GameManager.Instance.Trial = 0;
    }
}
