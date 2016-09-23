using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent (typeof(Camera))]
public class CullingGroup_DistanceSample : MonoBehaviour
{
	public static List<Target> targets = new List<Target> ();
	private CullingGroup group = null;

	[SerializeField]
	DistanceAndColor[] distanceByColor;

	void Awake ()
	{
		group = new CullingGroup ();
		group.targetCamera = GetComponent<Camera> ();
	}

	void Start ()
	{
		group.SetBoundingSpheres (targets.Select (c => c.bound).ToArray ());
		group.SetBoundingDistances (distanceByColor.Select (c => c.distance).ToArray ());

		group.SetDistanceReferencePoint (transform);
		group.onStateChanged += OnChange;
	}

	void OnDestroy ()
	{
		group.onStateChanged -= OnChange;
		group.Dispose ();
	}

	void OnChange (CullingGroupEvent ev)
	{
		targets [ev.index].renderer.material.color = distanceByColor [ev.currentDistance].color;
	}

	public class Target
	{
		private const float size = 1;

		public Target (GameObject obj, Transform transform)
		{
			bound = new BoundingSphere (transform.position, size);
			renderer = obj.GetComponent<Renderer> ();
		}

		public BoundingSphere bound{ get; private set; }

		public Renderer renderer{ get; private set; }
	}

	[System.Serializable]
	public class DistanceAndColor
	{
		public float distance;
		public Color color;
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
}
