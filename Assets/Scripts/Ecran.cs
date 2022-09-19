using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Ecran du pupitre du jeu des pneus
 * Affiche les indications pour l'opérateur en fonction de ce qui est lu sur le tapis
 * */
public class Ecran : MonoBehaviour
{
    private Renderer componentRenderer;
    public Texture waitingTex, ErrorTex, okayTex, noscanTex;

    void Start()
    {
        componentRenderer = GetComponent<Renderer>();

        // Ecoute des évènements provenants des lectures (tapis et douchette)
        EventManager.StartListening("tireDefective", displayError);
        EventManager.StartListening("tireConform", displayOkay);
        EventManager.StartListening("tireMissing", displayWaiting);
        EventManager.StartListening("tireNoScan", displayNoScan);
    }

    void Update()
    {
        
    }

    private void displayError(EventParam obj)
    {
        Debug.Log("Affiche erreur");
        componentRenderer.material.SetTexture("_MainTex", ErrorTex);
    }

    private void displayOkay(EventParam obj)
    {
        Debug.Log("Affiche OK");
        componentRenderer.material.SetTexture("_MainTex", okayTex);
    }

    private void displayWaiting(EventParam obj)
    {
        Debug.Log("Affiche Waiting");
        componentRenderer.material.SetTexture("_MainTex", waitingTex);
    }

    private void displayNoScan(EventParam obj)
    {
        Debug.Log("Affiche no scan");
        componentRenderer.material.SetTexture("_MainTex", noscanTex);
    }
}
