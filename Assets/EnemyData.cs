using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : ICharacter
{
    public AIDestinationSetter destination;
    private System.Action OnDeadAction = null;

    public override void Setup()
    {
        base.Setup();
        // Set speed
        // Set Acceleration
        OnDeadAction = GameManager.Instance.genLevel.SpawnPerTime;
        // Set up chi so enemy theo level: levelPlayer*1.5 + baseValue;
        // Set up chi so enemy theo level: levelMap*1.5 + baseValue;
        Debug.Log($"Set up Enemy: HP = {Hp}| Defend = {Defend}| Damage = {Damage}| Lucky Rate = {LuckyRate}");
        destination.target = PlayerController.Instance.transform;
    }
    public override void OnTakenDamage(int amount)
    {
        base.OnTakenDamage(amount);
        if(Hp<=0)
        {
            //bat effect die
            GameManager.Instance.AddEnemyKill();
            OnDeadAction.Invoke();
            gameObject.SetActive(false);

            //GameManager.Instance.genLevel.SpawnPerTime();
        }
    }
    private void Update()
    {
        this.GetComponent<AIPath>().enabled = PlayerController.Instance.isStart;
    }

}
