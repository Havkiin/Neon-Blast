using UnityEngine;
using System.Collections;

public class Weak_Spot_Main : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Start () {

        health = 15;
        GetComponent<Renderer>().material.color = Color.blue;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Missile(Clone)")
        {
            //If hot, reduce boss health
            if (health > 0)
            {
                health--;
                GetComponent<AudioSource>().Play();
                GameObject.Find("Life Bar(Clone)").transform.localScale += new Vector3(-0.25f, 0.0f);
                GameObject.Find("Life Bar(Clone)").transform.position += new Vector3(-0.125f, 0.0f);
            }

            //When defeated, destroy the boss, display victory screen and disable player
            if (health == 0)
            {
                Player.count += 10000;
                Destroy(transform.parent.gameObject);
                Enemy_Spawn.gameover = true;
                
                GameObject.Find("Player").GetComponent<Player>().enabled = false;
                GameObject.Find("Player Collider").GetComponent<Player_Collider>().enabled = false;

                Instantiate(Resources.Load("Animations/explosion_enemy"), transform.position, transform.rotation);
                Instantiate(Resources.Load("Animations/explosion_enemy"), GameObject.Find("Weak Spot 1").transform.position, GameObject.Find("Weak Spot 1").transform.rotation);
                Instantiate(Resources.Load("Animations/explosion_enemy"), GameObject.Find("Weak Spot 2").transform.position, GameObject.Find("Weak Spot 2").transform.rotation);

                GameObject.Find("Sound Enemies").GetComponent<AudioSource>().Play();
                GameObject.Find("Sound Enemies").GetComponent<AudioSource>().Play();
                GameObject.Find("Sound Enemies").GetComponent<AudioSource>().Play();
                GameObject.Find("Enemy Spawner").GetComponent<Enemy_Spawn>().end.fontSize = 43;
                GameObject.Find("Enemy Spawner").GetComponent<Enemy_Spawn>().end.text = "Congratulations!";
                GameObject.Find("Enemy Spawner").GetComponent<Enemy_Spawn>().tryagain.text = "Play again?";
            }
        }
    }
}
