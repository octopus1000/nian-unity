using UnityEngine;
using System.Collections;

public class CollideToDie : MonoBehaviour {

	public bool isDestructable = false;
	public bool isTrigger = true;
	public bool isTrample = false;
	public int lifeBound = 1;

	private Runner runner; //must exist
	private Animator ani;
	private int life;
 
	public delegate void CreatureBehave();
	public CreatureBehave die = null;

	void Start() {
		//set animator
		ani = GetComponent<Animator> ();
		//set life
		life = lifeBound;
	}

	void  OnBecameVisible() {
		//set player script which control life
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player) {
			runner = player.GetComponent<Runner> ();
		} else {
			Debug.LogError("can't find tag with player");
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (isTrigger && col.tag == "PlayerParts") {
			damage();
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			//collision from bottom
			if (isTrample &&  Vector3.Dot(col.contacts[0].normal, -Vector3.up) > 0.7f) {
				takeDamage(1);
				Debug.Log(col.contacts[0].normal);
			} else {
				damage();
			}
		}
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	void damage() {
		//player is attacking
		if (runner && runner.takeDamage (isDestructable) && isDestructable) {
			takeDamage(1);
		}
	}

	void takeDamage(int damage) {
		life -= damage;
		if (life <= 0) {
			if (die != null) {
				die();
			} else {
				DieDefault();
			}
		}
	}

	void DieDefault() {
		//animation....
		Debug.Log ("mike die");
		if (ani) {
			ani.SetTrigger("die");
	//		ani.Play("die");
		} else {
			Destroy(gameObject);
		}
	}
}
