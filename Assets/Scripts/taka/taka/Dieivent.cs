using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dieivent : MonoBehaviour
{

    private int PactID;
    private GameObject playertag;

    void OnTriggerStay2D(Collider2D other)
    {
        PactID = other.GetComponent<Player>().actID;
        playertag = GameObject.FindWithTag("Player" + PactID);
        if (other.gameObject.tag == "Player" + PactID)
        {
            playertag.GetComponent<Player>().isDead = true;
        }
    }
}
