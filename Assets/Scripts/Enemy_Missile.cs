using UnityEngine;
using System.Collections;

public class Enemy_Missile : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 200.0f;
    private Vector3 destination = new Vector3();

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        destination = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        float angle = Mathf.Atan2(destination.y, destination.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        destination.Normalize();
    }
	
	// Update is called once per frame
	void Update () {

        rb.velocity = destination * speed * Time.deltaTime;

        if (transform.position.y < -0.5f || transform.position.y > 11.0f)
        {
            Destroy(gameObject);
        }
    }
}
