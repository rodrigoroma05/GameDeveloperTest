using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    #region Declarations

    [Header("Menus")]
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _shopMenu;
    [SerializeField] private GameObject _inventoryMenu;

    [Header("Inventory")]
    [SerializeField] private GameObject _swordSlot;
    [SerializeField] private GameObject _shieldSlot;
    [SerializeField] private GameObject _helmetSlot;
    [SerializeField] private GameObject _pantsSlot;
    [SerializeField] private GameObject _chestplateSlot;

    [Header("Equipped")]
    [SerializeField] private GameObject _swordImage;
    [SerializeField] private GameObject _shieldImage;
    [SerializeField] private GameObject _helmetImage;
    [SerializeField] private GameObject _pantsImage;
    [SerializeField] private GameObject _chestplateImage;

    [Header("Text")]
    [SerializeField] private Text _playerMoneyText;

    [Header("Others")]
    [SerializeField] private GameObject _notEnoughMoneyText;

    private static UiManager _instance;
    public static UiManager Instance { get => _instance; }

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
    }

    #endregion

    #region PauseMenu

    public void ShowPauseMenu()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
    }

    public bool IsPauseOpened()
    {
        return _pauseMenu.activeSelf;
    }

    #endregion

    #region ShopMenu

    public void ShowShopMenu()
    {
        _shopMenu.SetActive(true);
    }

    #endregion

    #region InventoryMenu

    public void ShowInventoryMenu()
    {
        _inventoryMenu.SetActive(true);
    }

    public void ItemsAreAvailable(int itemIdInventory)
    {
        switch (itemIdInventory)
        {
            case 0:
                _swordSlot.SetActive(true);
                break;

            case 1:
                _shieldSlot.SetActive(true);
                break;

            case 2:
                _helmetSlot.SetActive(true);
                break;

            case 3:
                _pantsSlot.SetActive(true);
                break;

            case 4:
                _chestplateSlot.SetActive(true);
                break;
        }
    }

    public void EquipItem(int itemEquipID, bool equipValue)
    {
        switch (itemEquipID)
        {
            case 0:
                _swordImage.SetActive(equipValue);
                break;

            case 1:
                _shieldImage.SetActive(equipValue);
                break;

            case 2:
                _helmetImage.SetActive(equipValue);
                break;

            case 3:
                _pantsImage.SetActive(equipValue);
                break;

            case 4:
                _chestplateImage.SetActive(equipValue);
                break;
        }
    }

    #endregion

    #region MoneyRelated

    public void HowMuchMoney(int money)
    {
        _playerMoneyText.text = money.ToString();
    }

    public void NotEnoughMoneyText()
    {
        StartCoroutine(NoMoneyCourotine());
    }

    IEnumerator NoMoneyCourotine()
    {
        _notEnoughMoneyText.SetActive(true);
        yield return new WaitForSeconds(1);
        _notEnoughMoneyText.SetActive(false);
    }

    #endregion
}
