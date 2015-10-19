﻿using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	public int life;

	private float initX; //charater axis
	private int coins;
	private bool win;
	private bool shield = false;
	private PlayerController controller;
	private Animator anim;

	void Start () {
		win = false;
		controller = GetComponent<PlayerController> ();
		anim = GetComponent<Animator> ();
		initX = transform.position.x;
	}

	void Update() {
		if (Utility.outOfScreen(transform.position, new Vector3(0,0,0))) {
			Debug.Log("player out of screen");
			die();
		}
	}

	void FixedUpdate () {
		Utility.playerPosX = transform.position.x;
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
	public void decreaseCoin(int num){
		coins -= num;
	}
	public int decreaseLife() {
		anim.Play ("Knight2Hurt", -1, 0f);
		life -= 1;
		if (life <= 0) {
			die();
		}
		return life;
	}
	public void die() {
		//load game over scene
		GameEventScript.TriggerGameOver();
	}

	public void playerWin() {
		win = true;
	}

	//we need a render component to get this func called
	/*void OnBecameInvisible () {
		Debug.Log ("invisible");
		if (!win) {
			die ();
		}
	}*/

	//obstacleType - 0 (collideToDie) 2 - creep
	public bool takeDamage(int obstacleType) {
		if (controller.attackState && obstacleType == 1) {
			return false;
		}

		if (!shield) {
			decreaseLife ();
			shield = true;
			Invoke("removeShield", 1f);
		}
		return true;
	}

	void removeShield() {
		shield = false;
	}
}
