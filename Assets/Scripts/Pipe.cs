using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float Force;
    void Start()
    {
        // Todo: get this value from GameController
        Force = 2.5f;
    }
    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(((Force * Time.deltaTime) * -1), 0f, 0f);
    }
}
