using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "Loader Menu");
		

		if(GUI.Button(new Rect(20,40,80,20), "Play")) {
			Application.LoadLevel(1);
		}
		

		if(GUI.Button(new Rect(20,70,80,20), "Exit")) {
			Application.Quit();
		}
	}
}