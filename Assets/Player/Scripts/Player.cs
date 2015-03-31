using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, InputEventListener {
	private GameObject objPlayer;
	private GameObject objCamera;
	public Sprite left, right, forward;
	private float playerHeight;

	public void OnEvent(InputEvent inputevent) {
		switch (inputevent.eventType) {
		case InputType.Jump:
			Jump ();
			break;
		case InputType.Walk:
			Move (inputevent.x, inputevent.y);
			break;
		}
		print(inputevent);
	}

	// Use this for initialization
	void Start ()
	{
		objPlayer = (GameObject) GameObject.FindWithTag("Player");
		objCamera = (GameObject) GameObject.FindWithTag("MainCamera");
		playerHeight = GetComponent<Collider2D>().bounds.extents.y;
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
	}

	void Jump() {
		Rigidbody2D rbody = GetComponent<Rigidbody2D> ();
		// Do not allow the player to jump if they are not close enough to the ground
		if (Input.GetKeyDown (KeyCode.Space) && IsGrounded ()) {
			// Apply a one time vertical force to emulate jumping
			rbody.AddForce (new Vector2 (0.0f, 300f));
		}
	}

	void Move(float x, float y) {
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

		Rigidbody2D rbody = GetComponent<Rigidbody2D> ();
		rbody.velocity = new Vector2(x*5, y+rbody.velocity.y);
		if (rbody.velocity.x >= 0) {
			renderer.sprite = right;
		} else {
			renderer.sprite = left;
		}
		UpdateCamera ();
	}

	void UpdateCamera() {
		// Update the camera
		objCamera.transform.position = new Vector3(transform.position.x,
		                                           transform.position.y,transform.position.z-10);
	}

	bool IsGrounded() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, playerHeight + 0.25f);
		return hit.collider != null;
	}

	void OnTriggerEnter2D (Collider2D Other){
		print ("COLLISION");
		print (Other);
	}
}
