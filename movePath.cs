using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePath : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    
    public Vector3[] moveTo;
    public int idx = 0;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
       
     

        // Fraction of journey completed equals current distance divided by total distance.

        if (Mathf.Abs(Vector3.Distance(transform.position, moveTo[idx])) < .008f)
        {
            if (idx < moveTo.Length -1)
            {
                idx += 1;
            }
            else
            {
                idx = 0;
            }

            startTime = Time.time;
            
            // Set our position as a fraction of the distance between the markers.
           
        }

       
        
    }

    private void FixedUpdate()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;
        float angCovered = (Time.time ) * rotSpeed;

        Quaternion rot = Quaternion.FromToRotation(transform.forward,transform.position-moveTo[idx]);

        float fractionOfJourneyDist = distCovered / Vector3.Distance(transform.position, moveTo[idx]);
        float fractionOfJourneyRot = angCovered / Quaternion.Angle(transform.rotation,rot);

        Debug.Log(fractionOfJourneyDist);

        transform.position = Vector3.Lerp(transform.position, moveTo[idx], fractionOfJourneyDist);        

        transform.rotation = Quaternion.Lerp(transform.rotation, rot, angCovered);
        
    }
}
