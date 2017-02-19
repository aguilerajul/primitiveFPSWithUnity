using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StairsController : MonoBehaviour
{
    public float heightFactor = 3.2f;

    private FirstPersonController _playerFirstPersonController;
    private bool _isPlayerInside;

    private void Awake()
    {
        _playerFirstPersonController = GameObject.Find("Player").GetComponent<FirstPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _playerFirstPersonController.enabled = false;
            _isPlayerInside = !_isPlayerInside;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _playerFirstPersonController.enabled = true;
            _isPlayerInside = !_isPlayerInside;
        }
    }

    private void Update()
    {
        if (_isPlayerInside && Input.GetKey("w"))
        {
            _playerFirstPersonController.transform.position += Vector3.up / heightFactor;
        }

        if (_isPlayerInside && Input.GetKey("s"))
        {
            _playerFirstPersonController.transform.position += -Vector3.up / heightFactor;
            _playerFirstPersonController.enabled = true;
        }

        if (_isPlayerInside && Input.GetKey("a") || _isPlayerInside && Input.GetKey("d"))
        {
            _playerFirstPersonController.enabled = true;
            _isPlayerInside = false;
        }
    }
}
