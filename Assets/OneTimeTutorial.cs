using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeTutorial : MonoBehaviour
{
    int count = 0;
    [SerializeField] GameObject tutPanel;
    bool isTutOn = false;

    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("TutCount", 0);
        

        tutPanel.SetActive(false);

        if(count == 0)
        {
            tutPanel.SetActive(true);
            count++;
            PlayerPrefs.SetInt("TutCount", count);
            isTutOn=true;
        }
    }


}
