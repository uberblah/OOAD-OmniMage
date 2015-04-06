using UnityEngine;
using System.Collections;

public class TreeGenerator : MonoBehaviour {
	// terrain references
	public GameObject[] shortTerrain;
	public GameObject[] mediumTerrain;
	public GameObject[] longTerrain;
	
	// starting position for terrain, number found from tweaking in the editor
	public float startSpawnPosition = 11.59f;
	// y position that all terrain will be spawned
	// my terrain is all joined at the same level
	// you can change this if here and the spawn method
	// if you need terrain at different heights
	public int spawnYPos = 0;
	public int chunkCount = 0;
	
	// random number that is used for selecting the terrain
	int randomChoice;
	// keep track of the last position terrain was generated
	float lastPosition;
	// camera reference
	GameObject cam;
	// used to check if terrain can be generated depending on the camera position and lastposition
	bool canSpawn = true;
	
	void Start()
	{
		// make the lastposition start at start spawn position
		lastPosition = startSpawnPosition;
		// pair camera to camera reference
		cam = GameObject.Find("Main Camera");
	}
	
	void Update()
	{
		// if the camera is farther than the number last position minus 16 terrain is spawned
		// a lesser number may make the terrain 'pop' into the scene too early
		// showing the player the terrain spawning which would be unwanted
		if (cam.transform.position.x >= lastPosition - 16 && canSpawn == true)
		{
			// turn off spawning until ready to spawn again
			canSpawn = false;
			// we choose the random number that will determine what terrain is spawned
			randomChoice = Random.Range(1, 10);
			// SpawnTerrain is called and passed the randomchoice number
			SpawnTerrain(randomChoice);
		}
	}
	
	// spawn terrain based on the rand int passed by the update method
	void SpawnTerrain(int rand)
	{
		if (rand >= 1 && rand <= 5 )
		{
			Instantiate(shortTerrain[Random.Range(0,shortTerrain.Length)],
			new Vector3(lastPosition, spawnYPos, 0), Quaternion.Euler(0, 0, 0));
			// same as start spawn position as starting terrain
			// is the same length as the rest of the terrain prefabs
			lastPosition += 5.6f;
		}
		
		if (rand >= 5 && rand <= 10)
		{
			Instantiate(mediumTerrain[Random.Range(0,mediumTerrain.Length)], 
            new Vector3(lastPosition, spawnYPos, 0), Quaternion.Euler(0, 0, 0));
			lastPosition += 11.2f;
		}
		
		if (rand >= 11 && rand <= 11)
			// the platform terrain is more difficult to traverse
			// so we will lessen the chances of it spawning
		{
			Instantiate(longTerrain[Random.Range(0,longTerrain.Length)], 
            new Vector3(lastPosition, spawnYPos, 0), Quaternion.Euler(0, 0, 0));
			lastPosition += 22.4f;
		}
		
		// script is now ready to spawn more terrain
		canSpawn = true;
	}
}
