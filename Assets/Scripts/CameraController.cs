using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private float distanceX;

	// Use this for initialization
	void Start () {
		distanceX = transform.position.x - player.transform.position.x;
//		distanceY = transform.position.y - player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x + distanceX ,transform.position.y, transform.position.z);
	}
}
