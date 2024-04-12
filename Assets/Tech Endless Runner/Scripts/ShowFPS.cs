using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowFps : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    private float deltaTime = 0.0f;

    private int lastFramIndex;
    private float[] framDeltaTimeArray;

    private void Awake()
    {
        framDeltaTimeArray = new float[50];
    }

    void Update()
    {
        framDeltaTimeArray[lastFramIndex] = Time.deltaTime;
        lastFramIndex = (lastFramIndex + 1) % framDeltaTimeArray.Length;

        fpsText.text = "FPS : " + Mathf.RoundToInt(CalculateFPS()).ToString();
    }

    private float CalculateFPS()
    {
        float total = 0f;
        foreach (float deltaTime in framDeltaTimeArray)
        {
            total += deltaTime;
        }

        return framDeltaTimeArray.Length / total;
    }
}
