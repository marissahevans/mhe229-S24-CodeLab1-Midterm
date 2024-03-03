using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MousePos : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Vector3 endPoint = GetMouseWoldPosition();
            GameManager.Instance.ClickPoint = new Vector3(endPoint[0], endPoint[1], endPoint[2]);
            SceneManager.LoadScene("Game2");
        }

    }
    
    Vector3 GetMouseWoldPosition()
    {
        Vector3 result = Input.mousePosition;
        result.z = Camera.main.WorldToScreenPoint(transform.position).z;
        result = Camera.main.ScreenToWorldPoint(result);
        return result;
    }
}
