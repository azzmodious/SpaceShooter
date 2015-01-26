﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public GameController gameController; 
	public int scoreValue;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if(gameController == null)
		{
			Debug.Log("Cant find Game Controller");
		}
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary")
			return;

		Instantiate(explosion,transform.position, transform.rotation);
		if(other.tag =="Player")
		{
			Instantiate(playerExplosion,transform.position, transform.rotation);
			gameController.GameOver();
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
		gameController.IncrementScore(scoreValue);
	}
}