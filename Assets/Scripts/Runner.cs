using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	public int life;

	private float initX; //charater axis
	private int coins;
	private bool win;
	private PlayerController controller;

	void Start () {
		win = false;
		controller = GetComponent<PlayerController> ();
		initX = transform.position.x;
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
	void OnBecameInvisible () {
		Debug.Log ("invisible");
		if (!win) {
			die ();
		}
	}

	public bool takeDamage(Collision2D coll) {

		ContactPoint2D c = coll.contacts[0];

		/*if (c.collider.gameObject.tag == "PlayerFoot") {
			return false;
		}*/
		Debug.Log("attackState:" + controller.attackState);
		if (controller.attackState) {
			return false;
		}
		decreaseLife();
		return true;
	}
}
