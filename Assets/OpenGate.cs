using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenGate : MonoBehaviour
{
    [SerializeField] GameObject leftGate, rightGate;
    [SerializeField] Ease ease = Ease.Linear;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            leftGate.transform.DORotate(new Vector3(0,-90,0), 0.5f).SetEase(ease);
            rightGate.transform.DORotate(new Vector3(0, 90, 0), 0.5f).SetEase(ease);
        }
    }
}
