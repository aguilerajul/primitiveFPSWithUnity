using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasController : MonoBehaviour
{
    private const float messageTimeToDisplay = 0f;
    private const float messageTimeToHide = 20f;
    private bool _isMessageDisplayed;

    private Text _activatedPortalsCountText;
    private Text _enemiesScoreCountText;
    private Text _weaponsCollectedCountText;
    private Text _stoneCollectedCountText;
    private Text _gameInstructionsText;
    private GameObject _gameInstructionsPanel;
    private PortalsController _portal;
    private StringBuilder _sbGameInstructions;
    private Dictionary<string, bool> _messageDisplayed;
    
    // Use this for initialization
    void Awake()
    {
        _activatedPortalsCountText = GameObject.Find("/Player/PlayerCanvas/IndicatorPanel/ActivedPortalsCount").GetComponent<Text>();
        _enemiesScoreCountText = GameObject.Find("/Player/PlayerCanvas/IndicatorPanel/EnemiesScoreCount").GetComponent<Text>();
        _stoneCollectedCountText = GameObject.Find("/Player/PlayerCanvas/IndicatorPanel/StoneCollectCount").GetComponent<Text>();
        _gameInstructionsPanel = GameObject.Find("/Player/PlayerCanvas/GameInstructionsPanel");
        _gameInstructionsText = GameObject.Find("/Player/PlayerCanvas/GameInstructionsPanel/GameInstructionsText").GetComponent<Text>();
        _portal = FindObjectOfType<PortalsController>();
        _sbGameInstructions = new StringBuilder();
        _messageDisplayed = new Dictionary<string, bool>();
        _messageDisplayed.Add("HasRevolver", false);
        _messageDisplayed.Add("HasShotGun", false);
        _messageDisplayed.Add("HasMachineGun", false);
        _messageDisplayed.Add("BossMessage", false);
        _messageDisplayed.Add("PortalMessage", false);
        _messageDisplayed.Add("GotMaterial", false);
        _gameInstructionsPanel.SetActive(false);
        StartCoroutine(DisplayInstructions(SetDefaultInstructionsMessage()));
    }

    private void Update()
    {
        SetWeaponTextMessages();

        if (_activatedPortalsCountText)
        {
            SetActivatedPortalCount();
        }

        if (_enemiesScoreCountText)
        {
            _enemiesScoreCountText.text = GlobalActions.GetCurrentEnemiesDead().ToString();
            if(GlobalActions.GetCurrentEnemiesDead() > 0 && _messageDisplayed["BossMessage"] == false)
            {
                StartCoroutine(SetBossPortalActivationMessage());
                _messageDisplayed["BossMessage"] = true;
            }
        }

        if (_stoneCollectedCountText)
        {
            _stoneCollectedCountText.text = GlobalActions.PlayerHasStone ? "1/1" : "0/1";
        }

        SetPortalMessage();
        SetMateriaMessage();
    }

    #region Custom Methods
    private void SetPortalMessage()
    {
        if (GlobalActions.GetCurrentEnemiesDead() >= 20 && _messageDisplayed["PortalMessage"] == false)
        {
            StartCoroutine(DisplayInstructions("Great!!!, The Big Rocks portal is \r\n activated move there."));
            _messageDisplayed["PortalMessage"] = true;
        }
    }

    private void SetMateriaMessage()
    {
        if (GlobalActions.IsBossDead && _messageDisplayed["GotMaterial"] == false && GlobalActions.PlayerHasStone)
        {
            StartCoroutine(DisplayInstructions("Great!!!, You got the material cross \r\n the green portal to win."));
            _messageDisplayed["GotMaterial"] = true;
        }
    }

    private void SetWeaponTextMessages()
    {
        if(GlobalActions.HasRevolver && _messageDisplayed["HasRevolver"] == false)
        {
            StartCoroutine(DisplayInstructions("Great!!!, you got a Revolver press \r\n the number 2 in the keyboard \r\n to activate."));
            _messageDisplayed["HasRevolver"] = true;
        }

        if (GlobalActions.HasMachineGun && _messageDisplayed["HasMachineGun"] == false)
        {
            StartCoroutine(DisplayInstructions("Great!!!, you got a MachineGun press \r\n the number 3 in the keyboard \r\n to activate."));
            _messageDisplayed["HasMachineGun"] = true;
        }

        if (GlobalActions.HasShotGun && _messageDisplayed["HasShotGun"] == false)
        {
            StartCoroutine(DisplayInstructions("Great!!!, you got a ShotGun press \r\n the number 4 in the keyboard \r\n to activate."));
            _messageDisplayed["HasShotGun"] = true;
        }
    }

    private void SetActivatedPortalCount()
    {
        string activatedPortals = "{0}/2";

        if (GlobalActions.GetCurrentEnemiesDead() >= _portal.deadEnemiesToActivatePortal
            && !GlobalActions.PlayerHasStone)
            activatedPortals = string.Format(activatedPortals, 1);

        if (GlobalActions.GetCurrentEnemiesDead() >= _portal.deadEnemiesToActivatePortal
            && GlobalActions.PlayerHasStone)
            activatedPortals = string.Format(activatedPortals, 2);

        if (GlobalActions.GetCurrentEnemiesDead() <= _portal.deadEnemiesToActivatePortal
            && GlobalActions.PlayerHasStone)
            activatedPortals = string.Format(activatedPortals, 1);

        activatedPortals = activatedPortals.Replace("{0}", "0");
        _activatedPortalsCountText.text = activatedPortals;
    }

    private string SetDefaultInstructionsMessage()
    {
        string message = string.Empty;
        if (_gameInstructionsText != null)
        {
            _sbGameInstructions.AppendLine("Welcome again, i take a");
            _sbGameInstructions.AppendLine("look into this planet and i");
            _sbGameInstructions.AppendLine("saw 4 kind of monsters");
            _sbGameInstructions.AppendLine("1.- Kamikaze, be careful");
            _sbGameInstructions.AppendLine("2.- Small Kamikaze, they looks like rabits");
            _sbGameInstructions.AppendLine("3.- Snippers");
            _sbGameInstructions.AppendLine("4.- I cannot identify the last one???");
            _sbGameInstructions.AppendLine("I suggest: find other weapons");
            _sbGameInstructions.AppendLine("or things that can be useful");
            _sbGameInstructions.AppendLine("into the houses or environment.");
            message = _sbGameInstructions.ToString();
        }

        return message;
    }
    
    private IEnumerator SetBossPortalActivationMessage()
    {
        _gameInstructionsPanel.SetActive(true);

        _sbGameInstructions.AppendLine("Great!!! You kill 1 monster");
        _sbGameInstructions.AppendLine("But you have to kill 20, to make appear ");
        _sbGameInstructions.AppendLine("a kind of portal in front of");
        _sbGameInstructions.AppendLine("the big rocks.");
        _sbGameInstructions.AppendLine(" ");
        _sbGameInstructions.AppendLine("Once you cross that portal");
        _sbGameInstructions.AppendLine("i can't help you anymore,");
        _sbGameInstructions.AppendLine("because i cannot explore that zone");
        _sbGameInstructions.AppendLine("maybe there you'll find the material");
        _sbGameInstructions.AppendLine("that we are looking for.");

        DisplayDelayedMessage(_sbGameInstructions.ToString());
        yield return new WaitUntil(() => _isMessageDisplayed == true);

        yield return new WaitForSeconds(10f);
        CleanInstructionsText();
    }

    private void CleanInstructionsText()
    {
        _gameInstructionsText.text = string.Empty;
        _isMessageDisplayed = false;
        _sbGameInstructions.Remove(0, _sbGameInstructions.Length);
        _gameInstructionsPanel.SetActive(false);
    }

    private IEnumerator DisplayInstructions(string messageToDisplay)
    {
        if (!string.IsNullOrEmpty(messageToDisplay))
        {
            DisplayDelayedMessage(messageToDisplay);
            yield return new WaitUntil(() => _isMessageDisplayed == true);
            yield return new WaitForSeconds(10f);
            CleanInstructionsText();
        }
    }

    private void DisplayDelayedMessage(string messageToDisplay)
    {
        _gameInstructionsPanel.SetActive(true);
        for (int i = 0; i < messageToDisplay.Length; i++)
        {
            _gameInstructionsText.text += messageToDisplay[i].ToString();
        }
        _isMessageDisplayed = true;
    }
    #endregion
}
