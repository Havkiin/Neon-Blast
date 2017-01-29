using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 100.0f;
    public float frequency = 5.0f;
    public float magnitude = 15.0f;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Fire", 1.0f, 2.0f);
    }
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector3(Mathf.Sin(Time.time * frequency) * magnitude, -1.0f) * speed * Time.deltaTime;

        if (GameObject.Find("Player") == null)
        {
            CancelInvoke();
        }

        if (transform.position.y < -0.5f)
        {
            Destroy(gameObject);
        }
    }

    void Fire ()
    {
        Instantiate(Resources.Load("Enemy_Missile"), transform.position, transform.rotation);
    }
}
