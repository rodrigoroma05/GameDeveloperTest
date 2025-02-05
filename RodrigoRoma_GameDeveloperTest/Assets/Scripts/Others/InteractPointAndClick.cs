using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.EventSystems;

public enum InteractionType { OpenShop, OpenInventory, ReceiveMoney }

public class InteractPointAndClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private InteractionType _interactionType;

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
                Debug.Log("OpenShop");
                break;

            case InteractionType.OpenInventory:
                UiManager.Instance.ShowInventoryMenu();
                Debug.Log("OpenInventory");
                break;

            case InteractionType.ReceiveMoney:
                GameManager.Instance.ReceiveMoney();
                Debug.Log("ReceiveMoney");
                break;
        }
    }
}
