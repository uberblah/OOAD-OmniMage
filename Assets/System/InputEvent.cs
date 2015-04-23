using UnityEngine;
using System.Collections;

public enum InputType {
	Walk,
	Jump,
    Select,
    Cast
}

public class InputEvent {
	public InputType eventType;
	public float x, y;
    public int idx;

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

    public static InputEvent NewCastEvent() {
        InputEvent e = new InputEvent ();
        e.eventType = InputType.Cast;
        return e;
    }

    public static InputEvent NewSelectEvent(int idx) {
        InputEvent e = new InputEvent ();
        e.eventType = InputType.Select;
        e.idx = idx;
        return e;
    }
}
