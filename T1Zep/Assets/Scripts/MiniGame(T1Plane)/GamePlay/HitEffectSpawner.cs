using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectPrefab;

    public void SpawnEffect(Vector2 position)
    {
        if (hitEffectPrefab != null)
        {
            GameObject fx = Instantiate(hitEffectPrefab, position, Quaternion.identity);
            Destroy(fx, 1.0f);
        }
    }
}
