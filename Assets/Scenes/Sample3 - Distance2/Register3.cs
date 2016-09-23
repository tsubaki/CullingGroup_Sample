using UnityEngine;
using System.Collections;

public class Register3 : MonoBehaviour
{
	BoundingSphere bound;

	[SerializeField] CullingGroup_DistanceSample2 cgd;

	private int id;

	void Awake ()
	{
		id = cgd.RegisterObject (transform);
	}
	
	// Update is called once per frame
	void Update ()
	{
		cgd.UpdateNewPosition (id, transform.position);
	}
}
