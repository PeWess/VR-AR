using System;
using System.Security.AccessControl;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class DoorOpenController : MonoBehaviour //, IPointerClickHandler
{
    private Animator _animator;
    private ARPlaneManager _planeManager;
    private ARPointCloudManager _pointManager;
    public static bool _isFaceFound;
    private bool _isDoorOpened;

    public static Text _text;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _planeManager = FindObjectOfType<ARPlaneManager>();
        _pointManager = FindObjectOfType<ARPointCloudManager>();
        _isFaceFound = false;
        _isDoorOpened = false;
        _text = FindObjectOfType<Text>();
        _text.text += "DoorOpenController\n";
    }
/*
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
*/

    private void Update()
    {
        if (!_isDoorOpened && _isFaceFound)
        {
            FaceFound();
        }
    }

    public void FaceFound()
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