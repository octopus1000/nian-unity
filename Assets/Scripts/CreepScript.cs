using UnityEngine;
using System.Collections;

public class CreepScript : MonoBehaviour {

	private Animator ani;
	private bool attackState = false;
	private Rigidbody2D bd;
	public float speedX = 10;

	void Start() {
		ani = GetComponent<Animator> ();
		bd = GetComponent<Rigidbody2D> ();
	}

	void OnBecameVisible () {
		bd.velocity = new Vector2 (-speedX, 0);

		if (ani) {
			//enemy walk...
			ani.SetFloat("speed", speedX);
		}
	}


	void FixedUpdate() {
		if ((transform.position.x - Utility.playerPosX) < 10 && ani != null && !attackState) {
			ani.SetBool("attack", true);
			attackState = true;
		}
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Runner runner = coll.gameObject.GetComponent<Runner>();
			if (runner) {
				if (runner.takeDamage(coll)) {
					bd.velocity = new Vector2(-speedX, 0);
				} else {
					die();
				}
			} else {
				Debug.Log("Can not find runner script");
			}
		}
	}

	void die() {
		//animation....
		Debug.Log ("Creep die");
		Destroy (gameObject);
	}
}
