using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Director;

[RequireComponent (typeof(Animator))]
public class PlaySingleAnimation : MonoBehaviour
{
	[SerializeField]
	AnimationClip clip;

	void Start ()
	{
		GetComponent<Animator> ().Play (AnimationClipPlayable.Create (clip));
	}
}
