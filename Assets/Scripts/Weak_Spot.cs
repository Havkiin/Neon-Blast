using UnityEngine;
using System.Collections;

public class Weak_Spot : MonoBehaviour {

    public int health;
    public bool down;

	// Use this for initialization
	void Start () {

        health = 2;
        down = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Missile(Clone)")
        {
            if (health > 0)
            {
                health--;
                GetComponent<AudioSource>().Play();
            }

            //When down, become invincible until up again
            if (health == 0)
            {
                down = true;
                gameObject.layer = LayerMask.NameToLayer("Invincibility_Frames");
                GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }
}
