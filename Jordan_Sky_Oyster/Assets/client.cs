using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class client : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mob;
    public GameObject mob2;
    private mobParam scrpt;
    private mobParam scrpt2;
    void Start()
    {
         scrpt = mob.GetComponent<mobParam>();
         scrpt2 = mob2.GetComponent<mobParam>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (scrpt.data != "")
        {
            Debug.Log(scrpt.data);
        }
        if (scrpt2.data != "")
        {
            Debug.Log(scrpt2.data);
        }

    }
}
