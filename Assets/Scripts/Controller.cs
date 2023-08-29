using UnityEngine;

public class Controller : MonoBehaviour
{
    //What button does what attack/move

    //What player is pressing button

    //What button was actually pressed

    public int Index { get; private set; }
    public bool IsAssigned { get; set; }

    private string attackButton;

    public bool attack;

    private void Start()
    {
        if(!string.IsNullOrEmpty(attackButton))
        {
            attackButton = "Attack" + Index;
        }
    }

    private void Update()
    {
        attack = Input.GetButton(attackButton);
    }

    internal void SetIndex(int index)
    {
        Index = index;
        attackButton = "Attack" + Index;
        gameObject.name = "Controller" + Index;
    }

    internal bool AnyButtonDown()
    {
        return attack;
    }
}
