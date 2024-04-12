using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] string collectableName;
    public int collectableIndex = 0;

    [SerializeField] GameObject nameText;

    public  void DisableItem()
    {
        //DOTween.Kill(gameObject, true);
        gameObject.transform.parent.gameObject.SetActive(false);

        if (nameText != null)
        {
            nameText.SetActive(false);
        }
    }
}
