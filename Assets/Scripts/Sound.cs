using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _master;
    [SerializeField] private AudioMixerGroup _backGround;
    [SerializeField] private AudioMixerGroup _ui;

    private float _masterVolume;
    private bool _enable;

    public void Mute(bool enable)
    {
        _enable = enable;

        if (enable)
            _master.audioMixer.SetFloat("MasterVolume", -80);
        else
            _master.audioMixer.SetFloat("MasterVolume", _masterVolume);
    }

    public void ChangeMasterVolume(float volume)
    {
        _masterVolume = Mathf.Log10(volume) * 20;

        if (_enable == false)
            _master.audioMixer.SetFloat("MasterVolume", _masterVolume);
    }

    public void ChangeBackGroundVolume(float volume)
    {
        _master.audioMixer.SetFloat("BackGroundVolume", Mathf.Log10(volume) * 20);
    }

    public void ChangeUIVolume(float volume)
    {
        _master.audioMixer.SetFloat("UIVolume", Mathf.Log10(volume) * 20);
    }
}
