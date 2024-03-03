using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToStart : MonoBehaviour
{
    void Awake()
    {
        Cursor.visible = true;
    }
    
    void OnMouseDown()
    {
        Debug.Log("You started the trial");
        GameManager.Instance.Trial++;
        SceneManager.LoadScene("Game1");
        Debug.Log("Trial:" + GameManager.Instance.Trial);
        Cursor.visible = false;
    }
}
