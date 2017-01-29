using UnityEngine;
using System.Collections;

public class Trident : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 50.0f;

    public bool down1;
    public bool down2;

    private float timeDown;
    private bool timeMatters;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * speed * Time.deltaTime;
        InvokeRepeating("Fire", 3.0f, 3.0f);

        timeDown = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
	    
        if (transform.position.y <= 7.8f)
        {
            rb.velocity = Vector3.zero;
        }

        down1 = GameObject.Find("Weak Spot 1").GetComponent<Weak_Spot>().down;
        down2 = GameObject.Find("Weak Spot 2").GetComponent<Weak_Spot>().down;

        //If both weak spots are down, reveal the core
        if (down1 && down2)
        {
            timeMatters = true;
            timeDown = Time.time;
            GameObject.Find("Weak Spot Main").layer = LayerMask.NameToLayer("Enemies");
            GameObject.Find("Weak Spot Main").GetComponent<Renderer>().material.color = Color.red;
            GameObject.Find("Weak Spot 1").GetComponent<Weak_Spot>().down = false;
            GameObject.Find("Weak Spot 2").GetComponent<Weak_Spot>().down = false;
        }

        //After 5 sec, hide the core and reveal the weak spots again
        if (Time.time > timeDown + 5.0f && timeMatters)
        {
            GameObject.Find("Weak Spot 1").GetComponent<Weak_Spot>().health = 2;
            GameObject.Find("Weak Spot 2").GetComponent<Weak_Spot>().health = 2;

            GameObject.Find("Weak Spot Main").layer = LayerMask.NameToLayer("Invincibility_Frames");
            GameObject.Find("Weak Spot 1").layer = LayerMask.NameToLayer("Enemies");
            GameObject.Find("Weak Spot 2").layer = LayerMask.NameToLayer("Enemies");

            GameObject.Find("Weak Spot Main").GetComponent<Renderer>().material.color = Color.blue;
            GameObject.Find("Weak Spot 1").GetComponent<Renderer>().material.color = Color.red;
            GameObject.Find("Weak Spot 2").GetComponent<Renderer>().material.color = Color.red;

            timeMatters = false;
        }
    }

    //Fire round of missiles in a 180 degree angle in front of it
    void Fire ()
    {
        for (float i = -90.0f; i <= 90.0f; i += 10.0f)
        {
            Instantiate(Resources.Load("Boss_Missile"), transform.position, Quaternion.Euler(0.0f, 0.0f, i));
            GetComponent<AudioSource>().Play();
        }
    }
}
