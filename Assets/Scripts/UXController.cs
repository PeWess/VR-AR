using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UXController : MonoBehaviour
{
    private ARPlaneManager _planeManager;
    public GameObject _image;
    
    void Start()
    {
        _planeManager = GetComponent<ARPlaneManager>();
        _planeManager.planesChanged += PlanesChanged;
    }

    private void PlanesChanged(ARPlanesChangedEventArgs obj)
    {
        foreach (var item in obj.added)
        {
            _image.SetActive(false);
            break;
        }
    }
}
