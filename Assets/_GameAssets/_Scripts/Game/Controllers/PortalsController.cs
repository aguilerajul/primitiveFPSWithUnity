using UnityEngine;

public class PortalsController : MonoBehaviour
{
    #region Public Variables
    public Transform destinyPortal;
    public int deadEnemiesToActivatePortal = 20;
    #endregion

    #region Private Variables
    private ParticleSystem _particleSystem;
    private BoxCollider _boxCollider;
    #endregion

    private void Awake()
    {
        _particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        _boxCollider = GetComponent<BoxCollider>();

        _particleSystem.Stop();
        _boxCollider.enabled = false;
    }

    private void Update()
    {
        ActivatePortal();
    }

    private void OnTriggerEnter(Collider other)
    {
        MovePlayerToPortalDestiny(other);
    }
    #region Custom Methods

    private void ActivatePortal()
    {
        if (GlobalActions.GetCurrentEnemiesDead() >= deadEnemiesToActivatePortal)
        {
            _particleSystem.Play();
            _boxCollider.enabled = true;
        }
    }

    private void MovePlayerToPortalDestiny(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = destinyPortal.transform.position;            
            other.gameObject.transform.Rotate(other.gameObject.transform.up);
        }
    }

    #endregion
}
