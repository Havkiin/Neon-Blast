using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public float speed = 0.5f;

	// Use this for initialization
	void Start () {

        Screen.SetResolution(600, 900, false);
    }
	
	// Update is called once per frame
	void Update () {

        //Slow down the movement when the boss approaches
        if (Time.timeSinceLevelLoad >= 30.0f && Time.timeSinceLevelLoad < 31.0f)
        {
            speed = 0.35f;
        }
        else if (Time.timeSinceLevelLoad >= 31.0f && Time.timeSinceLevelLoad < 32.0f)
        {
            speed = 0.25f;
        }
        else if (Time.timeSinceLevelLoad >= 32.0f && Time.timeSinceLevelLoad < 33.0f)
        {
            speed = 0.15f;
        }
        else if (Time.timeSinceLevelLoad >= 33.0f)
        {
            speed = 0.0f;
        }

        transform.Translate(new Vector3(0.0f, -speed) * Time.deltaTime, Space.World);

        //Continuously replaces the 2 backgrounds on top of each other
        if (transform.position.y <= -5.0f && Time.timeSinceLevelLoad < 30.0f)
        {
            transform.position = new Vector3(0.0f, 14.9f, 0.0f);
        }
	}
}
