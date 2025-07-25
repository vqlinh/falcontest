using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BotSpawnData
{
    public GameObject prefab;
    public Vector2Int gridPosition; // hàng, cột
    public Vector2 offset; 
}