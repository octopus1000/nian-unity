using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//States
	private const int NORMAL = 0;
	private const int IN_AIR = 1;
	private const int CROUCH = 2;
	private const int DIE = 3;

	private int state;
	private int player_speed = 10;
	private int accelerate_speed = 20;
	private int player_height = 15;
	private int activate_num = 10;
	private Rigidbody2D rb;
	private Runner runner;
	private Animator anim;
	public GameObject weapon;
	public GameObject halo;
	public GodPlayerScript godPlayer;
	public bool rushState = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		runner = GetComponent<Runner> ();
		run ();
	}
	
	// Update is called once per frame
	void Update () {
		//debug
		if (runner.getCoin () >= activate_num) {
			Debug.Log(runner.getCoin());
			runner.decreaseCoin (activate_num);
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
			{
				Ray ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );
				RaycastHit hit;
				
				if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == "Knight2")
				{
					magic();  
				}
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (state == IN_AIR) {
			anim.SetTrigger("onGround");
			Debug.Log ("collision");
			state = NORMAL;
		}
	}

	void FixedUpdate(){	
		float speedX = godPlayer.getSpeedX();
		//lag behind god player
		if (transform.position.x < godPlayer.transform.position.x) {
			speedX *= 1.2f;
		}
		rb.velocity = new Vector2 (speedX, rb.velocity.y);
	}

	public void run (){
		Debug.Log ("run");
		state = NORMAL;
	}

	public void jump (){
		if (state == NORMAL) {
			Debug.Log ("jump");
			rb.velocity = new Vector2 (player_speed, player_height);
			anim.Play ("Knight2JumpUp", -1, 0f);
			state = IN_AIR;
		}
	}

	public void attack (){
		anim.Play ("Knight2Attack", -1, 0f); 
	}

	public void magic(){
		StartCoroutine(MyCoroutine());
	}
	
	public void accelerate (){
		godPlayer.setSpeedX (accelerate_speed);
	}

	IEnumerator MyCoroutine(){
		accelerate ();
		anim.Play ("Knight2Rush",-1,0f);
		rushState = true;
		Debug.Log (rb.velocity);
		yield return new WaitForSeconds (2.0f);
		godPlayer.setSpeedX (player_speed);
		rushState = false;
		Debug.Log (rb.velocity);
	}

}
