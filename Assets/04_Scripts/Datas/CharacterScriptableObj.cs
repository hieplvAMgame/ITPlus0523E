using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character",menuName ="New Character")]
public class CharacterScriptableObj : ScriptableObject
{
    public int hp;
    public int defend;
    public int damage;
    [Range(0,100)]
    public int luckyRate;
    public Sprite previewCharacter;
    public int price = 0;
}
