using UnityEngine;
using System.Collections;

public class InputEventManager : MonoBehaviour {
	private IList listeners;

	// Use this for initialization
	void Start () {
	}

	void Initialize() {
		// Initialization can happen out of order
		if (listeners == null)
			listeners = new ArrayList ();
	}

	public void Subscribe(InputEventListener listener) {
		Initialize();
		listeners.Add (listener);
	}
	public void Unsubscribe(InputEventListener listener) {
		Initialize();
		listeners.Remove (listener);
	}

	void Publish(InputEvent newevent) {
		Initialize();
		foreach (InputEventListener listener in listeners) {
			listener.OnEvent(newevent);
		}
	}

	void Update () {
		// Get input stuff
		float horiz = Input.GetAxis ("Horizontal");
		if (horiz != 0.0) {
			Publish (InputEvent.NewMoveEvent(horiz, 0.0f));
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			Publish (InputEvent.NewJumpEvent());
		}
	}
}
