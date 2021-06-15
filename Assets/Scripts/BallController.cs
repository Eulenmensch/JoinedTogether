using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody ball;
    [SerializeField] private float launchForce;

    private Vector3 mouseStartPosition;
    private Vector3 mouseCurrentPosition;

    private Vector3 mOffset;
    private float mZCoord;

    private FixedJoint fixedJoint;

    void Update()
    {
        GolfControls();
    }

    // void OnMouseDown()
    // {
    //     mZCoord = Camera.main.WorldToScreenPoint(
    //         gameObject.transform.position).z;
    //     // Store offset = gameobject world pos - mouse world pos
    //     mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    //     transform.position = GetMouseAsWorldPoint() + mOffset;
    //     fixedJoint = ball.gameObject.AddComponent<FixedJoint>();
    //     fixedJoint.connectedBody = GetComponent<Rigidbody>();
    // }
    // private Vector3 GetMouseAsWorldPoint()
    // {
    //     // Pixel coordinates of mouse (x,y)
    //     Vector3 mousePoint = Input.mousePosition;
    //     // z coordinate of game object on screen
    //     mousePoint.z = mZCoord;
    //     // Convert it to world points
    //     return Camera.main.ScreenToWorldPoint(mousePoint);
    // }
    // void OnMouseDrag()
    // {
    //     transform.position = GetMouseAsWorldPoint() + mOffset;
    // }
    // private void OnMouseUp()
    // {
    //     Destroy(fixedJoint);
    // }

    private void GolfControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            mouseCurrentPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            var direction = mouseCurrentPosition - mouseStartPosition;
            var launchDirection = new Vector3(-direction.x, direction.y, 0);
            ball.AddForce(launchDirection * launchForce, ForceMode.VelocityChange);
        }
    }
}
