using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelfDestructor : MonoBehaviour
{
	[SerializeField, Range(0.0f, 100.0f), Tooltip("Distance behind player before getting destroyed")]
	private float maxDistanceBehindPlayer = 25.0f;

	private Transform playerTransform;

	private const float TimeBetweenChecks = 1.0f; // seconds

	private void Start() {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		StartCoroutine(CheckDistanceBehindPlayer());
	}

	private IEnumerator CheckDistanceBehindPlayer() {
		while(isActiveAndEnabled) {
			// Check distance behind player
			if((playerTransform.position.z - transform.position.z) > maxDistanceBehindPlayer) {
				gameObject.SetActive(false);
				break;
			}

			// wait some time before checking again, for performance reasons (probably /shrug)
			yield return new WaitForSeconds(TimeBetweenChecks);
		}
	}
}
