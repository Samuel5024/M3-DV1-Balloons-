using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float floatStrength = 20f;
     private GameObject balloon;
   void Update()
    {
        if(Input.GetButtonDown("XRI_Right_TriggerButton"))
        {
            Debug.Log("Trigger down");
            CreateBalloon();
        }
        // else if(Input.GetButtonUp("XRI_Right_TriggerButton"))
        if(Input.GetButtonUp("XRI_Right_TriggerButton"))
        {
            Debug.Log("Trigger up");
            ReleaseBalloon();
        }
    }

    public void CreateBalloon()
    {
        balloon = Instantiate(balloonPrefab);

    }

    public void ReleaseBalloon()
    {
        Debug.Log("Release called");
        Rigidbody rb = balloon.GetComponent<Rigidbody>();
        Vector3 force = Vector3.up * floatStrength;
        rb.AddForce(force);

        GameObject.Destroy(balloon, 10f);
        balloon = null;
    }
}
