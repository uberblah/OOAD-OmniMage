using UnityEngine;
using System.Collections;

public class HeartRender : MonoBehaviour {
	public int currentHealth = 6;

	public Sprite fullHeart;
	public Sprite halfHeart;
	public Sprite emptyHeart;

	public GameObject heartOne;
	public GameObject heartTwo;
	public GameObject heartThree;
	// Update is called once per frame
	void Update () {
		switch (currentHealth){
			case 6:
				heartOne.GetComponent<SpriteRenderer>().sprite = fullHeart;
				heartTwo.GetComponent<SpriteRenderer>().sprite = fullHeart;
				heartThree.GetComponent<SpriteRenderer>().sprite = fullHeart;
				break;
			case 5:
				heartOne.GetComponent<SpriteRenderer>().sprite = fullHeart;
				heartTwo.GetComponent<SpriteRenderer>().sprite = fullHeart;
				heartThree.GetComponent<SpriteRenderer>().sprite = halfHeart;
				break;
			case 4:
				heartOne.GetComponent<SpriteRenderer>().sprite = fullHeart;
				heartTwo.GetComponent<SpriteRenderer>().sprite = fullHeart;
				heartThree.GetComponent<SpriteRenderer>().sprite = emptyHeart;
				break;
			case 3:
				heartOne.GetComponent<SpriteRenderer>().sprite = fullHeart;
				heartTwo.GetComponent<SpriteRenderer>().sprite = halfHeart;
				heartThree.GetComponent<SpriteRenderer>().sprite = emptyHeart;
				break;
			case 2:
				heartOne.GetComponent<SpriteRenderer>().sprite = fullHeart;
				heartTwo.GetComponent<SpriteRenderer>().sprite = emptyHeart;
				heartThree.GetComponent<SpriteRenderer>().sprite = emptyHeart;
				break;
			case 1:
				heartOne.GetComponent<SpriteRenderer>().sprite = halfHeart;
				heartTwo.GetComponent<SpriteRenderer>().sprite = emptyHeart;
				heartThree.GetComponent<SpriteRenderer>().sprite = emptyHeart;
				break;
			default:
				heartOne.GetComponent<SpriteRenderer>().sprite = emptyHeart;
				heartTwo.GetComponent<SpriteRenderer>().sprite = emptyHeart;
				heartThree.GetComponent<SpriteRenderer>().sprite = emptyHeart;
				break;
		}
	}
}
