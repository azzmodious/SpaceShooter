using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait; 
	public float startWait;
	public float waveWait;
	public int wave=0; 
	public bool playMusic = true;

	public Text waveText; 
	public Text scoreText;
	public Text gameOverText;
	public Text restartText;

	public int score = 0;

	private bool gameOver; 
	private bool restart;

	void Start()
	{
		
		StartCoroutine(spawnWaves());
		if(!playMusic)
			audio.Stop();

		gameOverText.text = "";
		restartText.text = "";
		score = 0; 
		gameOver = false;
		restart = false;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		restartText.text = "Press R to restart";
		restart = true;
		gameOver = true;
	}
	public void IncrementScore(int val)
	{
		score+=val;
	}
	IEnumerator spawnWaves()
	{
		
		yield return new WaitForSeconds(startWait);
		while(!gameOver)
		{
			wave++;
			for(int index = 0; index < hazardCount+wave; index++)
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				//cl

				yield return new WaitForSeconds(spawnWait);
			}


			yield return new WaitForSeconds(waveWait);
		}
	}



	void Update()
	{
		waveText.text = "Wave: "+wave;
		scoreText.text = "Score: "+score;
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
}
