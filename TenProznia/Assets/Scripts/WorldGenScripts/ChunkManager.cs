using UnityEngine;
using System.Collections.Generic;

public class ChunkManager : MonoBehaviour {
    /// Variables
    public GameObject[] chunkPrefabs;
    private Transform playerTransform;

    private float spawnZ = 0F;
    private float chunkLength = 512F;
    private int chunksOnScreen = 2;
    private float safeZone = 256F;
    private int previousPrefabIndex = 0;

    private List<GameObject> activeChunks;

      /// <summary>
     /// Upon Start, get game objects and spawn chunks
    /// </summary>
    void Start() {
        activeChunks = new List<GameObject>();                                   //List of active chunks in scene
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; //Validate for the "player"

        for (int i = 0; i < chunksOnScreen; i++) { 
            if (i < 2) {
                SpawnChunk(0);
            } else {
                SpawnChunk();
            }
        }
    }

      /// <summary>
     /// Update chunks dependant on framerate
    /// </summary>
    void Update() {
        if (playerTransform.position.z - safeZone > (spawnZ - chunksOnScreen * chunkLength)) { //If player position (- safeZone) is more than the formula, generates ground chunks> 
            SpawnChunk();
            DeleteChunk();
        }
    }

       /// CHUNK: SPAWN
      /// <summary>
     /// Determine when and where to spawn chunks
    /// </summary>
    void SpawnChunk(int prefabIndex = -1) {  //If prefabIndex isn't defined, = -1
        GameObject gameObj;
        if (prefabIndex == -1) {
            gameObj = Instantiate(chunkPrefabs[RandomPrefabIndex()]) as GameObject; //Instatiate a random prefab
        } else {
            gameObj = Instantiate(chunkPrefabs[prefabIndex]) as GameObject; //Instantiate prefab
        }

        gameObj.transform.SetParent(transform);                 //Set the gameobjects position
        gameObj.transform.position = Vector3.forward * spawnZ; //Set the gameobjects nextposition
        spawnZ += chunkLength;                                //Set where the next prefab will spawn
        activeChunks.Add(gameObj);                           //Add the prefab to the list of active Chunks
    }

       /// CHUNK: DELETE
      /// <summary>
     /// Delete the oldest existing chunk
    /// </summary>
    private void DeleteChunk() {
        Destroy(activeChunks[0]);
        activeChunks.RemoveAt(0);
    }

       /// RANDOM PREFAB INDEX
      /// <summary>
     /// Randomly determine which prefab to generate next
    /// </summary>
    private int RandomPrefabIndex() {
        if (chunkPrefabs.Length <= 1) { return 0; }

        int randomIndex = previousPrefabIndex;                    //If prefab chosen is the = to the previous prefab,
        while (randomIndex == previousPrefabIndex) {             //It loops again until a different prefab is selcted
            randomIndex = Random.Range(0, chunkPrefabs.Length); //So, generation loops until randomIndex != previousPrefabIndex
        }

        previousPrefabIndex = randomIndex; //set the randomly selected index is the previous prefabs index, and randomIndex is empty. 
        return randomIndex;
    }
}
