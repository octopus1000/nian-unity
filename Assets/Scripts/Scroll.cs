using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public Rigidbody2D playerBody;
	public GameObject godplayer;
	private float distanceX;
	
	private Vector2 offset;
	private Renderer rend;

	void Start ()
	{
		playerBody = godplayer.GetComponent<Rigidbody2D> ();
		rend = GetComponent<Renderer> ();
		distanceX = transform.position.x - godplayer.transform.position.x;
	}
	
	void FixedUpdate ()
	{
		offset.x = Time.time * playerBody.velocity.x / 700;
		if (rend != null)
			rend.material.SetTextureOffset("_MainTex", offset);

		transform.position = new Vector3 (godplayer.transform.position.x + distanceX, transform.position.y, transform.position.z);
	}
}
