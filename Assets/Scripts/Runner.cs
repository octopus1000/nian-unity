using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	public int life;

	private float initX; //charater axis
	private int coins;
	private bool win;

	void Start () {
		win = false;
		initX = transform.position.x;
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

	void OnBecameInvisible () {
		Debug.Log ("invisible");
		if (!win) {
			die ();
		}
	}
}
