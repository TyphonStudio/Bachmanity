using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public static SettingsMenu Instance { get; private set; }

    public AudioMixer audioMixer;

    private void Awake()
    {
        Instance = this;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void SetQuality(int level)
    {
        QualitySettings.SetQualityLevel(level);
    }

    public void SetFullscreen(bool yes)
    {
        Screen.fullScreen = yes;
    }
}
