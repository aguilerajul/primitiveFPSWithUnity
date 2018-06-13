using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonsSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonClickAudio;

    private AudioSource _audioSource;
    private Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        _audioSource.clip = _buttonClickAudio;
        _audioSource.playOnAwake = false;

        _button.onClick.AddListener(() => PlaySound());
    }


    void PlaySound()
    {
        _audioSource.PlayOneShot(_buttonClickAudio);
    }

}
