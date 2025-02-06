using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewObject", menuName = "NewPlayerObject")]
public class NewObjectScriptable : ScriptableObject
{
    #region Declarations

    [Header("Name")]
    [SerializeField] private string _name;

    [Header("Artwork")]
    [SerializeField] private Sprite _artwork;

    [Header("Stats")]
    [SerializeField] private int _health;
    [SerializeField] private int _attack;
    [SerializeField] private int _speed;
    [SerializeField] private int _price;

    #endregion

    #region GetSet

    public string Name { get => _name; set => _name = value; }
    public Sprite Artwork { get => _artwork; set => _artwork = value; }
    public int Health { get => _health; set => _health = value; }
    public int Attack { get => _attack; set => _attack = value; }
    public int Speed { get => _speed; set => _speed = value; }
    public int Price { get => _price; set => _price = value; }

    #endregion
}
