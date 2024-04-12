using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNonCollectable : MonoBehaviour
{
    [SerializeField] GameObject[] nonCollectableItems;

    private void Start()
    {
        int randomValue = Random.Range(0, nonCollectableItems.Length+1);

        if(randomValue <= nonCollectableItems.Length-1)
        {
            Instantiate(nonCollectableItems[randomValue], transform.position, transform.rotation);
        }        
        else
        {
            // do nothing
        }
    }
}
