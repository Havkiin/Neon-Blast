using UnityEngine;
using System.Collections;

public class Player_Collider : MonoBehaviour {

    private float timeHit;
    private bool hit;

	// Use this for initialization
	void Start () {

        timeHit = 0.0f;
        hit = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
        //When the player is hit, he becomes invincible for 2 sec.
        if (Time.time > timeHit + 2.0f)
        {
            CancelInvoke();
            gameObject.layer = LayerMask.NameToLayer("Player");
            timeHit = 0.0f;
        }
        else if (hit)
        {
            InvokeRepeating("coroutineInvincible", 0.0f, 1.0f);
        }
	}

    //Handles collisions with enemies and enemy missiles: downgrades weapon or kills if weapon is not upgraded
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name == "Enemy(Clone)" || col.gameObject.name == "Enemy2(Clone)" || col.gameObject.name == "Enemy_Missile(Clone)" 
            || col.gameObject.name == "Boss_Missile(Clone)" || col.gameObject.name == "Boss(Clone)" || (Player.bulletHellCount > 0 && col.gameObject.name == "Missile(Clone)"))
        {
            if (Player.power > 0)
            {
                GameObject.Find("Player").GetComponent<AudioSource>().Play();
                timeHit = Time.time;
                gameObject.layer = LayerMask.NameToLayer("Invincibility_Frames");
                Destroy(col.gameObject);
                Player.power--;
                hit = true;
            }
            else
            {
                GameObject.Find("Sound Player").GetComponent<AudioSource>().Play();
                Instantiate(Resources.Load("Animations/explosion_player"), transform.position, transform.rotation);
                Destroy(col.gameObject);
                Destroy(transform.parent.gameObject);
            }
        }

        //Handles picking up power-ups
        if (col.gameObject.name == "Power Up(Clone)")
        {
            GetComponent<AudioSource>().Play();
            Destroy(col.gameObject);
            Player.power++;
        }
    }

    //Makes the player blink to signal invincibility
    IEnumerator invincible ()
    {
        transform.parent.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        transform.parent.GetComponent<MeshRenderer>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(0.5f);
    }

    void coroutineInvincible ()
    {
        StartCoroutine(invincible());
    }
}
