using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{

	[SerializeField]
	GameObject spawnPrefab;

	Coroutine coroutine;

	IEnumerator SpawnCoroutine ()
	{
		Transform player = GameObject.FindGameObjectWithTag ("Player").transform;
		while (true) {
			var obj = GameObject.Instantiate (spawnPrefab, transform.position, Quaternion.identity) as GameObject;

			obj.hideFlags = HideFlags.HideInHierarchy;
			obj.GetComponent<NavMeshAgent> ().SetDestination (player.position);

			GameObject.Destroy (obj, 5);
			yield return new WaitForSeconds (Random.Range (0.2f, 1));
		}
	}

	void OnEnable ()
	{
		coroutine = StartCoroutine (SpawnCoroutine ());
	}

	void OnDisable ()
	{
		StopCoroutine (coroutine);
	}
}
