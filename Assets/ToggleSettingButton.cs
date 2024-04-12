using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettingButton : MonoBehaviour
{
    [SerializeField] GameObject _dropItem;
    bool isOpen = false;

    // Function to toggle the visibility of the GameObject
    public void ToggleGameObject()
    {
        isOpen = !isOpen; // Invert the value of isOpen

        // Enable or disable the GameObject based on the value of isOpen
        _dropItem.SetActive(isOpen);
    }
}
