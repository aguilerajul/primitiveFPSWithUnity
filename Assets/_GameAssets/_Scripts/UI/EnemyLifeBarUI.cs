using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeBarUI : MonoBehaviour
{
    #region Private Variables
    private EnemyLifeController _enemyLifeController;
    private Image _enemyLifeBarImage;
    #endregion

    void Awake()
    {
        _enemyLifeController = GetComponentInParent<EnemyLifeController>();
        _enemyLifeBarImage = GetComponentInChildren<Image>();
    }

    void Update()
    {
        float lifePercent = _enemyLifeController.currentLife / _enemyLifeController.maxLife;
        _enemyLifeBarImage.fillAmount = lifePercent;
    }
}