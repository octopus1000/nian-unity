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
		//bd.isKinematic = false;
		bd.velocity = new Vector2 (-speedX, 0);

		if (ani) {
			//enemy walk...
			ani.SetFloat("speed", speedX);
		}
	}


	void Update() {
		if ((transform.position.x - Utility.playerPosX) < 10 && ani != null && !attackState) {
			bd.velocity = new Vector2(0,0);
			ani.SetBool("attack", true);
			attackState = true;
		}
	}
}
