using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {

	public int currentHealth;
	public int invinsibleTimer;

	void FixedUpdate() {
		//decrement our invinsibility timer if our player is invinsible
		if (invinsibleTimer != 0)
			invinsibleTimer -= 1;
		//check for death
		if (currentHealth == 0)
			Death ();
	}
	void OnCollisionStay2D (Collision2D other){
		if (invinsibleTimer <= 0) {
			if (other.gameObject.tag == "Low Damage"){
				currentHealth -= 1;
				invinsibleTimer = 50;
			}
			else if (other.gameObject.tag == "Medium Damage"){
				currentHealth -= 2;
				invinsibleTimer = 50;
			}
			else if (other.gameObject.tag == "High Damage"){
				currentHealth -= 3;
				invinsibleTimer = 50;
			}
			else if (other.gameObject.tag == "Instakill"){
				currentHealth = 0;
				invinsibleTimer = 50;
			}

		}
	}
	//Health Getter
	public int GetHealth(){
		return currentHealth;
	}

	private void Death(){
		//we should do something fancy here, but i'm just going to reload the level for now
		Application.LoadLevel(Application.loadedLevelName);
	}
}
