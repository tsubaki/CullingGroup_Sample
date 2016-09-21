using UnityEngine;
using System.Collections;

public class Register : MonoBehaviour
{
	void Awake ()
	{
		CullingGroupSample.Target target = new CullingGroupSample.Target (gameObject, transform);
		CullingGroupSample.targets.Add (target);
	}

	void Start ()
	{
		GetComponent<Animator> ().enabled = false;
	}
}
