using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 0.1f;
    public Text score;

    public static int count;
    public static int power;
    public static int bulletHellCount = 0;

    // Use this for initialization
    void Start () {

        count = 0;
        power = 0;
        updateScore();
	}

	// Update is called once per frame
	void Update () {
	
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Moves the player & handles boundaries
        if (horizontal != 0 || vertical != 0)
        {
            transform.Translate(new Vector3(horizontal, 0, vertical) * speed);

            if (transform.position.x > 3.1f || transform.position.x < -3.1f)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.1f, 3.1f), transform.position.y, transform.position.z);
            }

            if (transform.position.y > 9.7f || transform.position.y < 0.3f)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0.3f, 9.7f), transform.position.z);
            }
        }

        //Fires the weapon, depending on the level of power-up
        if (Input.GetButtonDown("Fire1"))
        {
            if (power == 0)
            {
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.0f, 0.4f, -3.0f), Quaternion.identity);
            }
            else if (power == 1)
            {
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.05f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(-0.05f, 0.4f,-3.0f), Quaternion.identity);
            }
            else if (power == 2)
            {
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.0f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(-0.1f, 0.4f, -3.0f), Quaternion.Euler(0.0f, 0.0f, 25.0f));
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.1f, 0.4f, -3.0f), Quaternion.Euler(0.0f, 0.0f, -25.0f));
            }
            else if (power == 3)
            {
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.15f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.05f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(-0.05f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(-0.15f, 0.4f, -3.0f), Quaternion.identity);
            }
            else if (power == 4)
            {
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.0f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(-0.1f, 0.4f, -3.0f), Quaternion.Euler(0.0f, 0.0f, 25.0f));
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.1f, 0.4f, -3.0f), Quaternion.Euler(0.0f, 0.0f, -25.0f));
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.2f, 0.4f, -3.0f), Quaternion.Euler(0.0f, 0.0f, -50.0f));
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(-0.2f, 0.4f, -3.0f), Quaternion.Euler(0.0f, 0.0f, 50.0f));
            }
            else if (power == 5)
            {
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.05f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(-0.05f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.15f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(-0.15f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(0.25f, 0.4f, -3.0f), Quaternion.identity);
                Instantiate(Resources.Load("Missile"), transform.position + new Vector3(-0.25f, 0.4f, -3.0f), Quaternion.identity);
            }
        }

        updateScore();
	}

    void updateScore ()
    {
        score.text = "Score: " + count.ToString();
    }
}
