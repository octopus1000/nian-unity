using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	public int lifeBound = 10;
	public int crackTriggerLine = 10;

	private float initX; //charater axis
	private int life;
	private int coins;
	private bool shield = false;
	private PlayerController controller;
	private Animator anim;

	void Start () {
		controller = GetComponent<PlayerController> ();
		anim = GetComponent<Animator> ();
		initX = transform.position.x;
		life = lifeBound;
	}

	void Update() {
		if (Utility.outOfScreen(transform.position, new Vector3(0,0,0)) && life > 0) {
			life = 0;
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

//		if (coins > crackTriggerLine) {
//			coins -= crackTriggerLine;
//			Utility.explode(transform.position, 20);
//		}
		return coins;
	}
	public int getCoin(){
		return coins;
	}
	public void decreaseCoin(int num){
		coins -= num;
	}

	public int increaseLife(int num){
		life += num;
		life = life < lifeBound ? life : lifeBound;
		return life;
	}

	public int decreaseLife() {
		//bd.AddForce (new Vector2 (-2000 * bd.mass, 0), ForceMode2D.Force);
		anim.Play ("Knight2Hurt", -1, 0f);
		Handheld.Vibrate ();
		life -= 1;
		//Debug.Log (life);
		if (life <= 0) {
			life = 0;
			die();
		}
		return life;
	}
	public void die() {
		GameEventScript.TriggerGameOver();
	}

	//@param {bool} isDestructable
	//@return {bool} whether player is attacking
	public bool takeDamage(bool isDestructable) {
		//when obstacles can be destroyed by attacking
		if (isDestructable && controller.attackState) {
			return controller.attackState;
		}

		if (!shield) {
			decreaseLife ();
			shield = true;
			Invoke("removeShield", 1f);
		}
		return controller.attackState;
	}

	void removeShield() {
		shield = false;
	}
}
