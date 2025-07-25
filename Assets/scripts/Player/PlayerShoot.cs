using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerShoot : MonoBehaviour
{
    public string bulletTag = "Bullet";
    public float fireRate = 0.2f; 
    private float fireTimer = 0f;
    public List<Transform> shootPoint; 
    private List<int> NumberCanShoot = new List<int>();

    void Start()
    {
        NumberCanShoot.AddRange(new int[] { 0, 1, 4, 5 });
    }

    public void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)&& fireTimer >= fireRate)
        {
            foreach (int index in NumberCanShoot)
            {
                if (index >= 0 && index < shootPoint.Count)
                {
                    ObjectPooler.Instance.SpawnFromPool(bulletTag, shootPoint[index].position, shootPoint[index].rotation);
                }
            }
            fireTimer = 0f;
        }
    }
    
    [Button]
    public void UpgradeSpawnBullet()
    {
        if (!NumberCanShoot.Contains(2)) NumberCanShoot.Add(2);
        if (!NumberCanShoot.Contains(3)) NumberCanShoot.Add(3);
    }
    
}
