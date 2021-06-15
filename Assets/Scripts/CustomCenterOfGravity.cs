using System;
using UnityEngine;

namespace UnityTemplateProjects
{
	[RequireComponent(typeof(Rigidbody))]
	public class CustomCenterOfGravity : MonoBehaviour
	{
		[SerializeField] private Transform centerOfGravityTransform;

		private void Start()
		{
			GetComponent<Rigidbody>().centerOfMass = centerOfGravityTransform.position;
		}
	}
}