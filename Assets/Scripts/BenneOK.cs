using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Benne verte : détecte les pneus déposés et émet l'évènement correspondant (placmeent correct ou incorrect selon les propriétés du pneu)
 * */
public class BenneOK : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.parent != null)
        {
            Transform parentTransform = collider.gameObject.transform.parent;

            if (parentTransform.tag == "Pneu")
            {
                TireProperties tireProperties = (TireProperties)parentTransform.GetComponent<TireProperties>();

                if(!tireProperties.validated)
                {
                    if (!tireProperties.defective)
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

                    Destroy(parentTransform.gameObject);
                }
            }
        }

    }
}
