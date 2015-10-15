using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	public int life;

	private float initX;
	private Rigidbody2D body;
	private int coins;

	void Start () {
		initX = transform.position.x;
		body = GetComponent<Rigidbody2D> ();
	}
	
	public float getRunDist () {
		return transform.position.x - initX;
	}

	public int addCoin() {
		coins += 1;
		//Update UI
		UIManagerScript.updateCoin(coins);
		return coins;
	}
	public int getCoin(){
		return coins;
	}
	public void decreaseCoin(int num){
		coins -= num;
		UIManagerScript.updateCoin(coins);
	}
	public int decreaseLife() {
		life -= 1;
		if (life <= 0) {
			die();
		}
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
