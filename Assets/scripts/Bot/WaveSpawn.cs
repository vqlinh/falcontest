using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public List<WaveData> waveList;

    public float cellSize = 1.5f;
    public Vector2 gridOrigin = Vector2.zero;

    public List<GameObject> listBot = new List<GameObject>();

    [Button("Spawn All Waves")]
    public void SpawnAllWaves()
    {
        ClearBots();

        foreach (WaveData wave in waveList)
        {
            foreach (var bot in wave.botsInWave)
            {
                Vector2 spawnPos = gridOrigin + new Vector2(bot.gridPosition.x * cellSize, bot.gridPosition.y * cellSize) + bot.offset;
                GameObject newBot = Instantiate(bot.prefab, spawnPos, Quaternion.identity, this.transform);
                listBot.Add(newBot);
            }
        }
    }

    [Button("Clear All Bots")]
    public void ClearBots()
    {
        foreach (GameObject bot in listBot)
        {
            if (bot != null) DestroyImmediate(bot);
        }

        listBot.Clear();
    }
}