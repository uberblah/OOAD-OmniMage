using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {
	
	Hashtable move_ht = new Hashtable();
	
	void Awake(){
		move_ht.Add("x", -3);
		move_ht.Add("speed",.5F);
		move_ht.Add("easetype",iTween.EaseType.linear);
		move_ht.Add("onupdate", "flipIfColl");
		move_ht.Add("oncomplete", "loopFromPosition");

	}
	
	void Start () {
		iTween.MoveBy (gameObject, move_ht);
	}
	
	void flipIfColl() {
		Vector2 fwd = new Vector2(1,0);
		//LayerMask layerMask = ~1 << 2;
		//print (fwd);
		if (Physics2D.Raycast (gameObject.transform.position, fwd, 10, ~1<<Physics2D.IgnoreRaycastLayer)) {
			print ("called");
			gameObject.transform.eulerAngles = new Vector3 (0, gameObject.transform.eulerAngles.y + 180, 0);
		}
	}

	
	void loopFromPosition () {
		iTween.MoveBy (gameObject, move_ht);
	}

}
