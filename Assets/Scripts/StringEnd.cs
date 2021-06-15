using System;
using UnityEngine;

namespace UnityTemplateProjects
{
	public abstract class StringEnd : MonoBehaviour
	{
		[field: SerializeField] protected float ForceMultiplier { get; set; }
		protected Rigidbody RigidbodyReference;

		protected LineRenderer DragLineRenderer;
		[field: SerializeField] protected float lineLengthMultiplier;
		[SerializeField] private float lineStartWidth;
		[SerializeField] private float lineEndWidth;
		[SerializeField] private Material lineMaterial;


		protected Vector3 mousePositionInitial;
		protected Vector3 mousePositionCurrent;

		protected virtual void Start()
		{
			RigidbodyReference = GetComponent<Rigidbody>();
		}

		private void OnMouseDown()
		{
			mousePositionInitial = Input.mousePosition;
			DragLineRenderer = gameObject.AddComponent<LineRenderer>();
			DragLineRenderer.material = lineMaterial;
			DragLineRenderer.startWidth = lineStartWidth;
			DragLineRenderer.endWidth = lineEndWidth;
		}

		protected virtual void OnMouseDrag()
		{
			mousePositionCurrent = Input.mousePosition;
		}

		private void OnMouseUp()
		{
			Destroy(DragLineRenderer);

			var direction = mousePositionCurrent - mousePositionInitial;
			var launchDirection = new Vector3(-direction.x, direction.y, 0);
			Launch(launchDirection);
		}

		protected abstract void Launch(Vector3 launchDirection);
	}
}