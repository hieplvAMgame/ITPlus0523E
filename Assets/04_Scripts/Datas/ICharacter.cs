using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacter : MonoBehaviour
{
    private int hp;
    private int defend;
    private int damage;
    private int luckyRate;

    public CharacterScriptableObj baseData;
    public int Hp
    {
        get => hp;
        set
        {
            hp = value;
            if (hp <= 0)
                OnDead();
        }
    }
    public int Defend
    {
        get => defend;
        set => defend = value;
    }
    public int Damage
    {
        get => damage;
        set => damage = value;
    }
    public int LuckyRate
    {
        get => luckyRate;
        set => luckyRate = value;
    }
    /// <summary>
    /// Setup babe info of character, like hp, damage,...
    /// </summary>
    public virtual void Setup()
    {
        Hp = baseData.hp;
        defend = baseData.defend;
        damage = baseData.damage;
        luckyRate = baseData.luckyRate;
    }
    public virtual void OnDead()
    {
        // Nhung gi xay ra khi player/enemy chet
    }
    public virtual void OnTakenDamage(int amount)
    {
        Hp -= amount;
    }
}
