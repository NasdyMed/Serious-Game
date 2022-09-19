using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TiresGame : MonoBehaviour
{
    [SerializeField]
    private Text scoreTiresText;
    [SerializeField]
    private GameObject keyboardTires;
    [SerializeField]
    private GameObject saveButtonTires;
    [SerializeField]
    private GameObject nameTextTires;
    [SerializeField]
    private Canvas highScoreTableTires;


    private int score = 0;
    private int count = 0;
    private int nbPneus;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("goodPoint", goodPoint);
        EventManager.StartListening("wrongPoint", wrongPoint);
        EventManager.StartListening("tiresStartButtonPushed", startGame);
        EventManager.StartListening("tiresStopButtonPushed", emergencyStop);
        
    }

    // Update is called once per frame
    void Update()
    {
                    
    }

    private void emergencyStop(EventParam obj)
    {
        stopGame();
    }

    private void stopGame()
    {
        // Ajouter au tableau des scores

        EventManager.TriggerEvent("stopTiresGame", new EventParam());

        var Spell1 = GameObject.FindGameObjectsWithTag("Pneu");
        if (Spell1.Length > 1)
        {   // Spell1 contient au moins un element
            for (int i = 0; i < Spell1.Length; i++)
            {
                Destroy(Spell1[i]);
            }
        }

        if(score == nbPneus)
        {
            keyboardTires.SetActive(true);
            saveButtonTires.SetActive(true);
            nameTextTires.SetActive(true);
        }

    }

    private void checkResults()
    {
        scoreTiresText.text = "Score : " + score.ToString();
        if(count == nbPneus)
        {
            // Ajout tableau scores
            stopGame();
        }
    }

    private void goodPoint(EventParam obj)
    {
        score++;
        count++;
        checkResults();
    }

    private void wrongPoint(EventParam obj)
    {
        score--;
        count++;
        checkResults();
    }

    private void startGame(EventParam obj)
    {
        nbPneus = obj.value;
        score = 0;
        count = 0;
        scoreTiresText.text = "Score : " + score.ToString();

        keyboardTires.SetActive(false);
        saveButtonTires.SetActive(false);
        nameTextTires.SetActive(false);
    }
}
