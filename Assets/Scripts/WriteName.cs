using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

/**
 * Script du clavier et de la gestion de la sauvegarde pour le jeu de la grue
 * */
public class WriteName : MonoBehaviour
{
    private bool flag = false;
    Interactable key;
    private TextMeshPro playerTextOutput;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private GameObject highscoreTable;
    [SerializeField]
    private Canvas table;
    [SerializeField]
    private GameObject keyboard;
    [SerializeField]
    private GameObject nameText;
    [SerializeField]
    private GameObject playerName;
    [SerializeField]
    private GameObject reloadScene;
    [SerializeField]
    private GameObject redColor;
    [SerializeField]
    private GameObject greenColor;

    void Start()
    {
        // Code pour effacer les scores persistés en mémoire
        //PlayerPrefs.DeleteKey("highscoreTable");

        key = GetComponent<Interactable>();
        playerTextOutput = GameObject.FindGameObjectWithTag("PlayerTextOutput").GetComponentInChildren<TextMeshPro>();
    }

    void Update()
    {
        if(!flag && key.isHovering)
        {
            flag = true;

            // Sauvegarde de la partie en mémoire (format JSON)
            if (gameObject.name == "Save")
            {
                if (playerTextOutput.text.Split(' ').Last() != "")
                {
                    if (PlayerPrefs.HasKey("highscoreTable") == false)
                    {
                        Highscores emptyHighscores = new Highscores { highscoreEntries = { } };
                        string json = JsonUtility.ToJson(emptyHighscores);
                        PlayerPrefs.SetString("highscoreTable", json);
                        PlayerPrefs.Save();
                    }

                    highscoreTable.GetComponent<HighscoreTable>().AddHighscoreEntry(playerTextOutput.text, scoreText.text.Split(' ').Last(), timeText.text.Split(' ').Last());
                    table.gameObject.SetActive(true);
                    reloadScene.SetActive(true);

                    keyboard.SetActive(false);
                    gameObject.SetActive(false);
                    nameText.SetActive(false);
                    playerName.SetActive(false);
                }
                else
                {
                    // Si le nom est vide, le bouton de sauvegarde est coloré en rouge pendant une seconde
                    StartCoroutine(Coroutine());
                }
            }
            else if (gameObject.name == "Space")
            {
                playerTextOutput.text += " ";
            }
            else if (gameObject.name == "Delete")
            {
                if (playerTextOutput.text.Length > 0)
                {
                    playerTextOutput.text = playerTextOutput.text.Substring(0, playerTextOutput.text.Length - 1);
                }
            }
            else
            {
                playerTextOutput.text += gameObject.name;
            }
        }
        else if (!key.isHovering)
        {
            flag = false;
        }
    }

    IEnumerator Coroutine()
    {
        gameObject.GetComponent<Renderer>().material = redColor.GetComponent<Renderer>().material;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material = greenColor.GetComponent<Renderer>().material;
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntries;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public string name;
        public string score;
        public string time;
    }
}
