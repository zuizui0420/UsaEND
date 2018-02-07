using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemIvent : MonoBehaviour {
    
    string thisobname;
    public GameObject Player;
    private void Start()
    {
        thisobname = this.gameObject.name;
	

        //Carrot・Energy・Pickel・Torch
    }
    void OnCollisionEnter2D(Collision2D other)
    {


        if (other.gameObject.tag == "Player" + 0 || other.gameObject.tag == "Player" + 1)
        {
            if (other.gameObject.GetComponent<Player>().Item0 == " "){
                other.gameObject.GetComponent<Player>().Item0 = thisobname;
                Destroy(gameObject);
            }
            else if (other.gameObject.GetComponent<Player>().Item1 == " ") {
                other.gameObject.GetComponent<Player>().Item1 = thisobname;
                Destroy(gameObject);
            }
        }
    }
    private void Update()
    {
        if (Player.GetComponent<Player>().Item0 != " " && Player.GetComponent<Player>().Item1 != " ")
        {
            this.gameObject.layer = LayerMask.NameToLayer("ItemOver");
        }
        else
        {
            this.gameObject.layer = LayerMask.NameToLayer("Item");
        }
    }
}
