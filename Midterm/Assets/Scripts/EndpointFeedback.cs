using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointFeedback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameManager.Instance.ClickPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
