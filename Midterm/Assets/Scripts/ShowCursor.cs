using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    // Awake is called before scene is loaded
    void Awake()
    {
        Cursor.visible = true;
    }
}
