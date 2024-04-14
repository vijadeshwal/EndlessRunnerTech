using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] GameObject virtualCameraMain, virtualCameraIdle;


    // Start is called before the first frame update
    void Start()
    {
        virtualCameraIdle.SetActive(true);
        virtualCameraMain.SetActive(false);
    }

    public void ActivateMainCamera()
    {
        virtualCameraIdle.SetActive(false);
        virtualCameraMain.SetActive(true);
    }
}
