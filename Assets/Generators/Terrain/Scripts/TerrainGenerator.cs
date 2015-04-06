using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {
	// terrain references
	public GameObject[] prefabs;

	public float spawnXPos = 0f;
	public float spawnYPos = 0f;
	public int seed = 12345678;

	private GameObject currentEndBlock;

	// camera reference
	GameObject cam;
	// used to check if terrain can be generated depending on the camera position and lastposition
	bool canSpawn = true;
	
	void Start()
	{
		// get the starting game chunk
		// pair camera to camera reference
		cam = GameObject.Find("Main Camera");
		// find the place to start spawning things
		UpdateTerrainSpawnPositions ();
		// deal with the "Start Terrain" Edgecase
		GameObject.Find ("Start Chunk").name = "Last Chunk";
	}
	
	void Update()
	{
		//Terrain Constructor
		if (cam.transform.position.x >= spawnXPos-5 && canSpawn == true)
		{
			// turn off spawning until ready to spawn again
			canSpawn = false;
			// we choose the random number that will determine what terrain is spawned
			//randomChoice = Random.Range(1, 10);
			// SpawnTerrain is called and passed the randomchoice number
			SpawnTerrain(0);
		}


	}
	
	// spawn terrain based on the rand int passed by the update method
	void SpawnTerrain(int rand)
	{
		UpdateChunkNames ();
		var chunkPtr = Instantiate(prefabs[0],
		new Vector3(spawnXPos, spawnYPos, 0), Quaternion.Euler(0, 0, 0));
		chunkPtr.name = "Last Chunk";
		// same as start spawn position as starting terrain
		// is the same length as the rest of the terrain prefabs
		// Whenever a chunk is created, we want to destroy a chunk as well.
		//update the new spawn positions
		UpdateTerrainSpawnPositions();
		//DestroyChunks ();
		// script is now ready to spawn more terrain
		canSpawn = true;
	}
	void UpdateTerrainSpawnPositions(){
		var chunk = GameObject.FindGameObjectWithTag ("End Block");
		spawnXPos = chunk.transform.position.x;
		spawnYPos = chunk.transform.position.y;
		chunk.tag = "Untagged";
	}
	void UpdateChunkNames(){
		//deadChunk->edgeChunk->previousChunk->currentChunk->nextChunk->lastChunk
		if(GameObject.Find ("Dead Chunk") != null)
			Destroy (GameObject.Find ("Dead Chunk"));
		if (GameObject.Find ("Edge Chunk") != null)
			GameObject.Find ("Edge Chunk").name = "Dead Chunk";
		if (GameObject.Find ("Previous Chunk") != null)
			GameObject.Find ("Previous Chunk").name = "Edge Chunk";
		if (GameObject.Find ("Current Chunk") != null)
			GameObject.Find ("Current Chunk").name = "Previous Chunk";
		if (GameObject.Find ("Next Chunk") != null)
			GameObject.Find ("Next Chunk").name = "Current Chunk";
		if (GameObject.Find ("Last Chunk") != null)
			GameObject.Find ("Last Chunk").name = "Next Chunk";
	}
		
}