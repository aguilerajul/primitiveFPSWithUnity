using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{

    private ParticleSystem _particle;
    private BoxCollider _boxCollider;

    void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _boxCollider = GetComponent<BoxCollider>();
        _particle.Stop();
        _boxCollider.enabled = false;
    }

    void Update()
    {
        if (GlobalActions.IsBossDead && GlobalActions.PlayerHasStone)
        {
            SetWinScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    void SetWinScene()
    {
        if (_particle.isStopped)
        {
            _particle.Play();
            _boxCollider.enabled = true;
        }

    }
}
