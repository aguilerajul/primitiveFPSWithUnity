using UnityEngine;

public class SmartEnemyEntity : MonoBehaviour {
    #region Public Variables
    public float radtoToFollow = 20;
    #endregion

    #region Private Variables
    protected RandomMovement _ramdonMovement;
    protected FollowMovement _followMovement;
    protected GameObject _player;
    #endregion
}
