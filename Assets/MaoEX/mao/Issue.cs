using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Issue : MonoBehaviour {

    public GameObject RockPrefab;

    public Transform Spawn;

    private float attackInterval = 4.0f;//間隔
    private float lastAttackTime;


    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > lastAttackTime + attackInterval)
        {
            Instantiate(RockPrefab, Spawn.position, Spawn.rotation);

            lastAttackTime = Time.time;
        }
    }

}
