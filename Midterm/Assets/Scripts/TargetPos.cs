using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(
            Random.Range(-5, 5),
            Random.Range(-2, 5),
            0);
        GameManager.Instance.TarPos = new Vector3(transform.position[0],transform.position[1],transform.position[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
