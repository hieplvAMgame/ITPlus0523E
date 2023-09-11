using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHome : Singleton<UIHome>
{
    public GameObject settingPanel;
    public Button settingButton;
    public Button shopButton;
    public TopUI topUI;
    private void Awake()
    {
        settingButton.onClick.AddListener(()=>settingPanel.SetActive(true));
        shopButton.onClick.AddListener(() => SceneLoader.Instance.LoadScene("Shop", () => { }));
        topUI.UpdateUIExp();
        topUI.UpdateCoinUI();
    }
}
