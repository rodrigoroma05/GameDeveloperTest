using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemsType { Sword, Shield, Helmet, Pants, Chestplate }

public class Items : MonoBehaviour
{
    private ObjectDisplay _objectDisplay;
    [SerializeField] private ItemsType _interactionType;
    [SerializeField] private Button _button;

    [SerializeField] private bool _isItemEquipped;

    public bool IsItemEquipped { get => _isItemEquipped; set => _isItemEquipped = value; }

    private void Awake()
    {
        _objectDisplay = GetComponent<ObjectDisplay>();
    }

    public void BuyButtonPressed()
    {
        WhatIsBuying();
    }

    public void EquipButtonPressed()
    {
        WhatIsEquipping();
    }

    private void WhatIsBuying()
    {
        switch (_interactionType)
        {
            case ItemsType.Sword:
                GameManager.Instance.ItemBought(15, 0);
                if (GameManager.Instance.WasItemBought == true)
                {
                    _button.enabled = false;
                }
                break;

            case ItemsType.Shield:
                GameManager.Instance.ItemBought(100, 1);
                if (GameManager.Instance.WasItemBought == true)
                {
                    _button.enabled = false;
                }
                break;

            case ItemsType.Helmet:
                GameManager.Instance.ItemBought(20, 2);
                if (GameManager.Instance.WasItemBought == true)
                {
                    _button.enabled = false;
                }
                break;

            case ItemsType.Pants:
                GameManager.Instance.ItemBought(30, 3);
                if (GameManager.Instance.WasItemBought == true)
                {
                    _button.enabled = false;
                }
                break;

            case ItemsType.Chestplate:
                GameManager.Instance.ItemBought(50, 4);
                if (GameManager.Instance.WasItemBought == true)
                {
                    _button.enabled = false;
                }
                break;
        }
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
}
