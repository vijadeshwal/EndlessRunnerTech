using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] RectTransform _rectTransform;

    private void Start()
    {
        var safeArea = Screen.safeArea;
        var anchormin = safeArea.position;
        var anchormax = safeArea.position + safeArea.size;
        anchormin.x /= _canvas.pixelRect.width;
        anchormin.y /= _canvas.pixelRect.height;
        anchormax.x /= _canvas.pixelRect.width;
        anchormax.y /= _canvas.pixelRect.height;

        _rectTransform.anchorMin = anchormin;
        _rectTransform.anchorMax = anchormax;
    }
}
