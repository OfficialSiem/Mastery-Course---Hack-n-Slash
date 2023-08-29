using System.Collections;
using TMPro;
using UnityEngine;

public class UIPlayerText : MonoBehaviour
{
    private TextMeshProUGUI tmText;

    [SerializeField]
    private float howManySecondsToWait = 2.0f;

    private void Awake()
    {
        tmText = GetComponent<TextMeshProUGUI>();
    }

    internal void HandlePlayerInitalized()
    {
        tmText.text = "Player Joined";

        StartCoroutine(ClearTextAfterDelay(howManySecondsToWait));
    }

    private IEnumerator ClearTextAfterDelay(float howManySecondsToWait)
    {
        yield return new WaitForSeconds(howManySecondsToWait);
        tmText.text = string.Empty;
    }

}
