using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class instructionText : MonoBehaviour
{
    
    public TextMeshProUGUI display;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display.text = "Use the mouse to click as close as you can to the target";
    }
}
