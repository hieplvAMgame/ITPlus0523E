using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : Singleton<PlayerInfo>
{
    public List<Text> txtValueInfo = new List<Text>();
    public List<Button> listBtn = new List<Button>();
    public List<Sprite> characterSprites = new List<Sprite>();

    private void Awake()
    {
        for (int i = 0; i < listBtn.Count; i++) listBtn[i].onClick.AddListener(() => OnClickBtn(i));
    }
    private void OnClickBtn(int indexBtn)
    {
        switch (indexBtn)
        {
            case 0:
                //Bat Tab character
                break;
            case 1:
                //Bat Tab Attribute
                break;
            case 2:
                //Bat Tab weapon
                break;
        }
    }
    public void UpdateUIAttribute(int index)
    {
        switch (index)
        {
            case 0://atk
                break;
            case 1://hp
                break;
            case 2://dp
                break;
            case 3://lkr
                break;
        }
    }
    public void UpdateUIAttributeAll()
    {

    }
}
