using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

[RequireComponent (typeof(Camera))]
public class CullingGroup_DistanceSample2 : MonoBehaviour
{
	private CullingGroup group = null;

	const int maxRegisterCount = 1;

	int currentID = 0;
	private BoundingSphere[] bounds = new BoundingSphere[maxRegisterCount];
	private Renderer[] renderers = new Renderer[maxRegisterCount];

	public DistanceAndColor[] distanceByColor;

	void Start ()
	{
		group = new CullingGroup ();
		group.targetCamera = GetComponent<Camera> ();

		group.SetBoundingSpheres (bounds);
		group.SetBoundingDistances (distanceByColor.Select (c => c.distance).ToArray ());
		group.SetDistanceReferencePoint (transform.position);

		group.onStateChanged += OnChange;

	}

	void OnChange (CullingGroupEvent ev)
	{
		renderers [ev.index].material.color = distanceByColor [ev.currentDistance].color;
	}

	void OnDestroy ()
	{
		group.Dispose ();
		group = null;
	}

	public int RegisterObject (Transform transform)
	{
		bounds [currentID] = new BoundingSphere (transform.position, 1);
		renderers [currentID] = transform.GetComponent<Renderer> ();
		return currentID++;
	}

	public void UpdateNewPosition (int id, Vector3 pos)
	{
		bounds [id].position = pos;
	}

#if UNITY_EDITOR
	void OnDrawGizmos ()
	{
		for (int i = 0; i < distanceByColor.Length; i++) {
			var dbc = distanceByColor [i];

			UnityEditor.Handles.color = dbc.color;
			UnityEditor.Handles.CircleCap (0, transform.position, Quaternion.AngleAxis (90, Vector3.right), dbc.distance);
		}
	}
#endif

	[System.Serializable]
	public class DistanceAndColor
	{
		public float distance;
		public Color color;
	}

}
