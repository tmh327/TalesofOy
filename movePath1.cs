using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePath1 : MonoBehaviour
{
    public float speed = 1;
    public float rotSpeed;

    public Vector3[] moveTo;
    public int idx = 0;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        transform.position = transform.parent.position;
        transform.GetChild(0).position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
        transform.GetChild(0).rotation = transform.parent.rotation;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Mathf.Abs(Vector3.Distance(transform.parent.position, moveTo[idx])) < .008f)
        {
            if (idx < moveTo.Length - 1)
            {
                idx += 1;
                startTime = Time.time;
                // transform.parent.position = Vector3.zero;
            }
            else
            {
                idx = 0;
                startTime = Time.time;
                //transform.parent.position = Vector3.zero;
            }
        }


        // Fraction of journey completed equals current distance divided by total distance.


        //startTime = Time.time;

        // Set our position as a fraction of the distance between the markers.
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;
            float angCovered = (Time.time) * rotSpeed;

            Quaternion rot;
            rot = Quaternion.FromToRotation(transform.forward, transform.parent.position - moveTo[idx]);

             float fractionOfJourneyDist = distCovered / Vector3.Distance(transform.parent.position, moveTo[idx]);
           
             float fractionOfJourneyRot = angCovered / Quaternion.Angle(transform.rotation, rot);
        //Debug.Log(distCovered);

         transform.parent.position = Vector3.Lerp(transform.parent.position, moveTo[idx], fractionOfJourneyDist);
        //transform.Translate(0, 0, 1);
        //transform.Rotate(0, 1, 0);
        //transform.LookAt(moveTo[idx]);
        /*
            if (idx + 1 < moveTo.Length - 1)
            {
                Vector3 newDir = Vector3.RotateTowards(transform.forward, moveTo[idx], 10, 0.0f);
                rot = Quaternion.FromToRotation(transform.forward, transform.position - moveTo[idx+ 1]);
                angCovered = angCovered / Quaternion.Angle(transform.rotation, rot);
                fractionOfRot = angCovered / Vector3.Distance(transform.position, moveTo[idx+1]);
            if (Vector3.Distance(transform.rotation.eulerAngles, rot.eulerAngles) > 10)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, angCovered);
            }
                //transform.LookAt(moveTo[idx + 1]);
            }
            else
            {
                rot = Quaternion.FromToRotation(transform.forward, transform.position - moveTo[0]);
                angCovered = angCovered / Quaternion.Angle(transform.rotation, rot);
                fractionOfRot = angCovered / Vector3.Distance(transform.position, moveTo[0]);
            if (Vector3.Distance(transform.rotation.eulerAngles, rot.eulerAngles) > .05)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, angCovered);
            }
                //transform.LookAt(moveTo[0]);

            }
            */
        //Debug.Log(fractionOfJourneyDist);
        if (Mathf.Abs(Vector3.Distance(transform.rotation.eulerAngles, rot.eulerAngles)) > .005f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, fractionOfJourneyRot);
            //transform.LookAt(moveTo[idx],Vector3.up);
        }
        else
        {
           // transform.LookAt(moveTo[idx],Vector3.left);
        }
        Debug.Log(Mathf.Abs(Vector3.Distance(transform.rotation.eulerAngles, rot.eulerAngles)));

        

    }
}





