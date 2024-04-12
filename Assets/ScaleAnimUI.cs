using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleAnimUI : MonoBehaviour
{
    [SerializeField] Ease _easeType = Ease.Linear;
    CanvasGroup _canvasGroup;
    [SerializeField] GameObject _parentObject;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }


    private void OnEnable()
    {
        gameObject.transform.DOScale(0,0);
        gameObject.transform.DOScale(1f,0.5f).SetEase(_easeType);
    }

    public void ClosePanel()
    {
        gameObject.transform.DOScale(0f, 0.3f).SetEase(_easeType).OnComplete(() => { _parentObject.gameObject.SetActive(false); });
        
    }
}
