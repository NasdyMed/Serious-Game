using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Générateur de pneus : écoute les évènements et fait apparaitre les pneus
 * */
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabPneu;
    private bool spawnedTires = false;
    private int nbPneus;

    void Start()
    {
        EventManager.StartListening("tiresStartButtonPushed", spawnTires);
        EventManager.StartListening("stopTiresGame", resetSpawn);
    }

    void Update()
    {  }

    private void spawnTires(EventParam eventParams)
    {
        if (!spawnedTires)
        {
            nbPneus = eventParams.value; // Lecture du nombre de pneus depuis l'évènement
            spawnedTires = true;
            StartCoroutine(SpawnTiresCoroutine());
        }
    }

    private void resetSpawn(EventParam obj)
    {
        spawnedTires = false;
    }

    // Coroutine d'apparition des pneus : génère un pneu par seconde
    IEnumerator SpawnTiresCoroutine()
    {
        for (int i = 0; i < nbPneus; i++)
        {
            Instantiate(prefabPneu, new Vector3(transform.position.x + UnityEngine.Random.Range(-0.001f, 0.001f), transform.position.y, transform.position.z + UnityEngine.Random.Range(-0.001f, 0.001f)), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }

}
