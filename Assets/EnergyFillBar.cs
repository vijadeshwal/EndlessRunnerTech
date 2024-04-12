using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnergyFillBar : MonoBehaviour
{
    [SerializeField] private Image energyFillImage;
    public float totalFill = 1f;
    private float currentFill;

    private void Start()
    {
        InitializeEnergyFillImage();
        InitializeCurrentFill();
        UpdateUI();
    }

    private void Update()
    {
        UpdateFillBar();
    }

    // Call this function when the player gives the right answer
    public void RightAnswer()
    {
        ResetFillBar();
    }

    // Call this function when the player gives the wrong answer
    public void WrongAnswer()
    {
        ApplyPenalty();
    }

    // Update UI elements like text and fill bar
    private void UpdateUI()
    {
        energyFillImage.fillAmount = currentFill / totalFill;
    }

    private void InitializeEnergyFillImage()
    {
        energyFillImage = GetComponent<Image>();
    }

    private void InitializeCurrentFill()
    {
        currentFill = totalFill;
    }

    private void UpdateFillBar()
    {
        if (currentFill > 0)
        {
            currentFill -= Time.deltaTime / 10;
            UpdateUI();
        }
        else
        {
            HandleEnergyDepletion();
        }
    }

    private void ResetFillBar()
    {
        currentFill = totalFill;
        UpdateUI();
    }

    private void ApplyPenalty()
    {
        currentFill -= 0.35f; // Adjust the penalty time as needed
        UpdateUI();
    }

    private void HandleEnergyDepletion()
    {
        GameManager.Instance.GameisOver();
        gameObject.SetActive(false);
    }
}
