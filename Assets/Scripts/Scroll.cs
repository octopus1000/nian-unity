using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public Rigidbody2D playerBody;
	public GameObject player;
	private float distanceX;
	
	private Vector2 offset;
	private Renderer rend;
	
	void Start ()
	{
		playerBody = player.GetComponent<Rigidbody2D> ();
		rend = GetComponent<Renderer> ();
		distanceX = transform.position.x - player.transform.position.x;

	}
	
	void FixedUpdate ()
	{
		offset.x = Time.time * playerBody.velocity.x / 70;
		rend.material.SetTextureOffset("_MainTex", offset);
		transform.position = new Vector3 (player.transform.position.x + distanceX, transform.position.y, transform.position.z);
	}
}
