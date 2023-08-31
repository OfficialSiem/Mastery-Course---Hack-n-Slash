using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UiCharacterSelectionMarker : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Image markerImage;
    [SerializeField]
    private Image lockImage;

    [SerializeField]
    private float howManySecondsToWaitForInitalization = 0.5f;

    [SerializeField]
    private float horzizontalThresholdForMovingCharacterSelectionMarker = 0.5f;

    [SerializeField]
    private float verticalThresholdForMovingCharacterSelectionMarker = 0.5f;

    private UiCharacterSelectionMenu menu;
    private bool initalizing;
    private bool initialized;

    public bool IsLockedIn { get; private set; }

    //Meaning if a player is using a controller 
    public bool IsPlayerIn { get { return player.HasController; } }

    private void Awake()
    {
        //Grab the menu if it exists
        menu = GetComponentInParent<UiCharacterSelectionMenu>();

        //Turn off all markers [until player joins]
        markerImage.gameObject.SetActive(false);
        lockImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (IsPlayerIn == false)
            return;

        if (!initalizing)
            StartCoroutine(Initalize());

        if (!initialized)
            return;

        //if the player hadn't locked in a character & Check for playter controls and selection
        if (!IsLockedIn)
        {
            if (player.Controller.horizontal > horzizontalThresholdForMovingCharacterSelectionMarker)
            {
                MoveToCharacterPanel(menu.RightPanel);
            }
            if (player.Controller.horizontal < -horzizontalThresholdForMovingCharacterSelectionMarker)
            {
                MoveToCharacterPanel(menu.LeftPanel);
            }
            if (player.Controller.attackPressed)
            {
                LockCharacter();
            }
        }
    }

    private void LockCharacter()
    {
        IsLockedIn = true;
        lockImage.gameObject.SetActive(true);
        markerImage.gameObject.SetActive(false);
    }

    private void MoveToCharacterPanel(UICharacterSelectionPanel panel)
    {
        transform.position = panel.transform.position;
    }

    private IEnumerator Initalize()
    {
        initalizing = true;

        MoveToCharacterPanel(menu.LeftPanel);

        //so we can prevent registering and double button presses or shinanginens,
        // we can wait for a few moments after initalizing starts
        yield return new WaitForSeconds(howManySecondsToWaitForInitalization);

        markerImage.gameObject.SetActive(true);
        initialized = true;
    }
}
