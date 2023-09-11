using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterElementUI : MonoBehaviour
{
    public int id;
    public List<Text> txtAttribute = new List<Text>();
    public Image preview;
    public Button btnBuy;
    public Text txtPrice;
    public Button btnSelect;
    public GameObject selectedObj;
    private CharacterScriptableObj data;
    int status = 0;
    private void Awake()
    {
        btnBuy.onClick.AddListener(OnClickBtnBuy);
        btnSelect.onClick.AddListener(OnClickBtnSelect);
    }
    public void SetupUI(int _id, CharacterScriptableObj _data)
    {
        id = _id;
        data = _data;
        txtAttribute[0].text = data.damage.ToString();
        txtAttribute[1].text = data.hp.ToString();
        txtAttribute[2].text = data.defend.ToString();
        txtAttribute[3].text = data.luckyRate.ToString();
        preview.sprite = data.previewCharacter;
        txtPrice.text = data.price.ToString();
        status = DataManager.Instance.userData.GetCharacterStatus(id);
        UpdateStatusElement();
    }
    public void UpdateStatusElement()
    {
        status = DataManager.Instance.userData.GetCharacterStatus(id);
        switch (status)
        {
            case 0:
                btnBuy.gameObject.SetActive(true);
                btnSelect.gameObject.SetActive(false);
                selectedObj.SetActive(false);
                //if (DataManager.Instance.userData.CurrentCoin < data.price) btnBuy.interactable = false;
                //else btnBuy.interactable = true;
                break;
            case 1:
                btnBuy.gameObject.SetActive(false);
                btnSelect.gameObject.SetActive(true);
                selectedObj.SetActive(false);
                break;
            case 2:
                DataManager.Instance.userData.CurrentCharacter = id;
                btnBuy.gameObject.SetActive(false);
                btnSelect.gameObject.SetActive(false);
                selectedObj.SetActive(true);
                break;

        }

    }
    private void OnClickBtnBuy()
    {
        Debug.LogError($"{DataManager.Instance.userData.CurrentCoin}||{data.price}");
        if (DataManager.Instance.userData.CurrentCoin < data.price) return;
        DataManager.Instance.userData.CurrentCoin-=data.price;
        DataManager.Instance.userData.SaveCharacterStatus(id, 1);
        UpdateStatusElement();
    }
    private void OnClickBtnSelect()
    {
        DataManager.Instance.userData.SaveCharacterStatus(DataManager.Instance.userData.CurrentCharacter, 1);
        DataManager.Instance.userData.SaveCharacterStatus(id, 2);
        ShopElementManager.Instance.UpdateUICharacterScroll();
    }
}
