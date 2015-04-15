using UnityEngine;
using System.Collections;

public class SpriteAnimation {
	private string[] frames;
	private MonoBehaviour obj;
	private int currentFrame;
	private bool active;

	public SpriteAnimation(MonoBehaviour obj, string[] frameNames) {
		this.frames = frameNames;
		this.obj = obj;
		this.currentFrame = 0;
		this.active = false;
	}

	public void NextFrame() {
		currentFrame = (currentFrame + 1) % frames.Length;
		SpriteRenderer renderer = obj.GetComponent<SpriteRenderer> ();

	}
}
