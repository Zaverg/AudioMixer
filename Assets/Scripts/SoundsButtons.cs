using UnityEngine;
using UnityEngine.UI;

public class SoundsButtons : MonoBehaviour
{
    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _slashButton;
    [SerializeField] private Button _coinButton;

    [SerializeField] private AudioSource _jumpAudioSource;
    [SerializeField] private AudioSource _slashAudioSource;
    [SerializeField] private AudioSource _coinAudioSource;

    private void OnEnable()
    {
        _jumpButton.onClick.AddListener(OnJump);
        _slashButton.onClick.AddListener(OnSlash);
        _coinButton.onClick.AddListener(OnCoin);
    }

    private void OnDisable()
    {
        _jumpButton.onClick.RemoveListener(OnJump);
        _slashButton.onClick.RemoveListener(OnSlash);
        _coinButton.onClick.RemoveListener(OnCoin);
    }

    private void OnJump()
    {
        _jumpAudioSource.Play();
    }

    private void OnSlash()
    {
        _slashAudioSource.Play();
    }

    private void OnCoin()
    {
        _coinAudioSource.Play();
    }
}
