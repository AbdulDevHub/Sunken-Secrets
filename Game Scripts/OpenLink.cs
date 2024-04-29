using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Diagnostics;

public class ClickableRawImage : MonoBehaviour, IPointerClickHandler
{
    public string redirectUrl;

    public void OnPointerClick(PointerEventData eventData)
    {
        Process.Start(redirectUrl);
    }
}