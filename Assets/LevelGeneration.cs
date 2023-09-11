using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public List<Transform> transEnemies = new List<Transform>();
    public List<LevelDatasScripable> listLevel = new List<LevelDatasScripable>();
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        //SpawnPerTime();
    }
    public void GenerateLevel()
    {
        // check level nao
        listLevel[0].listPosEnemies.ForEach(x =>
        {
            GameManager.Instance.AddEnemySpawn();
            GameObject o = ObjectPooling.instance.GetObjectFromPool("Enemy");
            o.transform.position = x;
            o.GetComponent<EnemyData>().Setup();
            o.SetActive(true);
        });
    }
    Vector3 randomPos;
    public void SpawnPerTime()
    {
        if (GameManager.Instance.GetActiveEnemy() < listLevel[0].valueOfWaveEnemy)
        {
            //Spawn them enemy
            for (int i = 0; i < listLevel[0].valueOfWaveEnemy - GameManager.Instance.GetActiveEnemy();i++)
            {
                GameObject clone = ObjectPooling.instance.GetObjectFromPool("Enemy");

                //do
                //{
                    randomPos = listLevel[0].listPosEnemies[UnityEngine.Random.RandomRange(0, listLevel[0].listPosEnemies.Count)];
                //}
                //while (Vector3.Distance(PlayerController.Instance.transform.position, randomPos) <= 30f);
                clone.transform.position = randomPos;
                clone.GetComponent<EnemyData>().Setup();
                clone.SetActive(true);
                GameManager.Instance.AddEnemySpawn();
            }
        }
    }
}
