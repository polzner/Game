using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private float offsetX = 0;
    private float offsetY = 0;

    private void Update()
    {
        offsetX += Input.GetAxis("Mouse X");
        offsetY -= Input.GetAxis("Mouse Y");
        offsetY = Mathf.Clamp(offsetY,-30f,30f);

        _camera.transform.rotation = Quaternion.AngleAxis(offsetX*3, Vector3.up) * Quaternion.AngleAxis(offsetY * 3, Vector3.right);
    }
}
