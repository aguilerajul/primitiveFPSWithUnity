using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameIntro : MonoBehaviour
{
    public float timeToDisplayMessage = 0.5f;
    public float timeToChangeScene = 50f;

    private Text _text;
    private string _message;
    private AudioSource _audioSource;
    private int _messageTextLenght;
    private Image _fpsControlImg;

    // Use this for initialization
    void Awake()
    {
        _text = GetComponentInChildren<Text>();
        _audioSource = GetComponent<AudioSource>();
        _message = _text.text;
        _messageTextLenght = _message.Length;
        _text.text = string.Empty;
        _fpsControlImg = GameObject.Find("/Canvas/fpsControlImg").GetComponent<Image>();
        _fpsControlImg.enabled = false;
        StartCoroutine(DisplateMessage());
    }

    private void Update()
    {
        if (_messageTextLenght <= 0)
        {
            _audioSource.Stop();
            _fpsControlImg.enabled = true;
            StartCoroutine(ChangeScene());
        }            
    }

    IEnumerator ChangeScene()
    {
        SceneManager.LoadScene("GamePlay");

        yield return new WaitForSeconds(timeToChangeScene);
    }

    IEnumerator DisplateMessage()
    {
        _text.enabled = true;
        if(_messageTextLenght > 0)
            _audioSource.Play();
        else
            _audioSource.Stop();

        for (int i = 0; i < _message.Length; i++)
        {
            char letter = _message[i];
            _text.text += letter;
            _messageTextLenght--;

            yield return new WaitForSeconds(timeToDisplayMessage);
        }        
    }

}
