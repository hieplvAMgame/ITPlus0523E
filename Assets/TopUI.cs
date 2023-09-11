using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TopUI : MonoBehaviour
{
    [Header("TOP UI")]

    public Text txtLevel;
    public Text txtCoin;
    public Image processImgExp;

    public void UpdateUIExp()
    {
        txtLevel.text = DataManager.Instance.userData.CurrentLevel.ToString();
        processImgExp.fillAmount = DataManager.Instance.userData.ProcessLevel;
    }
    public void UpdateCoinUI()
    {
        txtCoin.text = DataManager.Instance.userData.CurrentCoin.ToString();
    }
}
