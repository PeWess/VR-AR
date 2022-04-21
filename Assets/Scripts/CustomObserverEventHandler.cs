using UnityEngine;
using UnityEngine.UI;

public class CustomObserverEventHandler : DefaultObserverEventHandler
{
    [SerializeField]private Image _hint;

    override protected void OnTrackingFound()
    {
        base.OnTrackingFound();
        _hint.enabled = false;
    }
    
    override protected void OnTrackingLost()
    {
        base.OnTrackingLost();
        _hint.enabled = true;
    }
}
