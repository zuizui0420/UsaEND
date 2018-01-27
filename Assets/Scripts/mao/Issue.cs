using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Issue : MonoBehaviour {

    public GameObject RockPrefab;

    public Transform Spawn;

    private float attackInterval = 3.0f;//間隔
    private float lastAttackTime;


    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine("Duplication");

        if (Time.time > lastAttackTime + attackInterval)
        {
            Instantiate(RockPrefab, Spawn.position, Spawn.rotation);

            lastAttackTime = Time.time;
        }
    }

    private IEnumerator Duplication()
    {
        
        // ログ出力  
        Debug.Log("1");

        // 1秒待つ  
        yield return new WaitForSeconds(3.0f);

        // ログ出力  
        Debug.Log("2");

       

    }
}
