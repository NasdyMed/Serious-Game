using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Lecture des pneus sur le tapis
 * */
public class Tapis : MonoBehaviour
{
    bool isTirePresent = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    void OnTriggerStay(Collider collider)
    {
        if (!isTirePresent)
        {
            isTirePresent = true;

            if (collider.gameObject.transform.parent != null)
            {
                Transform parentTransform = collider.gameObject.transform.parent;

                if (parentTransform.tag == "Pneu")
                {
                    Debug.Log("Pneu identifié");
                    TireProperties tireProperties = (TireProperties)parentTransform.GetComponent<TireProperties>();

                    Debug.Log(tireProperties.scannable);

                    if (tireProperties.scannable)
                    {
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
                        EventManager.TriggerEvent("tireNoScan", new EventParam());
                        Debug.Log("Non détectable");
                    }
                }
            }

        }   
    }

    void OnTriggerExit(Collider collider)
    {
        isTirePresent = false;
        EventManager.TriggerEvent("tireMissing", new EventParam());
    }
}
