using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDisplay : MonoBehaviour
{
    #region Declarations

    [Header("ScriptableObject")]
    [SerializeField] private NewObjectScriptable _object;

    [Header("Image")]
    [SerializeField] private Image _objectImage;

    [Header("Text")]
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _attackText;
    [SerializeField] private Text _speedText;
    [SerializeField] private Text _priceText;

    [Header("Bool")]
    [SerializeField] private bool _isInShop;

    public NewObjectScriptable Object { get => _object; }

    #endregion

    #region Monobehaviour

    private void Start()
    {
        _nameText.text = _object.Name;

        _objectImage.sprite = _object.Artwork;

        _healthText.text = "Health: " + _object.Health.ToString();
        _attackText.text = "Attack: " + _object.Attack.ToString();
        _speedText.text = "Speed: " + _object.Speed.ToString();

        if (_isInShop == true)
        {
            _priceText.text = "Price: " + _object.Price.ToString();
        }
    }

    #endregion
}
