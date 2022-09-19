using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Permet de lancer le jeu, affiche le chemin à suivre avec l'effecteur
 * */
public class ShowPath : MonoBehaviour
{
    [SerializeField]
    GameObject line;
    [SerializeField]
    GameObject endCube;

    private bool flag = false;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Effecteur")
        {
            line.SetActive(true);
            endCube.SetActive(true);
            if (!flag)
            {
                EventManager.TriggerEvent("StartChronoCrane", new EventParam());
                flag = true;
            }
        }
    }
}
