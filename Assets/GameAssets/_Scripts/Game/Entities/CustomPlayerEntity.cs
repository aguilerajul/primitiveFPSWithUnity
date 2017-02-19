using UnityEngine;

public class CustomPlayerEntity : MonoBehaviour {

    #region Public Variables
    public AudioClip upStairsClip;
    #endregion

    #region Private Variables
    protected float _mapWidth;
    protected float _mapDepth;

    protected Vector3 _originalPlayerScale;
    protected Vector3 _chuncScaleVector;
    protected CharacterController _player;
    protected GameObject _lantern;
    #endregion
}
