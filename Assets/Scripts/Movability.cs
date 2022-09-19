using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script des poignées de la grue : permet de vérifier que l'utilisateur tient les deux poignées en même temps
 * */
public class Movability : MonoBehaviour
{
    private bool moveLeft = false;
    private bool moveRight = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(moveLeft || moveRight)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void CanMoveLeft()
    {
        moveLeft = true;
    }
    public void CannotMoveLeft()
    {
        moveLeft = false;
    }
    public void CanMoveRight()
    {
        moveRight = true;
    }
    public void CannotMoveRight()
    {
        moveRight = false;
    }
}
