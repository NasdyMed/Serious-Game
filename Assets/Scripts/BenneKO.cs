using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gestion de la benne rouge : pneus de mauvaise qualité
 * */
public class BenneKO : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    // Détection du dépôt des pneus
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.parent != null)
        {
            Transform parentTransform = collider.gameObject.transform.parent;

            if (parentTransform.tag == "Pneu")
            {
                TireProperties tireProperties = (TireProperties)parentTransform.GetComponent<TireProperties>();

                if (!tireProperties.validated)
                {
                    // Emission de l'évènement pour calcul du score (pneu déposé dans la bonne benne ou non)
                    if (tireProperties.defective)
                    {
                        Debug.Log("goodPoint");
                        EventManager.TriggerEvent("goodPoint", new EventParam());
                    }
                    else
                    {
                        Debug.Log("wrongPoint");
                        EventManager.TriggerEvent("wrongPoint", new EventParam());
                    }

                    tireProperties.validated = true;

                    // Destruction du pneu une fois traité
                    Destroy(parentTransform.gameObject);
                }
            }
        }

    }
}
