using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig
{
}
public enum Type_Character
{
    Warrior,
    Mage,
    Orge,
    Dracula
}
public struct GAME_TAG
{
    public const string Player = "Player";
    public const string Enemy = "Enemy";
    public const string Wall = "Wall";
    public const string Bullet = "Bullet";
}
public enum TYPE_GUN
{
    Type1,
    Type2,
    Type3
}
public struct TYPE_BULLET
{
    public const string NormalBullet = "NormalBullet";
}
public enum GAME_STATE
{
    GamePrepare,
    GameStart,
    GamePause,
    GameResume,
    GameWin,
    GameLose
}
