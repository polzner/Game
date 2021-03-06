using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacer : MonoBehaviour
{
    [SerializeField] private Transform _sphere;
    [SerializeField] private ObjectsPool _pool;

    private float _distanceToSpawn = 15;
    private Ground _currentPart;

    private void Start()
    {
        PlaceFirstPart();
    }

    private void PlaceFirstPart()
    {
        _pool.TryGetObject(out Ground part);
        part.gameObject.SetActive(true);
        part.transform.position = Vector3.zero;
        _currentPart = part;
    }

    public void Restart()
    {
        _pool.ResetPool();
        PlaceFirstPart();
    }

    private void LateUpdate()
    {
        if (_currentPart.transform.position.x - _sphere.position.x < _distanceToSpawn)
        {
            SpawnPart();
            _pool.DeselectOutOfScreen();
        }
    }

    private void SpawnPart()
    {
        if(_pool.TryGetObject(out Ground newPart))
        {
            newPart.gameObject.SetActive(true);
            newPart.transform.position = _currentPart.End.position - newPart.Begin.localPosition;
            _currentPart = newPart; 
        }
    }    
}
