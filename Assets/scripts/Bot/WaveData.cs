using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Bot/WaveData")]
public class WaveData : ScriptableObject
{
    public List<BotSpawnData> botsInWave;
}