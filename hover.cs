using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour
{
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * .01f* Mathf.Cos(Time.time*(float)20+offset));
        transform.Rotate(0, 1, 0);
    }
}
