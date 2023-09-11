using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>, IGameSubcriber
{
    public LevelGeneration genLevel;
    public GAME_STATE state;
    public int targetEnemyKillInLevel = 5; // tham chieu ve leveldata
    public int spawnEnemy;
    public int killedEnemy;


    #region GameState Method
    public void GameLose()
    {
        state = GAME_STATE.GameLose;
        listSubcriber.ForEach(x => x.GameLose());
    }

    public void GamePause()
    {
        state = GAME_STATE.GamePause;
        listSubcriber.ForEach(x => x.GamePause());
    }

    public void GamePrepare()
    {
        state = GAME_STATE.GamePrepare;
        Debug.Log("Call Prepare");
        genLevel.GenerateLevel();
        //Keo data tu user data -> Player
        //Gen Player
        listSubcriber.ForEach(x => x.GamePrepare());
    }

    public void GameResume()
    {
        state = GAME_STATE.GameResume;
        listSubcriber.ForEach(x => x.GameResume());
    }

    public void GameStart()
    {
        state = GAME_STATE.GameStart;
        Debug.Log("Call Start");
        listSubcriber.ForEach(x => x.GameStart());
    }

    public void GameWin()
    {
        state = GAME_STATE.GameWin;
        listSubcriber.ForEach(x => x.GameWin());
    }
    #endregion
    private List<IGameSubcriber> listSubcriber = new List<IGameSubcriber>();

    public void AddSubcriber(IGameSubcriber sub)
    {
        listSubcriber.Add(sub);
    }
    public void RemoveSubcriber(IGameSubcriber sub)
    {
        listSubcriber.Remove(sub);
    }
    public void Check()
    {
        switch (state)
        {
            case GAME_STATE.GameStart:
                GameStart();
                break;
            case GAME_STATE.GamePrepare:
                GamePrepare();
                break;
        }
    }
    public void AddEnemyKill()
    {
        killedEnemy++;
        CheckWin();
    }
    public void AddEnemySpawn()
    {
        spawnEnemy++;
    }
    public void CheckWin()
    {
        if (killedEnemy >= targetEnemyKillInLevel) GameWin();
    }
    public int GetActiveEnemy() => spawnEnemy - killedEnemy;
}
