using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

/**
 * Permet de relancer la scène dans les conditions d'origine (pour relancer les jeux)
 * */
public class ReloadScene : MonoBehaviour
{
    Interactable button;

    void Start()
    {
        button = GetComponent<Interactable>();
    }

    void Update()
    {
        if (button.isHovering)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            RenderSettings.ambientIntensity = 1;
        }
    }
}
