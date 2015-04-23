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
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Publish(InputEvent.NewSelectEvent(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Publish(InputEvent.NewSelectEvent(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            Publish(InputEvent.NewSelectEvent(2));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            Publish(InputEvent.NewSelectEvent(3));
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            Publish(InputEvent.NewSelectEvent(4));
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            Publish(InputEvent.NewSelectEvent(5));
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            Publish(InputEvent.NewSelectEvent(6));
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) {
            Publish(InputEvent.NewSelectEvent(7));
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Publish(InputEvent.NewSelectEvent(8));
        }
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            Publish(InputEvent.NewSelectEvent(9));
        }
        if (Input.GetMouseButtonDown(0)) {
            Publish(InputEvent.NewCastEvent());
        }
	}
}
