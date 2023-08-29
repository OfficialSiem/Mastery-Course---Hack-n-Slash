using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player[] players;

    private void Awake()
    {
        players = FindObjectsOfType<Player>();

    }

    internal void AddPlayerToGame(Controller controller)
    {
        //go through the array,
        //order the array by player number
        //then find the first controller in the organized list, that's inactive 
        var firstNonActivePlayer = players
            .OrderBy(t => t.PlayerNumber)
            .FirstOrDefault(t => t.HasController == false);

        firstNonActivePlayer.InitializePlayer(controller);
    }
}
