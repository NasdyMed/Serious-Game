using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

/**
 * Tableau d'affichage des scores du jeu des pneus
 * Scores triés par ordre croissant des temps
 * **/
public class HighscoreTableTires : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    // Start is called before the first frame update
    private void Awake()
    {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTableTires");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        List<HighscoreEntry> sortedList = highscores.highscoreEntries.OrderBy(s => s.time).ToList();
        int c = 0; // only show first 10 people to avoid scrollbar
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in sortedList)
        {
            if (c < 10)
            {
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
                c++;
            }
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 15f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        string name = highscoreEntry.name;
        entryTransform.Find("FullNameText").GetComponent<TextMeshProUGUI>().text = name;

        string time = highscoreEntry.time;
        entryTransform.Find("TimeText").GetComponent<TextMeshProUGUI>().text = time;

        int rank = transformList.Count + 1;
        if (rank == 1)
        {
            entryTransform.Find("FullNameText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("TimeText").GetComponent<TextMeshProUGUI>().color = Color.green;
        }

        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(string name, string time)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { name = name, time = time };
        string jsonString = PlayerPrefs.GetString("highscoreTableTires");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscores.highscoreEntries.Add(highscoreEntry);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTableTires", json);
        PlayerPrefs.Save();

    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntries;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public string name;
        public string time;
    }
}
