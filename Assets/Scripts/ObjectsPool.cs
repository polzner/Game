using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private Ground[] _partTeamplates;
    [SerializeField] Transform _container;
    [SerializeField] private Camera _camera;
    private List<Ground> _partsPool = new List<Ground>();

    private void Start()
    {
        foreach (var item in _partTeamplates)
        {
            var part = Instantiate(item,_container);
            _partsPool.Add(part);
            part.gameObject.SetActive(false);
        }
    }

    public void DeselectOutOfScreen()
    {
        Vector3 pointOutOfScreen = _camera.ViewportToWorldPoint(new Vector2(0, 0));

        foreach (var item in _partsPool)
        {
            if (item.gameObject.activeSelf && item.End.position.x < pointOutOfScreen.x)
            {
                item.gameObject.SetActive(false);
                item.transform.position = _container.position;
            }
        }
    }

    public bool TryGetObject(out Ground part)
    {
        part = null;
        var possibleParts = _partsPool.Where(a => a.gameObject.activeSelf == false).ToList();

        if (possibleParts.Count > 0)
        {
            part = possibleParts[Random.Range(0, possibleParts.Count - 1)];
        }

        return part != null;
    }
}
