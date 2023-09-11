using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    private void Start()
    {
        SetOpenFirstCharacter();
    }
    public int CurrentLevel
    {
        get
        {
            return PlayerPrefs.GetInt("A", 8);
        }
        set
        {
            PlayerPrefs.SetInt("A", value);
        }
    }
    public float ProcessLevel
    {
        get => PlayerPrefs.GetFloat("ProcessLevel", .3f);
        set => PlayerPrefs.SetFloat("ProcessLevel", value);
    }
    public int CurrentCoin
    {
        get => PlayerPrefs.GetInt("CurrentCoin", 20000);
        set => PlayerPrefs.SetInt("CurrentCoin", value);
    }
    public bool IsNewPlayer
    {
        get => PlayerPrefs.GetInt("IsNewPlayer", 1) == 1;
        set => PlayerPrefs.SetInt("IsNewPlayer", value ? 1 : 0);
    }

    #region Character Status
    public int GetCharacterStatus(int index)        // 0- chưa mua  1- mua rồi  2 - selected
    {
        return PlayerPrefs.GetInt("GetCharacterStatus" + index.ToString(), 0);
    }
    public void SaveCharacterStatus(int index, int valueStatus)
    {
        PlayerPrefs.SetInt("GetCharacterStatus" + index.ToString(), valueStatus);
    }
    public int CurrentCharacter
    {
        get => PlayerPrefs.GetInt("CurrentCharacter", 0);
        set => PlayerPrefs.SetInt("CurrentCharacter", value);
    }
    private void SetOpenFirstCharacter()
    {
        if (IsNewPlayer&&GetCharacterStatus(0)!=2)
        {
            SaveCharacterStatus(0, 2);
            CurrentCharacter = 0;
            IsNewPlayer = false;
        }
    }
    #endregion
    #region Attribute

    public int AttackAttributeLvl
    {
        get => PlayerPrefs.GetInt("AttackAttributeLvl", 0);
        set => PlayerPrefs.SetInt("AttackAttributeLvl", value);
    }
    public int DefendAttributeLvl
    {
        get => PlayerPrefs.GetInt("DefendAttributeLvl", 0);
        set => PlayerPrefs.SetInt("DefendAttributeLvl", value);
    }
    public int HPAttributeLvl
    {
        get => PlayerPrefs.GetInt("HPAttributeLvl", 0);
        set => PlayerPrefs.SetInt("HPAttributeLvl", value);
    }
    public int LkrAttributeLvl
    {
        get => PlayerPrefs.GetInt("LkrAttributeLvl", 0);
        set => PlayerPrefs.SetInt("LkrAttributeLvl", value);
    }
    #endregion
}
