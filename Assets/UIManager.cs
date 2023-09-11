using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IGameSubcriber
{
    public GameObject gameWinObj;
    public GameObject gameLoseObj;
    public Button btnStart;
    public Button btnHome;
    private void Awake()
    {
        btnHome.onClick.AddListener(() => SceneLoader.Instance.LoadScene("Home"));
    }
    public void GameLose()
    {
        gameLoseObj.SetActive(true);
    }

    public void GamePause()
    {
    }

    public void GamePrepare()
    {
        gameLoseObj.SetActive(false);
        gameWinObj.SetActive(false);
        btnStart.gameObject.SetActive(true);
    }

    public void GameResume()
    {
    }

    public void GameStart()
    {

    }

    public void GameWin()
    {
        gameWinObj.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddSubcriber(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
