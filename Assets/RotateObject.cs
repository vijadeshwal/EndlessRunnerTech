using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 1;
    [SerializeField] Vector3 targetRotation = new Vector3(0, 360, 0);


    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(targetRotation, rotateSpeed, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);

        
    }

}
