using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDisplay : MonoBehaviour
{
    [SerializeField] private NewObjectScriptable _object;

    [SerializeField] private Image _objectImage;

    [SerializeField] private Text _nameText;
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _attackText;
    [SerializeField] private Text _speedText;

    public NewObjectScriptable Object { get => _object; }

    private void Start()
    {
        _nameText.text = _object._name;

        _objectImage.sprite = _object._artwork;

        _healthText.text = "Health: " + _object._health.ToString();
        _attackText.text = "Attack: " + _object._attack.ToString();
        _speedText.text = "Speed: " + _object._speed.ToString();
    }
}
