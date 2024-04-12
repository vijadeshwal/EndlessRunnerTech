using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollectingShowIcons : MonoBehaviour
{
    [SerializeField] Image[] icons;

    private void Start()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].DOFade(0.3f, 0);
        }
    }

    public void ActivateIcons(int iconIndex)
    {
        if(icons.Length > iconIndex + 1 )
        {
            icons[iconIndex].DOFade(1, 0.2f);
            Debug.Log("1 :- " + iconIndex);
        }
        
    }

    public void FadeOutIcon()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].DOFade(0.3f, 0);
            
        }
        Debug.Log(" Fade out ");
    }
}
