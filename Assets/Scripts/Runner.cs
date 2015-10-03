﻿using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	public int life;
	public float speed;

	private float initX;
	private Rigidbody2D body;
	private int coins;

	void Start () {
		initX = transform.position.x;
		body = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		speed = body.velocity.x;
	}

	public float getRunDist () {
		return transform.position.x - initX;
	}

	public int addCoin() {
		coins += 1;
		return coins;
	}
	public int getCoin(){
		return coins;
	}
	public void decreaseCoin(){
		coins = 0;
	}
	public int decreaseLife() {
		life -= 1;
		return life;
	}
	public void die() {
		GameObject gameController = GameObject.FindWithTag("GameController");
		if (gameController) {
			GameManagerScript script = gameController.GetComponent<GameManagerScript>();
			if (script) {
				script.gameOver();
			}
		}
	}
}
