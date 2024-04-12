using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour
{
    
    private Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponentInParent<Animator>();
    }

    
}