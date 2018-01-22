using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEvent : MonoBehaviour
{

    private int PactID;
    private GameObject playertag;

    void OnTriggerEnter2D(Collider2D other)
    {
        //PactID = other.GetComponent<Player>().actID;
        //playertag = GameObject.FindWithTag("Player" + PactID);
        if (other.gameObject.tag == "Player" +0)
        {
            other.GetComponent<Player>().isDying = true;
        }
    }
}
