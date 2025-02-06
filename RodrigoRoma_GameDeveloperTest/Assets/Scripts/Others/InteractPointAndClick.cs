using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.EventSystems;

public enum InteractionType { OpenShop, OpenInventory, ReceiveMoney }

public class InteractPointAndClick : MonoBehaviour, IPointerDownHandler
{
    #region Declarations

    [Header("InteractionType")]
    [SerializeField] private InteractionType _interactionType;

    #endregion

    #region Interaction

    public void OnPointerDown(PointerEventData eventData)
    {
        WhatIsInteraction();
    }

    private void WhatIsInteraction()
    {
        switch (_interactionType)
        {
            case InteractionType.OpenShop:
                UiManager.Instance.ShowShopMenu();
                break;

            case InteractionType.OpenInventory:
                UiManager.Instance.ShowInventoryMenu();
                break;

            case InteractionType.ReceiveMoney:
                GameManager.Instance.ReceiveMoney();
                break;
        }
    }

    #endregion
}
