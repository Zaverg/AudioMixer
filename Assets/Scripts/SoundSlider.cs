using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    private const float LogarithmicScaleFactor = 20f;
    private const float MinDecibels = -80;

    [SerializeField] private AudioMixerParams _mixerParams;
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        _mixerGroup.audioMixer.SetFloat(_mixerParams.ToString(), ConvertToDecibels(volume));
    }

    private float ConvertToDecibels(float volume)
    {
        if (volume == 0)
            return MinDecibels;

        return Mathf.Log10(volume) * LogarithmicScaleFactor;
    }
}
