using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private Animator playerAnim;

    private int nextCollectableIndex = 0;
    [SerializeField] EnergyFillBar energyFillBar;
    [SerializeField] CollectingShowIcons showIcons;
    private float currentEnergy = 0f;

   

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collect"))
        {
            Collectables collectables = other.GetComponent<Collectables>();
            if(nextCollectableIndex == collectables.collectableIndex)
            {
                collectables.DisableItem();
                nextCollectableIndex++;

                showIcons.ActivateIcons(nextCollectableIndex - 1 );

                SoundManager.Instance.PlayGoodCollect();

                if(nextCollectableIndex >= 5)
                {
                    collectables.DisableItem();

                    Debug.Log("2");
                    IncreaseEnergy();
                    
                }
            }
        }

        if(other.gameObject.CompareTag("NotCollect"))
        {
            SoundManager.Instance.PlayBadCollect();
            other.gameObject.SetActive(false);
            energyFillBar.WrongAnswer();
            Debug.LogWarning("Danger Touch ");
        }

    }

    public void IncreaseEnergy()
    {
        Debug.Log("3");
        energyFillBar.RightAnswer();
        nextCollectableIndex = 0;
        showIcons.FadeOutIcon();
    }

   
}