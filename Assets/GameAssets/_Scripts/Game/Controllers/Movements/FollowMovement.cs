using UnityEngine;

public class FollowMovement : MovementEntity
{
    #region Private Variables
    private GameObject _player;
    #endregion

    private void Awake()
    {
        _player = GameObject.Find("Player");
        this.CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        FollowPlayer();
    }

    #region Custom Methods
    private void FollowPlayer()
    {
        Vector3 direction = _player.transform.position - this.transform.position;
        direction.Normalize();
        this.transform.forward = direction;
        this.CharacterController.SimpleMove(direction * this.speed);
    }
    #endregion
}
