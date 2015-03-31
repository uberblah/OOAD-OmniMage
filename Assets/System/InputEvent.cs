using UnityEngine;
using System.Collections;

public enum InputType {
	Walk,
	Jump
}

public class InputEvent {
	public InputType eventType;
	public float x, y;

	public static InputEvent NewMoveEvent(float x, float y) {
		InputEvent e = new InputEvent ();
		e.eventType = InputType.Walk;
		e.x = x;
		e.y = y;
		return e;
	}

	public static InputEvent NewJumpEvent() {
		InputEvent e = new InputEvent ();
		e.eventType = InputType.Jump;
		return e;
	}
}
