using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy_Spawn : MonoBehaviour {

	public static bool[] Wave1 = new bool[5];
	public static bool[] Wave2 = new bool[5];
    public static bool gameover;

    public Text end;
    public Text tryagain;

    private bool timeForBoss;
    private int wave2Count;

	// Use this for initialization
	void Start () {

		for (int i = 0; i <= 4; i++)
		{
			Wave1[i] = true;
			Wave2[i] = true;
		}

        timeForBoss = true;
        wave2Count = 0;

       InvokeRepeating("SpawnWave1", 2.0f, 10.0f);
       InvokeRepeating("CoroutineWave2", 6.0f, 10.0f);
    }
	
	// Update is called once per frame
	void Update () {

        //When the boss appears, stop instantiating enemies
        if (Time.timeSinceLevelLoad >= 25.0f)
        {
            CancelInvoke();
        }

        //Game over
        if (GameObject.Find("Player") == null)
        {
            CancelInvoke();
            gameover = true;
            end.fontSize = 60;
            end.text = "Game Over";
            tryagain.text = "Try again?";
        }

        //Drop a power-up if all enemies from the same wave are dead
		if (!Wave1[0] && !Wave1[1] && !Wave1[2] && !Wave1[3] && !Wave1[4])
		{
            Instantiate(Resources.Load("Power Up"), new Vector3(0.0f, 5.0f, 0.0f), Quaternion.identity);

			for (int i = 0; i <= 4; i++)
			{
				Wave1[i] = true;
			}
		}

        //Same but for wave 2
		if (!Wave2[0] && !Wave2[1] && !Wave2[2] && !Wave2[3] && !Wave2[4])
		{
            Instantiate(Resources.Load("Power Up"), new Vector3(0.0f, 5.0f, 0.0f), Quaternion.identity);

            for (int i = 0; i <= 4; i++)
			{
				Wave2[i] = true;
			}
		}

        //Spawn the boss
        if (Time.timeSinceLevelLoad >= 30.0f && timeForBoss && GameObject.Find("Player") != null)
        {
            Instantiate(Resources.Load("Boss"), transform.position + new Vector3(0.0f, 2.0f, 0.0f), Quaternion.LookRotation(Vector3.down, Vector3.forward));
            Instantiate(Resources.Load("Life Bar"), transform.position + new Vector3(0.0f, -1.8f, 0.0f), transform.rotation);
            timeForBoss = false;
        }
	}

    //Wave 1
    void SpawnWave1 ()
    {
        Instantiate(Resources.Load("Enemy"), transform.position, Quaternion.LookRotation(Vector3.down, Vector3.back));
		Instantiate(Resources.Load("Enemy"), transform.position + new Vector3(1.0f, 1.0f), Quaternion.LookRotation(Vector3.down, Vector3.back));
		Instantiate(Resources.Load("Enemy"), transform.position + new Vector3(-1.0f, 1.0f), Quaternion.LookRotation(Vector3.down, Vector3.back));
		Instantiate(Resources.Load("Enemy"), transform.position + new Vector3(2.0f, 2.0f), Quaternion.LookRotation(Vector3.down, Vector3.back));
		Instantiate(Resources.Load("Enemy"), transform.position + new Vector3(-2.0f, 2.0f), Quaternion.LookRotation(Vector3.down, Vector3.back));

		for (int i = 0; i <= 4; i++)
		{
			Wave1[i] = true;
		}
    }

    //Wave 2
    IEnumerator SpawnWave2 (float pos)
    {
		for (int i = 0; i <= 4; i++)
		{
			Instantiate(Resources.Load("Enemy2"), transform.position + new Vector3(pos, 0.0f), Quaternion.LookRotation(Vector3.down, Vector3.back));
			Wave2[i] = true;
			yield return new WaitForSeconds(1.0f);
		}
    }

    //Alternate spawn position of wave 2
    void CoroutineWave2()
    {
        wave2Count++;
        float pos = 0;

        switch (wave2Count)
        {
            case 2:
                pos = 1.5f;
                break;
            default:
                pos = -1.5f;
                break;
        }

        StartCoroutine(SpawnWave2(pos));
    }
}
