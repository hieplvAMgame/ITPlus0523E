using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopElementManager : Singleton<ShopElementManager>
{
    public Transform contentScrollView;
    public Type_Generate type = Type_Generate.Character;


    public CharacterElementUI characterElementUI;
    private List<CharacterScriptableObj> datas = new List<CharacterScriptableObj>();
    private List<CharacterElementUI> listUICharacter = new List<CharacterElementUI>();

    public List<Sprite> spriteAttribute = new List<Sprite>();
    public AttributeElementUI attributeElementUI;
    private List<AttributeElementUI> attributeElementUIs = new List<AttributeElementUI>();

    public List<Button> tabButton = new List<Button>();
    private void Awake()
    {
        datas = GlobalConfig.Instance.characterDatas;
        for(int i = 0; i < tabButton.Count; i++)
        {
            int _index = i;
            tabButton[_index].onClick.AddListener(() => OnClickTabButton((Type_Generate)_index));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        OnClickTabButton(type);
    }

    CharacterElementUI clone = null;
    AttributeElementUI clone1 = null;
    public void GenElement(Type_Generate type = Type_Generate.Character)
    {
        switch (type)
        {
            case Type_Generate.Character:
                listUICharacter.Clear();
                attributeElementUIs.ForEach(x => DestroyImmediate(x.gameObject));
                attributeElementUIs.Clear();
                for (int i = 0; i < datas.Count; i++)
                {
                    int _index = i;
                    clone = Instantiate(characterElementUI, contentScrollView);
                    clone.SetupUI(_index, datas[_index]);
                    listUICharacter.Add(clone);
                    clone.gameObject.SetActive(true);
                }
                break;
            case Type_Generate.Attribute:
                listUICharacter.ForEach(x => DestroyImmediate(x.gameObject));
                listUICharacter.Clear();
                attributeElementUIs.Clear();
                for(int i = 0; i < 4; i++)
                {
                    clone1 = Instantiate(attributeElementUI, contentScrollView);
                    clone1.SetupUI(i);
                    attributeElementUIs.Add(clone1);
                    clone1.gameObject.SetActive(true);
                }
                break;
        }
    }
    public void UpdateUICharacterScroll()
    {
        listUICharacter.ForEach(x => x.UpdateStatusElement());
    }
    private void OnClickTabButton(Type_Generate _type)
    {
        Debug.LogError(_type.ToString());
        type = _type;
        GenElement(type);
    }
}
public enum Type_Generate
{
    Character,
    Attribute,
    Weapon
}
