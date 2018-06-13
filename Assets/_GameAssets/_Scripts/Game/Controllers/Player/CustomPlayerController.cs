using UnityEngine;

public class CustomPlayerController : CustomPlayerEntity
{
    // Use this for initialization
    void Awake()
    {
        this._player = GetComponent<CharacterController>();
        Terrain currentTerrain = GameObject.Find("PrincipalTerrain").GetComponent<Terrain>();

        SetMapWidthAndDepth(currentTerrain);

        this._lantern = GameObject.Find("Lantern");
        if (this._lantern != null)
        {
            this._lantern.SetActive(false);
        }

        SetPlayerScale();
    }

    private void SetPlayerScale()
    {
        if (this._player != null)
        {
            this._originalPlayerScale = this._player.transform.localScale;
            this._chuncScaleVector = new Vector3(_player.transform.localScale.x,
               this._player.transform.localScale.y / 2,
               this._player.transform.localScale.z);
        }
    }

    private void SetMapWidthAndDepth(Terrain currentTerrain)
    {
        this._mapDepth = currentTerrain.terrainData.size.z;
        this._mapWidth = currentTerrain.terrainData.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        LimitPlayerToTerrainSize();
        ToggleLantern();
        Crouch();
    }

    void ToggleLantern()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            this._lantern.SetActive(!this._lantern.activeSelf);
        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            this._player.transform.localScale = this._chuncScaleVector;
        }
        else
        {
            this._player.transform.localScale = this._originalPlayerScale;
        }
    }

    void LimitPlayerToTerrainSize()
    {
        Vector3 currentPosition = this._player.transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x, 0, this._mapWidth);
        currentPosition.z = Mathf.Clamp(currentPosition.z, 0, this._mapDepth);
        this._player.transform.position = currentPosition;
    }
}
