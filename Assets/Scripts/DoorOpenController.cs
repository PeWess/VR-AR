using System;
using UnityEngine.EventSystems;
using UnityEngine;

public class DoorOpenController : MonoBehaviour, IPointerClickHandler
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("OpenDoor");
    }
}
