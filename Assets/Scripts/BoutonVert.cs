using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

/**
 * Détection appui sur bouton de départ du jeu des pneus
 * */
public class BoutonVert : MonoBehaviour
{
    private Interactable detectVert;
    private bool pushDetected = false;

    // Nombre de pneus à générer (le calcul du score en dépend)
    private int nbPneus = 1;

    void Start()
    {
        detectVert = GetComponent<Interactable>();
    }

    void Update()
    {
        if (detectVert.isHovering && !pushDetected)
        {
            // Passage du nombre de pneus à générer en paramètre de l'évènement
            EventParam eventParams = new EventParam();
            eventParams.value = nbPneus;
            EventManager.TriggerEvent("tiresStartButtonPushed", eventParams);
            pushDetected = true;
        }
        else if (!detectVert.isHovering)
        {
            pushDetected = false;
        }
    }
}
