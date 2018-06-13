using UnityEngine;

public class FirtsAidPackController : ReloadEntity
{
    #region Private Variables
    private PlayerLifeController _playerLife;
    #endregion

    private void Awake()
    {
        _playerLife = FindObjectOfType<PlayerLifeController>();
    }

    private void Update()
    {
        this.Rotate();
        HealPlayer();
    }

    #region Custom Methods
    private void HealPlayer()
    {
        float distance = Vector3.Distance(_playerLife.transform.position, this.transform.position);
        if (distance <= this.radioToCatch && _playerLife.IsDamaged())
        {
            _playerLife.Heal(this.quantityPointsToGain);
            AudioSource.PlayClipAtPoint(this.gainedPointsClip, this.transform.position, this.reloadEffectVolumen);

            Destroy(this.gameObject);
        }
    }
    #endregion
}
