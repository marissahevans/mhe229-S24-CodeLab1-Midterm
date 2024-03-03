using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    // Awake is called before scene is loaded
    void Awake()
    {
        Cursor.visible = false;
    }
    
}
