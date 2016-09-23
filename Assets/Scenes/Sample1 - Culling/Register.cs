using UnityEngine;
using System.Collections;

namespace CullingGroupSamples.Sample1
{
	public class Register : MonoBehaviour
	{
		void Awake ()
		{
			CullingGroupSample1.Target target = new CullingGroupSample1.Target (gameObject, transform);
			CullingGroupSample1.targets.Add (target);
		}

		void Start ()
		{
			GetComponent<Animator> ().enabled = false;
		}
	}
}

