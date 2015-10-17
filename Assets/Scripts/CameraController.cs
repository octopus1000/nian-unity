using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GodPlayerScript godPlayer;
	public GameObject player;
	private float distanceX;
	private float distanceY;
	
	void Start () {
		distanceX = transform.position.x - godPlayer.transform.position.x;
		distanceY = transform.position.y - player.transform.position.y;
	}

	void Update () {
		transform.position = new Vector3 (godPlayer.transform.position.x + distanceX , player.transform.position.y + distanceY, transform.position.z);
	}
}