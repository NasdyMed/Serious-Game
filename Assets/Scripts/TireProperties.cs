using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script portant les propriétés individuelles de chaque pneu
 * */
public class TireProperties : MonoBehaviour
{
    public bool defective { get; set; }
    public bool scannable { get; set; }
    public bool validated { get; set; }

    void Start()
    {
        // Génération aléatoire des propriétés du pneu à la création
        if (UnityEngine.Random.Range(0, 2) == 1) defective = true;
        else defective = false;

        if (UnityEngine.Random.Range(0, 2) == 1) scannable = true;
        else scannable = false;

        validated = false;
    }
}
