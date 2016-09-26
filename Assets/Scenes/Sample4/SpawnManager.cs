using UnityEngine;
using System.Collections;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
	private CullingGroup group = null;

	[SerializeField]
	Spawn[] spawnPoints;

	// Use this for initialization
	void Start ()
	{
		group = new CullingGroup ();
		group.targetCamera = Camera.main;

		group.SetBoundingSpheres (
			spawnPoints
			.Select (c => new BoundingSphere (c.transform.position, 1))
			.ToArray ());

		group.SetDistanceReferencePoint (group.targetCamera.transform);
		group.onStateChanged += OnChange;
	}

	void OnDestroy ()
	{
		group.Dispose ();
	}

	void OnChange (CullingGroupEvent ev)
	{
		spawnPoints [ev.index].enabled = !ev.isVisible;
	}
}
