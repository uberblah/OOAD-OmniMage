using UnityEngine;
using System.Collections;

public class pingPong : MonoBehaviour {

	Hashtable move_ht = new Hashtable();

	void Awake(){
		move_ht.Add("x", -3);
		move_ht.Add("time",3);
		move_ht.Add("easetype",iTween.EaseType.linear);
		move_ht.Add("oncomplete", "flipAnimation");
	}

	void Start () {
		iTween.MoveBy (gameObject, move_ht);
	}
	
	// Update is called once per frame

	void flipAnimation () {
		gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y+180, 0);
		iTween.MoveBy (gameObject, move_ht);
	}

}
