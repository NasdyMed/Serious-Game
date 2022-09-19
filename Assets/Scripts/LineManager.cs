using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Script calculant le score en fonction de la présence de l'effecteur sur la ligne
 * */
public class LineManager : MonoBehaviour
{
    [SerializeField]
    private GameObject redColor;
    [SerializeField]
    private GameObject greenColor;

    private float scoreFloat;
    private int scoreInt;
    private bool scoreDecrease = false;
    private bool gameEnded = false;

    [SerializeField]
    private Text scoreText;

    void Start()
    {
        scoreFloat = 300;
        scoreInt = 300;
        scoreText.text = "Score = " + scoreInt.ToString();
        EventManager.StartListening("StopChrono", StopGame);
    }

    void Update()
    {
        if (!gameEnded && scoreDecrease)
        {
            scoreFloat -= 5 * Time.deltaTime;
            scoreInt = (int)scoreFloat;
        }
        scoreText.text = "Score = " + scoreInt.ToString();
    }

    // Détection de la présence de l'effecteur sur la ligne
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Effecteur")
        {
            gameObject.GetComponent<MeshRenderer>().material = greenColor.GetComponent<MeshRenderer>().material;
            scoreDecrease = false;
        }
    }

    // Détection de l'absence de l'effecteur : décrémentation du score activée
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Effecteur")
        {
            gameObject.GetComponent<MeshRenderer>().material = redColor.GetComponent<MeshRenderer>().material;
            scoreDecrease = true;
        }
    }

    // Arrêt des détections
    private void StopGame(EventParam obj)
    {
        gameEnded = true;
    }
    
}
