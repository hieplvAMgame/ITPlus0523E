using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ICharacter
{
    public float range;
    public FOV fov;
    public bool isImmortal = false;
    public Type_Character type = Type_Character.Warrior;
    public override void OnDead()
    {
        base.OnDead();
    }
    public override void Setup()
    {
        base.Setup();
        //hp = level *2 + base
        Hp += DataManager.Instance.userData.CurrentLevel * 2;// cong them tu item, chi so nang cap
        Defend += DataManager.Instance.userData.CurrentLevel * 2;
        Damage += DataManager.Instance.userData.CurrentLevel * 2;
        LuckyRate += DataManager.Instance.userData.CurrentLevel * 2;
        //fov.SetupRange(range);
        //Hp+= currentLevel*2 + item[id].Hp;
    }
    public override void OnTakenDamage(int amount)
    {
        base.OnTakenDamage(amount);
        if (Hp <= 0)
        {
            //Bat 1 coroutine -> anim die (2s)
            GameManager.Instance.GameLose();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GAME_TAG.Enemy) && !isImmortal)
        {
            collision.gameObject.TryGetComponent<EnemyData>(out EnemyData enemy);
            OnTakenDamage(enemy.Damage);
        }
    }
}

