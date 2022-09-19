using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script de la douchette pour scanner manuellement les pneus
 * */
public class Scanner : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // Lancement d'un rayon pour lire le code-bares
        RaycastHit hit;
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.forward) * 100, Color.blue);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.forward), out hit))
        {
            Transform scanned = hit.collider.transform;
            if (scanned)
            {
                // Vérification que l'objet détecté est bien un code-bares
                if (scanned.name == "BarCode")
                {
                    // Récupération du pneu et des propriétés associées
                    Transform parentTransform = scanned.parent;
                    TireProperties tireProperties = (TireProperties)parentTransform.GetComponent<TireProperties>();

                    if(!tireProperties.scannable)
                    {
                        // Emission de l'évènement approprié (à destination de l'écran)
                        if (tireProperties.defective)
                        {
                            Debug.Log("Défectueux");
                            EventManager.TriggerEvent("tireDefective", new EventParam());
                        }
                        else
                        {
                            EventManager.TriggerEvent("tireConform", new EventParam());
                            Debug.Log("Conforme");
                        }
                    }
                    else
                    {
                        Debug.Log("Objet déjà scanné");
                    }
                }
            }

        }
    }
}
