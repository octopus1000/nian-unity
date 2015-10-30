using UnityEngine;
using System.Collections;

public class FlyCreepScript : MonoBehaviour {

	enum State {Idle, Attack, Back};

	public Vector3 offset = new Vector3(-1, -1, 0);
	public float time = 1; //fly 1s to reach destination

	//position determine flying track
	private Vector3 initPos;
	private Vector3 endPos;
	private Vector2 speed;

	private State state = State.Idle;
	// Use this for initialization
	void Start () {
		initPos = transform.position;
		endPos = initPos + offset;
		speed = (Vector2)offset / time;

		state = State.Idle;
	}

	// when player jump and enter a circle range around flying creep
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.tag == "PlayerParts" && state == State.Idle) {
			state = State.Attack;
		}
	}

	// Update is called once per frame
	void Update () {
		switch (state) {
		case State.Attack:
			transform.position = step(speed);
			//reach destination
			if (transform.position.x < endPos.x) {
				state = State.Back;
				speed = -speed;
			}
			break;
		case State.Back:
			transform.position = step(speed);
			if (transform.position.x > initPos.x) {
				state = State.Idle;
				speed = -speed;
			}
			break;
		}
	}

	Vector3 step(Vector2 speed) {
		Vector3 newPos;
		newPos =  transform.position +  new Vector3(speed.x * Time.deltaTime, speed.y * Time.deltaTime , 0);
		return newPos;
	}
}
