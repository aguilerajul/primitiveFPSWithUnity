using System.Linq;
using UnityEngine;

public class CollectWeaponController : MonoBehaviour
{
    public float radioToCollect = 1f;
    public GameObject weaponPrefab;
    public AudioClip collectedWeaponClip;
    public string nameToDisplayUser;

    private WeaponController[] _weaponsController;
    private GameObject _player;

    // Use this for initialization
    void Awake()
    {
        this._weaponsController = FindObjectsOfType<WeaponController>();
        this._player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector3.Distance(_player.transform.position, this.transform.position);
        if (distance <= radioToCollect)
        {
            foreach (var weaponController in _weaponsController)
            {
                bool isWeaponActivated = weaponController.ActivateWeaponByName(weaponPrefab.name);
                if (collectedWeaponClip != null && isWeaponActivated)
                {
                    AudioSource.PlayClipAtPoint(collectedWeaponClip, this.transform.position, 1);
                    this.gameObject.SetActive(false);
                    break;
                }
            }

        }
    }
}
