using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    ARRaycastManager _raycastManager;
    private Vector2 _touchPos;

    public GameObject _scenePrefab;

    static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
        _scenePrefab.SetActive(false);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touchPos = Input.GetTouch(0).position;

            if (_raycastManager.Raycast(_touchPos, _hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = _hits[0].pose;
                
                _scenePrefab.SetActive(true);
                _scenePrefab.transform.position = hitPose.position;
                LookAtPlayer(_scenePrefab.transform);
            }
        }
    }

    private void LookAtPlayer(Transform scene)
    {
        var lookDirection = Camera.main.transform.position - scene.position;
        lookDirection.y = 0;
        scene.rotation = Quaternion.LookRotation(lookDirection);
    }
}
