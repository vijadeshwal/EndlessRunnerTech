using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnergyFillBar : MonoBehaviour
{
    private Image energyFillImage;
    public float fillAmount = 1f;
    public float decreaseRate = 0.1f;
    public float penaltyAmount = 0.35f;

    private void Start()
    {
        energyFillImage = GetComponent<Image>();
        energyFillImage.fillAmount = fillAmount;
    }

    private void Update()
    {
       
        // Decrease the fill amount over time
        if (!GameManager.Instance.isGameOver)
        {
            fillAmount -= decreaseRate * Time.deltaTime;
            energyFillImage.fillAmount = fillAmount;

            // Check if fill amount reaches 0
            if (fillAmount <= 0)
            {
                Debug.Log("GameOver");
                GameManager.Instance.isGameOver = true;
            }
        }
    }

    // Call this function when the player gives the right answer
    public void RightAnswer()
    {
        // Reset the fill amount to 1
        fillAmount = 1f;
        energyFillImage.fillAmount = fillAmount;
    }

    // Call this function when the player gives the wrong answer
    public void WrongAnswer()
    {
        // Decrease the fill amount by penalty amount
        fillAmount -= penaltyAmount;
        fillAmount = Mathf.Max(fillAmount, 0f); // Ensure fill amount doesn't go below 0
        energyFillImage.DOFillAmount(fillAmount, 0.5f); // Smoothly transition the fill amount
    }
}
