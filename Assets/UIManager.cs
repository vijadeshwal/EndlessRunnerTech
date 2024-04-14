using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUIPanel;
    [SerializeField] GameObject inGameUIPanel;
    public GameObject mainMenuUIPanel;
    [SerializeField] TextMeshProUGUI _gCurrentScoreText;
    [SerializeField] TextMeshProUGUI _gBestScoreText;
    [SerializeField] GameObject _gBg;
    [HideInInspector] public GameObject fadeInOutBg;
    

    public void ShowGameOverUI()
    {       
        _gBg.SetActive(true);
        inGameUIPanel.SetActive(false);
        gameOverUIPanel.SetActive(true);

        SetScoreOnGameOver();
    }

    private void SetScoreOnGameOver()
    {
        int _bestScore = PlayerPrefs.GetInt("BestScore",0);

        _gCurrentScoreText.text = "Score: "+ GameManager.Instance.currentScore;

        if(GameManager.Instance.currentScore >= _bestScore)
        {
            _bestScore = GameManager.Instance.currentScore;
            PlayerPrefs.SetInt("BestScore", _bestScore);
        }
        _gBestScoreText.text = "Best: "+_bestScore;
    }

    public void ShowInGameUI()
    {
        Invoke("DisableFadeImage", 0.5f);
        _gBg.SetActive(false);
        mainMenuUIPanel.SetActive(false);
        inGameUIPanel.SetActive(true);
    }

    public void ShowMainMenuUIPanel()
    {
        mainMenuUIPanel.SetActive(true);
        _gBg.SetActive(true);
    }

    private void DisableFadeImage()
    {
        fadeInOutBg.SetActive(false);
    }
}
