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
        if (player.HasController == false)
            return;

        if (!initalizing)
            StartCoroutine(Initalize());

        if (!initialized)
            return;

        // Check for playter controls and selection + locking character
        if (player.Controller.horizontal > horzizontalThresholdForMovingCharacterSelectionMarker)
        {
            MoveToCharacterPanel(menu.RightPanel);
        }
        if (player.Controller.horizontal < -horzizontalThresholdForMovingCharacterSelectionMarker)
        {
            MoveToCharacterPanel(menu.LeftPanel);
        }
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
