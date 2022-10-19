using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMissZoneController : MonoBehaviour
{
    public static event Action OnNoteMiss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("game over");
        GameManager.Instance.SetNextGameState(GameManager.GameState.PlayingGame);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("eeee");
    }


   
}
