using UnityEngine;

namespace UnityTemplateProjects
{
	public class GolfStringEnd : StringEnd
	{
		protected override void Launch(Vector3 launchDirection)
		{
			RigidbodyReference.AddForce(launchDirection * ForceMultiplier, ForceMode.VelocityChange);
		}

		protected override void OnMouseDrag()
		{
			base.OnMouseDrag();
			DragLineRenderer.SetPosition(0, transform.position);
			var mouseDirection = mousePositionCurrent - mousePositionInitial;
			var lineEndPosition = new Vector3(-mouseDirection.x, mouseDirection.y, 0f) * lineLengthMultiplier;
			DragLineRenderer.SetPosition(1, transform.position + lineEndPosition);
		}
	}
}