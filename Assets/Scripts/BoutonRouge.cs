using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

/**
 * Bouton rouge d'arrêt d'urgence du jeu des pneus
 * */
public class BoutonRouge : MonoBehaviour
{
    private Interactable detectRouge;
    private bool pushDetected = false;

    void Start()
    {
        detectRouge = GetComponent<Interactable>();
    }

    void Update()
    {
        if (detectRouge.isHovering && !pushDetected)
        {
            EventManager.TriggerEvent("tiresStopButtonPushed", new EventParam());
            pushDetected = true;
        }
        else if (!detectRouge.isHovering)
        {
            pushDetected = false;
        }
    }
}
