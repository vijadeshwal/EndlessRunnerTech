using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float randomPosX = Random.Range(-0.6f, 1.3f);// Original Values (-0.6f,1.8f);
        transform.position = new Vector3(randomPosX, transform.position.y, transform.position.z);
    }

}
