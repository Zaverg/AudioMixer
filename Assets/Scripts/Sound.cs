using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    private const string MasterVolumeParam = "MasterVolume";
    private const string BackgroundVolumeParam = "BackGroundVolume";
    private const string UIVolumeParam = "UIVolume";
    private const float LogarithmicScaleFactor = 20f;
    private const float MinDecibels = -80;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _backgroundVolumeSlider;
    [SerializeField] private Slider _uiVolumeSlider;

    [SerializeField] private AudioMixerGroup _masterMixerGroup;
    [SerializeField] private AudioMixerGroup _backgroundMixerGroup;
    [SerializeField] private AudioMixerGroup _uiMixerGroup;

    private void OnEnable()
    {
        _masterVolumeSlider.onValueChanged.AddListener(ChangeMasterVolume);
        _backgroundVolumeSlider.onValueChanged.AddListener(ChangeBackGroundVolume);
        _uiVolumeSlider.onValueChanged.AddListener(ChangeUIVolume);
    }

    private void OnDisable()
    {
        _masterVolumeSlider.onValueChanged.RemoveListener(ChangeMasterVolume);
        _backgroundVolumeSlider.onValueChanged.RemoveListener(ChangeBackGroundVolume);
        _uiVolumeSlider.onValueChanged.RemoveListener(ChangeUIVolume);
    }

    private void ChangeMasterVolume(float volume)
    {
        _masterMixerGroup.audioMixer.SetFloat(MasterVolumeParam, ConvertToDecibels(volume));
    }

    private void ChangeBackGroundVolume(float volume)
    {
        _masterMixerGroup.audioMixer.SetFloat(BackgroundVolumeParam, ConvertToDecibels(volume));
    }

    private void ChangeUIVolume(float volume)
    {
        _masterMixerGroup.audioMixer.SetFloat(UIVolumeParam, ConvertToDecibels(volume));
    }

    private float ConvertToDecibels(float volume)
    {
        if (volume == 0)
            return Mathf.Log10(MinDecibels) * LogarithmicScaleFactor;

        return Mathf.Log10(volume) * LogarithmicScaleFactor;
    }
}
