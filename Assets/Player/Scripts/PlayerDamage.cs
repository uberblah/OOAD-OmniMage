using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {

	public int currentHealth;
	public int invinsibleTimer;
	// Use this for initialization
	void Start () {
	}

	void FixedUpdate() {
		//decrement our invinsibility timer if our player is invinsible
		if (invinsibleTimer != 0)
			invinsibleTimer -= 1;
	}
	void OnCollisionStay2D (Collision2D other){
		if (invinsibleTimer == 0) {
			if (other.gameObject.tag == "Low Damage"){
				currentHealth -= 1;
				invinsibleTimer = 50;
			}
		}
	}
	//Health Getter
	public int GetHealth(){
		return currentHealth;
	}
}
