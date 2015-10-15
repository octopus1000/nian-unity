using UnityEngine;
using System.Collections;

public class GodPlayerScript : MonoBehaviour {

	public float speed; //god player move in constant speed
	public GameObject player;
	private Rigidbody2D bd;

	void Start () {
		bd = GetComponent<Rigidbody2D> ();

		//init god player with constant velocity
		bd.velocity = new Vector2(speed, 0);

		//overlap god player and player
		transform.position = player.transform.position;
	}

	public float getSpeedX() {
		return bd.velocity.x;
	}
}