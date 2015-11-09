using UnityEngine;
using System.Collections;

public class Setting_Panel : MonoBehaviour {

	public GameObject Setting_panel;
	private float startPosition;
	// Use this for initialization
	void Start () {
		startPosition = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pop() {
		InvokeRepeating("moveLeft", 0.1f,0.01f);
	}
	
	public void shrink() {
		InvokeRepeating("moveRight", 0.1f,0.01f);
	}
	
	public void moveLeft() {
		if (this.transform.position.x > 0) {
			this.transform.position = new Vector2 (this.transform.position.x - 40, this.transform.position.y);
			Setting_panel.transform.position = new Vector2 (Setting_panel.transform.position.x - 40, Setting_panel.transform.position.y);
		} else {
			CancelInvoke();
		}
	}
	
	public void moveRight() {
		if (this.transform.position.x < startPosition) {
			this.transform.position = new Vector2 (this.transform.position.x + 40, this.transform.position.y);
			Setting_panel.transform.position = new Vector2 (Setting_panel.transform.position.x + 40, Setting_panel.transform.position.y);
		} else {
			CancelInvoke();
		}
	}
}
