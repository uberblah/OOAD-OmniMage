using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, InputEventListener {
	public Sprite left, right, forward;
	public Animation[] anims;
	private GameObject objPlayer;
	private GameObject objCamera;
	private Vector2 playerSize;

	public void OnEvent(InputEvent inputevent) {
		switch (inputevent.eventType) {
		case InputType.Jump:
			Jump ();
			break;
		case InputType.Walk:
			Move (inputevent.x, inputevent.y);
			break;
		}
		//print(inputevent);
	}

	// Use this for initialization
	void Start ()
	{
		objPlayer = (GameObject) GameObject.FindWithTag("Player");
		objCamera = (GameObject) GameObject.FindWithTag("MainCamera");
		playerSize = GetComponent<Collider2D>().bounds.extents;

		Register ();
		

	}

	void Register ()
	{
		GameObject system = (GameObject) GameObject.FindWithTag ("System");
		InputEventManager manager = system.GetComponent<InputEventManager> ();
		manager.Subscribe (this);
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateCamera ();
		Animator anim = GetComponent<Animator>();
		anim.SetInteger ("Direction", 0);
		//SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		//renderer.sprite = right;
	}

	void Jump() {
		Rigidbody2D rbody = GetComponent<Rigidbody2D> ();
		// Do not allow the player to jump if they are not close enough to the ground
		if (MinDistance(-Vector3.up) < playerSize.y + .25) {
			// Apply a one time vertical force to emulate jumping
			rbody.AddForce (new Vector2 (0.0f, 300f));
		}
	}

	void Move(float x, float y) {
		//SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		Animator anim = GetComponent<Animator>();

		//Rigidbody2D rbody = GetComponent<Rigidbody2D> ();
		//rbody.velocity = new Vector2(x*5, y+rbody.velocity.y);
		if (IsGrounded() == true){
			if (x >= 0) {
				//renderer.sprite = right;
				anim.SetInteger("Direction", 1);
				if (MinDistance (Vector2.right) < playerSize.x*1.5) 
					return;
			} else {
				anim.SetInteger("Direction", -1);
				if (MinDistance (-Vector2.right) < playerSize.x*1.5) 
					return;
			}
			//renderer.sprite = left;
		}
		transform.position += new Vector3(x/10, y, 0);

		UpdateCamera ();
	}

	void UpdateCamera() {
		// Update the camera
		objCamera.transform.position = new Vector3(transform.position.x,
		                                           transform.position.y,transform.position.z-10);
	}

	float MinDistance(Vector2 direction) {
		Vector3 adjustment = new Vector3(0,0,0);

		if (direction.x != 0) {
			adjustment.y = 1;
			adjustment.y *= playerSize.y/2;
		}
		if (direction.y != 0) {
			adjustment.x = 1;
			adjustment.x *= playerSize.x/2;
		}


		float min = RaycastDirection(transform.position-adjustment, direction, 10);
		min = Mathf.Min (min, RaycastDirection (transform.position, direction, 10));
		min = Mathf.Min (min, RaycastDirection (transform.position+adjustment, direction, 10));

		return min;
	}

	float RaycastDirection(Vector3 pos, Vector2 dir, float maxdist) {
		RaycastHit2D hit = Physics2D.Raycast(pos, dir, maxdist);
		if (hit.collider == null) {
			return float.PositiveInfinity;
		}
		return hit.distance;
	}

	bool IsGrounded() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, playerSize.y + 0.25f);
		return hit.collider != null;
	}

	void OnTriggerEnter2D (Collider2D Other){
		print ("COLLISION");
		print (Other);
	}
}
