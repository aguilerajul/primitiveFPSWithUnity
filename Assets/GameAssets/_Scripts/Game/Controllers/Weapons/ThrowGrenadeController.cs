using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ThrowGrenadeController : MonoBehaviour
{

    #region Public Variables
    public int grenadeLimits = 3;
    public int currentGrenades { get; private set; }

    public float throwForce = 30;

    public Rigidbody grenadePrefab;
    #endregion

    #region Private Variables
    private string _strGrenadeTextFormat = "Grenades: {0}/{1}";
    private Image[] _grenadeImages;
    private Text _grenadeText;    
    #endregion

    private void Awake()
    {
        currentGrenades = grenadeLimits;
        _grenadeText = GameObject.Find("/Player/PlayerCanvas/GrenadeText").GetComponent<Text>();        
        _grenadeImages = GameObject.Find("Player").GetComponentsInChildren<Image>().Where(x => x.name.ToLower().Contains("grenade")).ToArray();
        //_grenadeText = _playerCanvas.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        UpdateCanvasCounters();
        if (Input.GetButtonDown("Fire2") && currentGrenades > 0)
        {
            currentGrenades--;
            _grenadeImages[currentGrenades].enabled = false;
            Rigidbody grenade = Instantiate(grenadePrefab);
            grenade.transform.position = this.transform.position;

            Vector3 direction = this.transform.forward;
            grenade.AddForce(direction * throwForce, ForceMode.Impulse);
        }
    }

    #region Custom Methods
    public bool HasMaxLimitGrenades()
    {
        return currentGrenades == grenadeLimits;
    }

    public void AddGrenades(int grenadeCount)
    {
        currentGrenades = Mathf.Clamp(currentGrenades + grenadeCount, 0, grenadeLimits);
        for (int i = 0; i < currentGrenades; i++)
        {
            _grenadeImages[i].enabled = true;
        }
    }

    private void UpdateCanvasCounters()
    {
        _grenadeText.text = string.Format(_strGrenadeTextFormat, currentGrenades, grenadeLimits);
    }
    #endregion
}
