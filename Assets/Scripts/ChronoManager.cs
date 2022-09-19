using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Gestion des chronomètres des deux jeux
 * */
public class ChronoManager : MonoBehaviour
{
    private float chronoFloat;
    private int chronoInt;
    private bool chronoCrane = false;
    private bool chronoTires = false;

    [SerializeField]
    private Text timeCraneText;

    [SerializeField]
    private Text timeTiresText;

    void Start()
    {
        chronoFloat = 0;
        chronoInt = 0;
        timeCraneText.text = "Time : " + chronoInt.ToString() + "s";
        timeTiresText.text = "Time : " + chronoInt.ToString() + "s";
        
        // Ecoute évènements pneus
        EventManager.StartListening("tiresStartButtonPushed", StartChronoTires);
        EventManager.StartListening("stopTiresGame", StopChrono);

        // Ecoute évènements grue
        EventManager.StartListening("StartChronoCrane", StartChronoCrane);
        EventManager.StartListening("StopChrono", StopChrono);
    }

    void Update()
    {
        if (chronoCrane)
        {
            chronoFloat += Time.deltaTime;
            chronoInt = (int)chronoFloat;
            timeCraneText.text = "Time : " + chronoInt.ToString() + "s";
        }
        if (chronoTires)
        {
            chronoFloat += Time.deltaTime;
            chronoInt = (int)chronoFloat;
            timeTiresText.text = "Time : " + chronoInt.ToString() + "s";
        }
    }

    private void StartChronoCrane(EventParam obj)
    {
        chronoFloat = 0f;
        chronoCrane = true;
        chronoTires = false;
    }

    private void StartChronoTires(EventParam obj)
    {
        chronoFloat = 0f;
        chronoTires = true;
        chronoCrane = false;
    }

    private void StopChrono(EventParam obj)
    {
        chronoCrane = false;
        chronoTires = false;
    }
}
