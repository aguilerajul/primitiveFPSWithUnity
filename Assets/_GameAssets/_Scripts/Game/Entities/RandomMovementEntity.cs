using UnityEngine;

public class RandomMovementEntity : MonoBehaviour
{
    #region Public Variables
    public float RotationDegrees = 90;
    public float ChangeDirectionInterval = 4;
    public float Speed = 4;
    #endregion

    #region Private Variables
    protected float _mapWidth;
    protected float _mapDepth;

    protected Vector3 _finalDirection;
    protected CharacterController _characterController;
    #endregion
}
