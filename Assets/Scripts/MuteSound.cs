using UnityEngine;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{
    [SerializeField] private AudioListener _audioListener;

    [SerializeField] private Toggle _toggle;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(OnMute);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(OnMute);
    }

    private void OnMute(bool enable)
    {
        _audioListener.enabled = !enable;
    }
}
