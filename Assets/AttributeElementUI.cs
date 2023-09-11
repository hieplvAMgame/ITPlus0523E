using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
public class AttributeElementUI : MonoBehaviour
{
    public int id;
    public Text txtBefore, txtAfter, txtPrice;
    public Button btnBuy;
    public Image preview;

    private int beforeVal, afterVal, price;

    private void Awake()
    {
        btnBuy.onClick.AddListener(() =>
        {
            if (DataManager.Instance.userData.CurrentCoin >= price)
            {
                DataManager.Instance.userData.CurrentCoin -= price;
                switch (id)
                {
                    case 0:
                        DataManager.Instance.userData.AttackAttributeLvl++;
                        break;
                    case 1:
                        DataManager.Instance.userData.DefendAttributeLvl++;
                        break;
                    case 2:
                        DataManager.Instance.userData.HPAttributeLvl++;
                        break;
                    case 3:
                        DataManager.Instance.userData.LkrAttributeLvl++;
                        break;
                }
                SetupUI(id);
            }
        });
    }
    public void SetupUI(int _id)
    {
        id = _id;
        preview.sprite = ShopElementManager.Instance.spriteAttribute[id];
        switch (id)
        {
            case 0:
                beforeVal = DataManager.Instance.userData.AttackAttributeLvl * GlobalConfig.Instance.formularValueAttribute[id];
                afterVal = (DataManager.Instance.userData.AttackAttributeLvl + 1) * GlobalConfig.Instance.formularValueAttribute[id];
                break;
            case 1:
                beforeVal = DataManager.Instance.userData.DefendAttributeLvl * GlobalConfig.Instance.formularValueAttribute[id];
                afterVal = (DataManager.Instance.userData.DefendAttributeLvl + 1) * GlobalConfig.Instance.formularValueAttribute[id];
                break;
            case 2:
                beforeVal = DataManager.Instance.userData.HPAttributeLvl * GlobalConfig.Instance.formularValueAttribute[id];
                afterVal = (DataManager.Instance.userData.HPAttributeLvl + 1) * GlobalConfig.Instance.formularValueAttribute[id];
                break;
            case 3:
                beforeVal = DataManager.Instance.userData.LkrAttributeLvl * GlobalConfig.Instance.formularValueAttribute[id];
                afterVal = (DataManager.Instance.userData.LkrAttributeLvl + 1) * GlobalConfig.Instance.formularValueAttribute[id];
                break;
        }
        txtBefore.text = beforeVal.ToString();
        txtAfter.text = afterVal.ToString();
        price = (DataManager.Instance.userData.HPAttributeLvl + 1) * 100;
        txtPrice.text = price.ToString();
    }
}
