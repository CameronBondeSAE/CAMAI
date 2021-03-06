﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public int maxClones;
    public int arenaSize;

    public event Action<GameObject> OnSpawnedNewGameObject;

    public float timedSpawnInterval;
    public int timedSpawnMaxSpawned = 10;

    public bool checkForEmptySpace = false;
    public LayerMask layerMask;

    public List<GameObject> thingsISpawned;

    // Use this for initialization
    IEnumerator Start()
    {
        // TODO HACK NodeCanvas for some reason needs a delay, or the Script actions link back to the prefab, instead of the instance
        yield return new WaitForSeconds(1);

        foreach (GameObject item in prefabs)
        {
            for (int i = 0; i < maxClones; i++)
            {
                Spawn(item);
            }
        }

        if (timedSpawnInterval > 0)
        {
            InvokeRepeating("Spawn", timedSpawnInterval, timedSpawnInterval);
        }
    }

    void Spawn()
    {
        Spawn(prefabs[prefabs.Count - 1]);
    }

    private void Spawn(GameObject item)
    {
        if (item == null)
            return;

        // For timed spawning, cap it at a sensible max
        if (timedSpawnInterval>0)
        {
            if (thingsISpawned.Count >= timedSpawnMaxSpawned)
            {
                return;
            }
        }
        
        
        Vector3 randomPosition = new Vector3();

        // Check for things in the way and try again (Bail after 100 tries)

        if (checkForEmptySpace)
        {
            for (int i = 0; i < 100; i++)
            {
                randomPosition = transform.position + new Vector3(Random.Range(-arenaSize, arenaSize), 0,
                                     Random.Range(-arenaSize, arenaSize));
                if (!Physics.CheckSphere(randomPosition, 0.1f, layerMask, QueryTriggerInteraction.Ignore))
//					if (!Physics.Raycast(randomPosition, Vector3.up, 1f, layerMask, QueryTriggerInteraction.Ignore))
//					if (!Physics.Raycast(randomPosition, Vector3.up, 10f))
                {
                    Debug.DrawLine(randomPosition, randomPosition + Vector3.up * 5f, Color.green, 3);
//						Debug.Log("Spawner: Found empty spot");
                    break;
                }
                else
                {
                    Debug.DrawLine(randomPosition, randomPosition + Vector3.up * 5f, Color.red, 3);
                    Debug.Log("Spawner: Location blocked, trying again");
                }
            }
        }
        else
        {
            randomPosition = transform.position + new Vector3(Random.Range(-arenaSize, arenaSize), 0,
                                 Random.Range(-arenaSize, arenaSize));
        }

        var newGO = Instantiate(item, randomPosition, Quaternion.identity);
//        Debug.Log("Spawned: "+item.name);

        thingsISpawned.Add(newGO);
        Health health = newGO.GetComponent<Health>();
        if (health != null) health.OnDeathEventGameObject += go => thingsISpawned.Remove(go);

        if (OnSpawnedNewGameObject != null)
            OnSpawnedNewGameObject(newGO);
    }
}