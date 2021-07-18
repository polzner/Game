using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotate : MonoBehaviour
{
    private void Update()
    {
        var offsetX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * offsetX * 3);
    }
}
