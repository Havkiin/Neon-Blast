using UnityEngine;
using System.Collections;

public class Mothership : MonoBehaviour {

    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.y <= -3.5f)
        {
            Destroy(gameObject);
        }
	}
}
