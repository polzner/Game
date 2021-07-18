using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _turnSpeed = 10;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidBody.velocity = new Vector3(_speed, _rigidBody.velocity.y, _rigidBody.velocity.z);

        if (Input.GetKey(KeyCode.W))
        {
            _rigidBody.AddForce(Vector3.forward* _turnSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidBody.AddForce(-Vector3.forward * _turnSpeed);
        }
    }
}
