using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 100.0f;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -0.5f)
        {
            Destroy(gameObject);
        }
    }
}
