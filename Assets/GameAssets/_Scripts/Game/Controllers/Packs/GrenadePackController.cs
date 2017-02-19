using UnityEngine;

public class GrenadePackController : ReloadEntity
{
    #region Private Variables
    private ThrowGrenadeController _throwGrenadeController;
    #endregion

    private void Awake()
    {
        _throwGrenadeController = GameObject.Find("Player").GetComponentInChildren<ThrowGrenadeController>();
    }

    private void Update()
    {
        this.Rotate();
        Reload();
    }

    #region Custom Methods
    private void Reload()
    {
        float distance = Vector3.Distance(_throwGrenadeController.transform.position, this.transform.position);
        if (distance <= this.radioToCatch && !_throwGrenadeController.HasMaxLimitGrenades())
        {
            _throwGrenadeController.AddGrenades(this.quantityPointsToGain);
            AudioSource.PlayClipAtPoint(this.gainedPointsClip, this.transform.position, this.reloadEffectVolumen);
            Destroy(this.gameObject);
        }
    }
    #endregion
}
