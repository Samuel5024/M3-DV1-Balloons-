using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float floatStrength = 20f;
    public float growRate = 1.5f;
     private GameObject balloon;
   void Update()
    {
        if(Input.GetButtonDown("XRI_Right_TriggerButton"))
        {
            Debug.Log("Trigger down");
            CreateBalloon();
        }
         else if(Input.GetButtonUp("XRI_Right_TriggerButton"))
        {
            Debug.Log("Trigger up");
            ReleaseBalloon();
        }
        else if(balloon != null)
        {
            GrowBalloon();
        }
    }

    public void CreateBalloon(GameObject parentHand)
    {
        balloon = Instantiate(balloonPrefab, parentHand.transform);
        balloon.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }

    public void ReleaseBalloon()
    {
        balloon.transform.parent = null;
        balloon.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
        Debug.Log("Release called");
        // Rigidbody rb = balloon.GetComponent<Rigidbody>();
        // Vector3 force = Vector3.up * floatStrength;
        // rb.AddForce(force);
        GameObject.Destroy(balloon, 10f);
        balloon = null;
    }

    public void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
        // float growThisFrame = growRate * growThisFrame.deltaTime;
        // Vector3 changeScale = balloon.transform.localScale * growThisFrame;
        // balloon.transform.localScale += changeScale;
    }
}
