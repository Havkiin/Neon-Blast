using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 500.0f;
	private bool[] Wave1 = Enemy_Spawn.Wave1;
	private bool[] Wave2 = Enemy_Spawn.Wave2;
    private int bulletHellCount;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        bulletHellCount = Player.bulletHellCount;

        if (bulletHellCount > 0)
        {
            gameObject.layer = LayerMask.NameToLayer("Bullet_Hell");
        }
    }
	
	// Update is called once per frame
	void Update () {

        rb.velocity = transform.up * speed * Time.deltaTime;

        //If bullethell mode is on, wraps around the screen
        if (bulletHellCount > 0)
            {
                if (transform.position.y > 10.0f)
                {
                    transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
                    bulletHellCount--;
                }
                else if (transform.position.x > 3.4f)
                {
                    transform.position = new Vector3(-3.4f, transform.position.y, transform.position.z);
                    bulletHellCount--;
                }
                else if (transform.position.x < -3.4f)
                {
                    transform.position = new Vector3(3.4f, transform.position.y, transform.position.z);
                    bulletHellCount--;
                }
        }
        else
        {
            if (transform.position.y > 10.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    //Handles collision with the enemies, sets them as dead in their wave array, to trigger power-up
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name == "Enemy(Clone)")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Player.count += 100;

			if (Wave1[0])
			{
				Wave1[0] = false;
			}
			else if (Wave1[1])
			{
				Wave1[1] = false;
			}
			else if (Wave1[2])
			{
				Wave1[2] = false;
			}
			else if (Wave1[3])
			{
				Wave1[3] = false;
			}
			else if (Wave1[4])
			{
				Wave1[4] = false;
			}

            GameObject.Find("Sound Enemies").GetComponent<AudioSource>().Play();
            Instantiate(Resources.Load("Animations/explosion_enemy"), col.transform.position, col.transform.rotation);
        }
        else if (col.gameObject.name == "Enemy2(Clone)")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Player.count += 200;

			if (Wave2[0])
			{
				Wave2[0] = false;
			}
			else if (Wave2[1])
			{
				Wave2[1] = false;
			}
			else if (Wave2[2])
			{
				Wave2[2] = false;
			}
			else if (Wave2[3])
			{
				Wave2[3] = false;
			}
			else if (Wave2[4])
			{
				Wave2[4] = false;
			}

            GameObject.Find("Sound Enemies").GetComponent<AudioSource>().Play();
            Instantiate(Resources.Load("Animations/explosion_enemy"), col.transform.position, col.transform.rotation);
        }
    }
}
