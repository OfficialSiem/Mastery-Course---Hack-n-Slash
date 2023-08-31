
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerNumber;

    public Controller Controller { get; private set; }

    private UIPlayerText playerText;

    //HasController can not be set, instead we can only check whether the controler actually exists, or is null!
    public bool HasController { get { return Controller!=null; } }
    public int PlayerNumber { get { return playerNumber; } }


    private void Awake()
    {
        playerText= GetComponentInChildren<UIPlayerText>();
    }

    public void InitializePlayer(Controller controller)
    {
        this.Controller = controller;

        //{0} takes the first parameter we write-- just more preformant than writting a bunch of  ("abc " + vairable + " jkl")
        //examples we use in concatinating strings with data from variables
        gameObject.name = string.Format("Player {0} - {1}", playerNumber, Controller.gameObject.name);

        playerText.HandlePlayerInitalized(playerNumber);
    }
}
