using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewObject", menuName = "NewPlayerObject")]
public class NewObjectScriptable : ScriptableObject
{
    public string _name;

    public Sprite _artwork;

    public int _health;
    public int _attack;
    public int _speed;
}
