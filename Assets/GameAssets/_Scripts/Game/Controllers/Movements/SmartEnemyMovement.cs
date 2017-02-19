using UnityEngine;

public class SmartEnemyMovement : SmartEnemyEntity
{
    void Awake()
    {
        this._player = GameObject.Find("Player");
        this._ramdonMovement = GetComponent<RandomMovement>();
        this._followMovement = GetComponent<FollowMovement>();

        EnableRandomMovement();
    }

    void Update()
    {
        EnableRandomMovementOrFollowMovement();
    }

    #region Custom Methods
    void EnableRandomMovementOrFollowMovement()
    {
        float distance = 30f;
        if (_player != null)
            distance = Vector3.Distance(this.transform.position, this._player.transform.position);

        if (distance <= this.radtoToFollow)
        {
            EnableFollowMovement();
        }
        else
        {
            EnableRandomMovement();
        }
    }

    void EnableRandomMovement()
    {
        this._ramdonMovement.enabled = true;
        this._followMovement.enabled = false;
    }

    void EnableFollowMovement()
    {
        this._ramdonMovement.enabled = false;
        this._followMovement.enabled = true;
    }
    #endregion
}
