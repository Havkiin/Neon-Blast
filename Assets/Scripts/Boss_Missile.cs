using UnityEngine;
using System.Collections;

public class Boss_Missile : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 100.0f;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = -transform.up * speed * Time.deltaTime;

        if (transform.position.y > 11.0f || transform.position.y < -0.5f || transform.position.x < -4.0f || transform.position.x > 4.0f)
        {
            Destroy(gameObject);
        }
    }
}
