using UnityEngine;

public class Controller : MonoBehaviour
{
    //What button does what attack/move

    //What player is pressing button

    //What button was actually pressed

    public int Index { get; private set; }
    public bool IsAssigned { get; set; }

    private string attackButton;
    private string horizontalAxis;
    private string verticalAxis;

    public bool attack;
    public bool attackPressed;
    public float horizontal;
    public float vertical;

    private void Start()
    {
        if(!string.IsNullOrEmpty(attackButton))
        {
            attackButton = "Attack" + Index;
        }
    }

    private void Update()
    {
        //attack putton pressed
        attack = Input.GetButton(attackButton);

        //was attack pressed down on that frame
        attackPressed = Input.GetButtonDown(attackButton);

        horizontal = Input.GetAxis(horizontalAxis);
        vertical = Input.GetAxis(verticalAxis);
    }

    internal void SetIndex(int index)
    {
        Index = index;
        attackButton = "Attack" + Index;
        horizontalAxis = "Horizontal" + Index;
        verticalAxis = "Vertical" + Index;
        gameObject.name = "Controller" + Index;
    }

    internal bool AnyButtonDown()
    {
        return attack;
    }
}
