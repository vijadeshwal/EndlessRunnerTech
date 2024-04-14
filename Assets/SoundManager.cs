using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for manipulating UI elements like button icons

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _uiClickClip;
    [SerializeField] private AudioClip _goodCollectClip;
    [SerializeField] private AudioClip _badCollectClip;
    [SerializeField] private AudioClip _gameOverClip;
    [SerializeField] private Sprite soundOnIcon;
    [SerializeField] private Sprite soundOffIcon;
    [SerializeField] private Button soundToggleButton, soundBtn; // Assign this button in the inspector

    void Awake()
    {
        // Ensure that there's only one instance of SoundManager
        if (Instance == null)
        {
            Instance = this;
        }
        LoadAudioSettings();
    }

    public void ToggleSound()
    {
        // Toggle the audio source enabled state
        _audioSource.mute = !_audioSource.mute;

        // Save the new state
        PlayerPrefs.SetInt("SoundEnabled", _audioSource.mute ? 0 : 1);
        PlayerPrefs.Save();

        // Update the button icon based on the audio state
        UpdateSoundIcon();
    }

    private void UpdateSoundIcon()
    {
        if (soundToggleButton != null)
        {
            soundToggleButton.image.sprite = _audioSource.mute ? soundOffIcon : soundOnIcon;
            soundBtn.image.sprite = _audioSource.mute ? soundOffIcon : soundOnIcon;
        }
    }

    private void LoadAudioSettings()
    {
        // Load the sound setting from PlayerPrefs
        // Default to 1 (enabled) if the key does not exist
        int soundEnabled = PlayerPrefs.GetInt("SoundEnabled", 1);

        // Set the audio source mute state based on saved preference
        _audioSource.mute = soundEnabled == 0;

        // Update the button icon based on the loaded setting
        UpdateSoundIcon();
    }

    // Method to play UI click sound
    public void PlayUIClick()
    {
        PlaySound(_uiClickClip);
    }

    // Method to play good collect sound
    public void PlayGoodCollect()
    {
        PlaySound(_goodCollectClip);
    }

    // Method to play bad collect sound
    public void PlayBadCollect()
    {
        PlaySound(_badCollectClip);
    }

    // Method to play game over sound
    public void PlayGameOver()
    {
        PlaySound(_gameOverClip);
    }

    // Helper method to play a given audio clip
    private void PlaySound(AudioClip clip)
    {
        if (clip != null && !_audioSource.mute)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}
