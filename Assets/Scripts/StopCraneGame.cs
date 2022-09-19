using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Permet l'arrêt du chrono du jeu de la grue
 * */
public class StopCraneGame : MonoBehaviour
{
    private bool flag = false;

    [SerializeField]
    private GameObject line;
    [SerializeField]
    private GameObject keyboard;
    [SerializeField]
    private GameObject saveButton;
    [SerializeField]
    private GameObject nameText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Effecteur")
        {
            if (!flag)
            {
                EventManager.TriggerEvent("StopChrono", new EventParam());
                flag = true;
                gameObject.SetActive(false);
                line.SetActive(false);
                keyboard.SetActive(true);
                saveButton.SetActive(true);
                nameText.SetActive(true);
            }
        }
    }
}
