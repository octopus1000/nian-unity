using UnityEngine;
using System.Collections;

public class Play_Pop : MonoBehaviour {

	public GameObject Play_panel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	public void pop() {
		InvokeRepeating("moveLeft", 0.1f,0.01f);
	}

	public void shrink() {
		InvokeRepeating("moveRight", 0.1f,0.01f);
	}

	public void moveLeft() {
		if (this.transform.position.x > -230) {
			this.transform.position = new Vector2 (this.transform.position.x - 10, this.transform.position.y);
			Play_panel.transform.position = new Vector2 (Play_panel.transform.position.x - 10, Play_panel.transform.position.y);
		} else {
			CancelInvoke();
		}
	}

	public void moveRight() {
		if (this.transform.position.x < 240) {
			this.transform.position = new Vector2 (this.transform.position.x + 10, this.transform.position.y);
			Play_panel.transform.position = new Vector2 (Play_panel.transform.position.x + 10, Play_panel.transform.position.y);
		} else {
			CancelInvoke();
		}
	}
}
