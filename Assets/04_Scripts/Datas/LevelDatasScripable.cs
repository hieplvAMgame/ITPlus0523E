using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Level", menuName = "New Data Level")]
public class LevelDatasScripable : ScriptableObject
{
    public Vector3 posPlayer;
    public List<Vector3> listPosEnemies = new List<Vector3>();
    public int valueOfWaveEnemy => listPosEnemies.Count;
}
