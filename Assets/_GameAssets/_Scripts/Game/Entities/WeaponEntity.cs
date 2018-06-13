using UnityEngine;

public class WeaponEntity : MonoBehaviour {
    #region Public Variables    
    public float rateShoot = 2f;
    public float shootForce = 10;
    public float shootEffectVolumen = 2;

    public AudioClip shootClip;
    public AudioClip reloadClip;
    public AudioClip changeWeaponClip;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    #endregion

    #region Protected Variables
    protected float _amountRateShoot;
    protected bool _isWeaponChanged = false;
    
    protected AudioSource _audioSource;
    protected Transform _revolverBulletSpawn;
    protected GameObject _pistol;
    protected GameObject _machineGun;
    protected GameObject _shotGun;
    protected GameObject _dualPistol;
    
    protected bool _hasMachineGun;
    protected bool _hasShotGun;
    protected bool _hasDualPistol;
    #endregion
}
