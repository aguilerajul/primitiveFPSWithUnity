using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponController : WeaponEntity
{
    void Awake()
    {
        this._audioSource = GetComponent<AudioSource>();
        this._pistol = GameObject.FindGameObjectWithTag("Pistol");
        this._machineGun = GameObject.FindGameObjectWithTag("MachineGun");
        this._shotGun = GameObject.FindGameObjectWithTag("ShotGun");
        this._revolver = GameObject.FindGameObjectWithTag("Revolver");
    }

    void FixedUpdate()
    {
        Fire();
        ChangeWeapon();
    }

    #region Custom Methods
    void ChangeWeapon()
    {
        if (!_isWeaponChanged)
        {
            SetDefaultWeapon();
        }
        else
        {
            SetPistol();
            SetDualPistol();
            SetMachineGun();
            SetShotgun();
        }
    }

    private void SetDefaultWeapon()
    {
        this._pistol.SetActive(true);
        if (this._revolver != null)
            this._revolver.SetActive(false);
        if (this._machineGun != null)
            this._machineGun.SetActive(false);
        if (this._shotGun != null)
            this._shotGun.SetActive(false);
        _isWeaponChanged = true;
    }

    private void SetPistol()
    {
        if (Input.GetKeyDown("1"))
        {
            this._pistol.SetActive(true);

            this._shotGun.SetActive(false);
            this._machineGun.SetActive(false);
            this._revolver.SetActive(false);
        }
    }

    private void SetDualPistol()
    {
        if (Input.GetKeyDown("2") && GlobalActions.HasRevolver)
        {
            this._pistol.SetActive(true);
            this._revolver.SetActive(true);

            this._shotGun.SetActive(false);
            this._machineGun.SetActive(false);
        }
    }

    private void SetMachineGun()
    {
        if (Input.GetKeyDown("3") && GlobalActions.HasMachineGun)
        {
            this._machineGun.SetActive(true);

            this._pistol.SetActive(false);
            this._shotGun.SetActive(false);
            this._revolver.SetActive(false);
        }
    }

    private void SetShotgun()
    {
        if (Input.GetKeyDown("4") && GlobalActions.HasShotGun)
        {
            this._shotGun.SetActive(true);

            this._pistol.SetActive(false);
            this._machineGun.SetActive(false);
            this._revolver.SetActive(false);
        }
    }

    private void Fire()
    {
        bool isButtonFirePress = Input.GetButton("Fire1");
        if (isButtonFirePress)
        {
            if (Time.time > this._amountRateShoot)
            {
                this._amountRateShoot = Time.time + rateShoot;
                InstanciateBullet();
            }
        }
    }

    public bool ActivateWeaponByName(string weaponName)
    {
        if (weaponName == this._revolver.name)
        {
            _hasRevolver = true;
            GlobalActions.HasRevolver = true;
            SetDualPistol();
            return true;
        }

        if (weaponName == this._machineGun.name)
        {
            _hasMachineGun = true;
            GlobalActions.HasMachineGun = true;
            SetMachineGun();
            return true;
        }

        if (weaponName == this._shotGun.name)
        {
            _hasShotGun = true;
            GlobalActions.HasShotGun = true;
            SetShotgun();
            return true;
        }

        return false;
    }

    private void InstanciateBullet()
    {
        GameObject bullet = Instantiate(this.bulletPrefab, bulletSpawn.position, this.transform.rotation);
        Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody>();
        bulletRigidBody.AddForce(this.transform.forward * this.shootForce, ForceMode.Impulse);
        _audioSource.PlayOneShot(this.shootClip, this.shootEffectVolumen);
    }
    #endregion    
}