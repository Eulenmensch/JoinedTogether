using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace UnityTemplateProjects
{
	public class ThrusterStringEnd : StringEnd
	{
		[SerializeField] private float thrustTime;
		[SerializeField] private float flightMass;

		private float defaultMass;

		protected override void Start()
		{
			base.Start();
			defaultMass = RigidbodyReference.mass;
		}

		protected override void OnMouseDrag()
		{
			base.OnMouseDrag();
			DragLineRenderer.SetPosition(0, transform.position);
			var mouseDirection = mousePositionCurrent - mousePositionInitial;
			var lineEndPosition = transform.up * mouseDirection.magnitude * lineLengthMultiplier;
			DragLineRenderer.SetPosition(1, transform.position + lineEndPosition);
		}

		protected override void Launch(Vector3 launchDirection)
		{
			GetComponent<MMFeedbacks>().PlayFeedbacks();
			StartCoroutine(ApplyThrustForSeconds(launchDirection));
		}

		private IEnumerator ApplyThrustForSeconds(Vector3 launchDirection)
		{
			var startTime = Time.time;
			RigidbodyReference.mass = flightMass;
			while (Time.time - startTime <= thrustTime)
			{
				RigidbodyReference.AddForce(transform.up * (launchDirection.magnitude * ForceMultiplier), ForceMode.Acceleration);
				yield return null;
			}
			RigidbodyReference.mass = defaultMass;
		}
	}
}