using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GodPlayerScript godPlayer;
	private float distanceX;
	
	void Start () {
		distanceX = transform.position.x - godPlayer.transform.position.x;
	}

	void Update () {
		transform.position = new Vector3 (godPlayer.transform.position.x + distanceX ,transform.position.y, transform.position.z);
	}
}