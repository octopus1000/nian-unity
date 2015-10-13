using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Runner player;
	private float distanceX;
	
	void Start () {
		distanceX = transform.position.x - player.transform.position.x;
	}

	void Update () {

		//simple follow
		transform.position = new Vector3 (player.transform.position.x + distanceX ,transform.position.y, transform.position.z);
	}
}