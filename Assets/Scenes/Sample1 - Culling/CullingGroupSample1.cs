using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CullingGroupSamples.Sample1
{
	[RequireComponent (typeof(Camera))]
	public class CullingGroupSample1 : MonoBehaviour
	{
		public static List<Target> targets = new List<Target> ();
		private CullingGroup group = null;

		void Awake ()
		{
			group = new CullingGroup ();
			group.targetCamera = GetComponent<Camera> ();
		}

		void Start ()
		{
			group.SetBoundingSpheres (targets.Select (c => c.bound).ToArray ());
		}

		void OnEnable ()
		{
			group.onStateChanged += OnChange;
		}

		void OnDisable ()
		{
			group.onStateChanged -= OnChange;
			group.Dispose ();
		}

		void OnChange (CullingGroupEvent ev)
		{
			targets [ev.index].animator.enabled = ev.isVisible;
		}

		public class Target
		{
			private const float size = 1;

			public Target (GameObject obj, Transform transform)
			{
				bound = new BoundingSphere (transform.position, size);
				animator = obj.GetComponent<Animator> ();
			}

			public BoundingSphere bound{ get; private set; }

			public Animator animator{ get; private set; }
		}
	}
}