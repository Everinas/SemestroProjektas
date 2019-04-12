//using UnityEngine;
//using System.Collections;

//public class Follow : MonoBehaviour
//{

//    public bool lockCursor;
//    public float mouseSensitivity = 10;
//    public Transform target;
//    public float dstFromTarget = 2;
//    public Vector2 pitchMinMax = new Vector2(-40, 85);

//    public float rotationSmoothTime = .12f;
//    Vector3 rotationSmoothVelocity;
//    Vector3 currentRotation;

//    float yaw;
//    float pitch;

//    void Start()
//    {
//        if (lockCursor)
//        {
//            Cursor.lockState = CursorLockMode.Locked;
//            Cursor.visible = false;
//        }
//    }

//    void LateUpdate()
//    {
//        var d = Input.GetAxis("Mouse ScrollWheel");
//        if (d > 0 && dstFromTarget > 1)
//        {
//            dstFromTarget = dstFromTarget - 1;
//        }
//        if (d < 0 && dstFromTarget < 5 )
//        {
//            dstFromTarget = dstFromTarget + 1;
//        }
//            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
//        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
//        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

//        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
//        transform.eulerAngles = currentRotation;

//        transform.position = target.position - transform.forward * dstFromTarget;

//    }

//}