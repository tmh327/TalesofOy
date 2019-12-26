using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoright : MonoBehaviour
{
    private Quaternion startquat;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startquat = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float angCovered = (Time.time-startTime) * 0;
        float fractionOfJourneyRot = angCovered / Quaternion.Angle(transform.rotation, startquat);
        if (Mathf.Abs(Vector3.Distance(transform.rotation.eulerAngles, startquat.eulerAngles)) > 5f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startquat, angCovered);
            //transform.LookAt(moveTo[idx],Vector3.up);
        }
        else
        {
             transform.rotation = startquat;
            transform.GetChild(0).position = transform.position;
            transform.GetChild(0).GetChild(0).position = transform.position;
            transform.GetChild(0).rotation = transform.rotation;
            transform.GetChild(0).GetChild(0).rotation = transform.rotation;
        }
    }
}
