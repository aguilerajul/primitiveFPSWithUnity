using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeBarUI : MonoBehaviour {

    #region Private Variables
    private PlayerLifeController _playerLifeController;
    private Image _playerLifeBarImage;
    private Text _playerLifeBarText;
    #endregion

    // Use this for initialization
    void Start () {
        _playerLifeController = GetComponentInParent<PlayerLifeController>();
        _playerLifeBarImage = GetComponentInChildren<Image>();
        _playerLifeBarText = GameObject.Find("/Player/PlayerCanvas/PlayerLifeText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        float lifePercent = _playerLifeController.currentLife / _playerLifeController.maxLife;
        _playerLifeBarImage.fillAmount = lifePercent;
        if(lifePercent <= 0)
            _playerLifeBarText.text = 0 + "%";
        else
            _playerLifeBarText.text = lifePercent * 100 + "%";
    }
}
