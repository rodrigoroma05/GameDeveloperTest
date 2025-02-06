using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Declarations

    [Header("Variables")]

    private int _totalMoney;
    private bool _wasItemBought;

    [SerializeField] private int _mainHealth;
    [SerializeField] private int _mainAttack;
    [SerializeField] private int _mainSpeed;

    private const string UI_SCENE_NAME = "UI";

    #endregion

    #region GetSet

    private static GameManager _instance;
    public static GameManager Instance { get => _instance; }
    public bool WasItemBought { get => _wasItemBought; }
    public int MainHealth { get => _mainHealth; set => _mainHealth = value; }
    public int MainAttack { get => _mainAttack; set => _mainAttack = value; }
    public int MainSpeed { get => _mainSpeed; set => _mainSpeed = value; }

    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (SceneManager.GetSceneByName(UI_SCENE_NAME).isLoaded == false)
        {
            StartCoroutine(LoadUI());
        }
    }

    private void Start()
    {
        _mainHealth = 5;
        _mainAttack = 5;
        _mainSpeed = 5;
    }

    private void Update()
    {
        PauseFunction();
    }

    IEnumerator LoadUI()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(UI_SCENE_NAME, LoadSceneMode.Additive);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    #endregion

    #region Items

    public void ItemEquipped(int itemEquippedID, NewObjectScriptable itemEquipped, bool isEquipped)
    {  
        if (isEquipped == true)
        {
            _mainHealth -= itemEquipped.Health;
            _mainAttack -= itemEquipped.Attack;
            _mainSpeed -= itemEquipped.Speed;
        }
        else
        {
            _mainHealth += itemEquipped.Health;
            _mainAttack += itemEquipped.Attack;
            _mainSpeed += itemEquipped.Speed;
        }

        switch (itemEquippedID)
        {
            case 0:
                UiManager.Instance.EquipItem(0, !isEquipped);
                break;

            case 1:
                UiManager.Instance.EquipItem(1, !isEquipped);
                break;

            case 2:
                UiManager.Instance.EquipItem(2, !isEquipped);
                break;

            case 3:
                UiManager.Instance.EquipItem(3, !isEquipped);
                break;

            case 4:
                UiManager.Instance.EquipItem(4, !isEquipped);
                break;
        }   
    }

    public void ItemBought(NewObjectScriptable price, int itemID)
    {

        if (_totalMoney < price.Price)
        {
            UiManager.Instance.NotEnoughMoneyText();
            _wasItemBought = false;
        }
        else
        {
            _totalMoney -= price.Price;
            UiManager.Instance.HowMuchMoney(_totalMoney);
            _wasItemBought = true;

            switch (itemID)
            {
                case 0:
                    UiManager.Instance.ItemsAreAvailable(0);
                    break;

                case 1:
                    UiManager.Instance.ItemsAreAvailable(1);
                    break;

                case 2:
                    UiManager.Instance.ItemsAreAvailable(2);
                    break;

                case 3:
                    UiManager.Instance.ItemsAreAvailable(3);
                    break;

                case 4:
                    UiManager.Instance.ItemsAreAvailable(4);
                    break;
            }
        }
    }

    #endregion

    #region Others

    private void PauseFunction()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            bool active = UiManager.Instance.IsPauseOpened();

            if (!active)
            {
                UiManager.Instance.ShowPauseMenu();
            }
        }
    }
    public void ReceiveMoney()
    {
        _totalMoney = _totalMoney + 10;
        UiManager.Instance.HowMuchMoney(_totalMoney);
    }

    #endregion
}
