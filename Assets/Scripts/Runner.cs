﻿using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	public int life;

	private float initX; //charater axis
	private int coins;
	private bool shield = false;
	private PlayerController controller;
	private Animator anim;
	private Rigidbody2D bd;

	void Start () {
		controller = GetComponent<PlayerController> ();
		anim = GetComponent<Animator> ();
		bd = GetComponent<Rigidbody2D> ();
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
		bd.AddForce (new Vector2 (-2000 * bd.mass, 0), ForceMode2D.Force);
		anim.Play ("Knight2Hurt", -1, 0f);
		life -= 1;
		if (life <= 0) {
			die();
		}
		return life;
	}
	public void die() {
		GameEventScript.TriggerGameOver();
	}

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
