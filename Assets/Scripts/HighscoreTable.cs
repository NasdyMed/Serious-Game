using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

/**
 * Tableau d'affichage des scores du jeu de la grue
 * Joueurs classés par scores croissants puis par temps décroissants (à scores identiques)
 * */
public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        List<HighscoreEntry> sortedList = highscores.highscoreEntries.OrderByDescending(s => s.score).ThenBy(t => t.time).ToList();
        int c = 0; // only show first 10 people to avoid scrollbar
        highscoreEntryTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in sortedList)
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

        string score = highscoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = score;

        string time = highscoreEntry.time;
        entryTransform.Find("TimeText").GetComponent<TextMeshProUGUI>().text = time;

        int rank = transformList.Count + 1;
        if (rank == 1)
        {
            entryTransform.Find("FullNameText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("TimeText").GetComponent<TextMeshProUGUI>().color = Color.green;
        }

        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(string name, string score, string time)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { name = name, score = score, time = time };
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        highscores.highscoreEntries.Add(highscoreEntry);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
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
        public string score;
        public string time;
    }
}
