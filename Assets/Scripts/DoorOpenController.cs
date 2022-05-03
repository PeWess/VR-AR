using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DoorOpenController : MonoBehaviour, IPointerClickHandler
{
    private Animator _animator;
    private ARPlaneManager _planeManager;
    private ARPointCloudManager _pointManager;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _planeManager = FindObjectOfType<ARPlaneManager>();
        _pointManager = FindObjectOfType<ARPointCloudManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("OpenDoor");

        foreach (var plane in _planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        _planeManager.enabled = false;

        foreach (var point in _pointManager.trackables)
        {
            point.gameObject.SetActive(false);
        }
        _pointManager.enabled = false;
    }
}