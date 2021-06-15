using System;
using UnityEngine;

namespace UnityTemplateProjects
{
	public class OutOfBounds : MonoBehaviour
	{
		[SerializeField] private float outOfBoundsHeight;

		private void OnTriggerExit(Collider other)
		{
			if (other.GetComponent<StringEnd>() != null)
			{
				GameManager.ReloadLevel();
			}
		}
	}
}