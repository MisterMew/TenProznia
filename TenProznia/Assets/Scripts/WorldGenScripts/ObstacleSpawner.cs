using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
	public GameObject[] obstaclePrefabs;
	public Transform[] spawnPoints;

	 // Obstacles spawn with a slight delay between them, this is to prevent
	// stuttering on lower end systems (instead of spawning everything at once)
	[SerializeField, Range(0.0f, 0.5f), Tooltip("Change rate at which obstacles spawn")]
	private float obstacleSpawnDelay = 0.1f;

	private Coroutine spawnRoutine;

	private void Start() {
		
	}

	private void OnEnable() {
		spawnRoutine = StartCoroutine(SpawnObstacles());
	}

	private void OnDisable() {
		StopCoroutine(spawnRoutine);
	}

	/// SPAWN OBSTACLES
	/// <summary>
	/// Spawns random obstacles at random spawn points, up to <paramref name="obstacleCount"/>
	/// </summary>
	private IEnumerator SpawnObstacles(int obstacleCount = 9999) {
		// Make a copy of the spawn points, later code will be modifying this list!
		List<Transform> tempSpawnPoints = spawnPoints.ToList();

		// Check if obstacle should be spawned
		while (tempSpawnPoints.Count > 0 && obstacleCount > 0) {
			// Get all the randoms
			int randomSpawnPoint = Random.Range(0, tempSpawnPoints.Count);
			int randomObstacle = Random.Range(0, obstaclePrefabs.Length);

			// Create that obsta-cool~
			Instantiate(
				obstaclePrefabs[randomObstacle],
				tempSpawnPoints[randomSpawnPoint].position,
				Quaternion.identity
			); // Quaternian.identity to ignore rotations

			// Delay
			yield return new WaitForSeconds(obstacleSpawnDelay);

			// Remove that spawn point from list of potential spawn points
			tempSpawnPoints.RemoveAt(randomSpawnPoint);
		}
	}
}
