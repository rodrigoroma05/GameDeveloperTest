using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemsType { Sword, Shield, Helmet, Pants, Chestplate }

public class Items : MonoBehaviour
{
    #region Declarations

    [SerializeField] private ItemsType _interactionType;
    [SerializeField] private Button _button;

    [SerializeField] private bool _isItemEquipped;

    private ObjectDisplay _objectDisplay;

    public bool IsItemEquipped { get => _isItemEquipped; set => _isItemEquipped = value; }

    #endregion

    #region Monobehaviour

    private void Awake()
    {
        _objectDisplay = GetComponent<ObjectDisplay>();
    }

    #endregion

    #region Buy

    public void BuyButtonPressed()
    {
        WhatIsBuying();
    }
    private void WhatIsBuying()
    {
        switch (_interactionType)
        {
            case ItemsType.Sword:
                GameManager.Instance.ItemBought(_objectDisplay.Object, 0);
                if (GameManager.Instance.WasItemBought == true)
                {
                    _button.enabled = false;
                }
                break;

            case ItemsType.Shield:
                GameManager.Instance.ItemBought(_objectDisplay.Object, 1);
                if (GameManager.Instance.WasItemBought == true)
                {
                    _button.enabled = false;
                }
                break;

            case ItemsType.Helmet:
                GameManager.Instance.ItemBought(_objectDisplay.Object, 2);
                if (GameManager.Instance.WasItemBought == true)
                {
                    _button.enabled = false;
                }
                break;

            case ItemsType.Pants:
                GameManager.Instance.ItemBought(_objectDisplay.Object, 3);
                if (GameManager.Instance.WasItemBought == true)
                {
                    _button.enabled = false;
                }
                break;

            case ItemsType.Chestplate:
                GameManager.Instance.ItemBought(_objectDisplay.Object, 4);
                if (GameManager.Instance.WasItemBought == true)
                {
                    _button.enabled = false;
                }
                break;
        }
    }

    #endregion

    #region Equip
    public void EquipButtonPressed()
    {
        WhatIsEquipping();
    }

    private void WhatIsEquipping()
    {
        switch (_interactionType)
        {
            case ItemsType.Sword:
                GameManager.Instance.ItemEquipped(0, _objectDisplay.Object, _isItemEquipped);
                break;

            case ItemsType.Shield:
                GameManager.Instance.ItemEquipped(1, _objectDisplay.Object, _isItemEquipped);
                break;

            case ItemsType.Helmet:
                GameManager.Instance.ItemEquipped(2, _objectDisplay.Object, _isItemEquipped);
                break;

            case ItemsType.Pants:
                GameManager.Instance.ItemEquipped(3, _objectDisplay.Object, _isItemEquipped);
                break;

            case ItemsType.Chestplate:
                GameManager.Instance.ItemEquipped(4, _objectDisplay.Object, _isItemEquipped);
                break;
        }
    }

    #endregion
}
