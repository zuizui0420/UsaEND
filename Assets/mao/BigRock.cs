using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRock : MonoBehaviour {

    public bool houkou;

    public bool hansya;

    bool WallHit = false;

    public float speed;

   
    

    // Use this for initialization
    void Start ()
    {
        StartCoroutine("hukusei");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if (WallHit == false)
        {
            rigidbody.velocity = Vector2.right * speed;
        }
        else
        {
            rigidbody.velocity = Vector2.left * speed;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (hansya)
            {
                WallHit = true;
            }
            else
            {
                Debug.Log("hit");
                Destroy(this.gameObject);

            }

        }
    }

    private IEnumerator hukusei()
    {
        // ログ出力  
        Debug.Log("1");

        // 1秒待つ  
        yield return new WaitForSeconds(3.0f);

        // ログ出力  
        Debug.Log("2");


    }
}
