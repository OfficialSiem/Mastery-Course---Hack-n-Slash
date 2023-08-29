
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int playerNumber;

    private Controller controller;

    private UIPlayerText playerText;

    //HasController can not be set, instead we can only check whether the controler actually exists, or is null!
    public bool HasController { get { return controller!=null; } }
    public int PlayerNumber { get { return playerNumber; } }


    private void Awake()
    {
        playerText= GetComponentInChildren<UIPlayerText>();
    }

    public void InitializePlayer(Controller controller)
    {
        this.controller = controller;

        //{0} takes the first parameter we write-- just more preformant than writting a bunch of  ("abc " + vairable + " jkl")
        //examples we use in concatinating strings with data from variables
        gameObject.name = string.Format("Player {0} - {1}", playerNumber, controller.gameObject.name);

        playerText.HandlePlayerInitalized();
    }
}
