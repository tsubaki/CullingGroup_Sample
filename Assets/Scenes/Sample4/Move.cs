using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	NavMeshAgent agent;

	[SerializeField]
	float speed = 2, rotationSpeed = 2;

	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update ()
	{
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		transform.Rotate (new Vector3 (0, x * rotationSpeed, 0));

		agent.Move (transform.forward * y * Time.deltaTime * speed);
	}
}
