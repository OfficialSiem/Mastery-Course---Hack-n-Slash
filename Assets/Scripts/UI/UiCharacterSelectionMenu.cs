using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCharacterSelectionMenu : MonoBehaviour
{
    [SerializeField]
    private UICharacterSelectionPanel leftPanel;

    [SerializeField]
    private UICharacterSelectionPanel rightPanel;

    public UICharacterSelectionPanel LeftPanel { get { return leftPanel; } }
    public UICharacterSelectionPanel RightPanel { get { return rightPanel; } }

}
