using UnityEngine;
using System.Collections;

namespace CullingGroupSamples.Sample2
{
	public class Register2 : MonoBehaviour
	{
		void Awake ()
		{
			CullingGroup_DistanceSample.targets.Add (new CullingGroup_DistanceSample.Target (gameObject, transform));
		}
	}
}
