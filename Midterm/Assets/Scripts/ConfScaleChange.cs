using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ConfScaleChange : MonoBehaviour
{
    private Vector3 scaleChange;
    private float pointsPossible;
    public TextMeshProUGUI display;

    void Awake()
    {
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameManager.Instance.TarPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localScale += scaleChange;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localScale -= scaleChange;
        }
        if (transform.localScale.y < 0.01f || transform.localScale.y > 5.0f)
        {
            scaleChange = -scaleChange;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GameManager.Instance.Confidence = transform.localScale[0];
            SceneManager.LoadScene("Game3");
        }

        pointsPossible = 10 - transform.localScale[0] * 2;
        display.text = "Points possible:" + Math.Round(pointsPossible,2);
    }
}
