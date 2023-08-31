using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCharacterSelectionMenu : MonoBehaviour
{
    [SerializeField]
    private UICharacterSelectionPanel leftPanel;

    [SerializeField]
    private UICharacterSelectionPanel rightPanel;

    [SerializeField]
    TMPro.TextMeshProUGUI startGameText;

    [SerializeField]
    private UiCharacterSelectionMarker[] markers;

    public UICharacterSelectionPanel LeftPanel { get { return leftPanel; } }
    public UICharacterSelectionPanel RightPanel { get { return rightPanel; } }

    private void Awake()
    {
        markers = GetComponentsInChildren<UiCharacterSelectionMarker>();
    }

    private void Update()
    {
        int playerCount = 0;
        int lockedCount = 0;

        foreach (var marker in markers)
        {
            if(marker.IsPlayerIn)
                playerCount++;

            if(marker.IsLockedIn)
                lockedCount++;
        }

        //Start the game if we have at least one player,
        // and the total number of characeters selected equals the number of players!
        bool startEnabled = (playerCount > 0) && (playerCount == lockedCount);

        startGameText.gameObject.SetActive(startEnabled);

    }

}
