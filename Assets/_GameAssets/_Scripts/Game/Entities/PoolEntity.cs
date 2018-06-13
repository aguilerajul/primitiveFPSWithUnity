using UnityEngine;

public class PoolEntity : MonoBehaviour {
    #region Public Variables
    public float RadioToDamage = 20f;
    public int Damage = 5;
    public float TimeToDamageInSeconds = 0.50f;

    public AudioClip PlayerDamagedClip;
    #endregion

    #region Private Variables
    protected float _heightToDamage;

    protected PlayerLifeController _playerLife;
    protected AudioSource _audioSource;
    #endregion
}
