using UnityEngine;
using UnityEngine.UI;

public class OptionsWindow : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioClip _pauseClip;

    private Button _closeBtn;
    private AudioClip _defaultClip;

    private void Awake()
    {
        _closeBtn = GetComponentInChildren<Button>();
        _defaultClip = _music.clip;
        
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _closeBtn.onClick.AddListener(CloseWindow);
        ChangeClip(_pauseClip);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        _closeBtn.onClick.RemoveListener(CloseWindow);
        ChangeClip(_defaultClip);
        Time.timeScale = 1;
    }

    private void CloseWindow()
    {
        gameObject.SetActive(false);
    }

    private void ChangeClip(AudioClip clip)
    {
        _music.clip = clip;
        _music.Play();
    }
}