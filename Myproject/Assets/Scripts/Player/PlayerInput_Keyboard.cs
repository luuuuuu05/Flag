using UnityEngine;

public class PlayerInput_Keyboard : MonoBehaviour, IPlayerInput
{
    public Vector2 Move { get; private set; }
    public Vector2 Look { get; private set; }
    public bool CollectTriggered { get; private set; }
    public bool InteractTriggered { get; private set; }
    public bool InteractReleased { get; private set; }

    [SerializeField] private KeyCode collectKey = KeyCode.J;
    [SerializeField] private KeyCode interactKey = KeyCode.G;

    private void Update()
    {
        Move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        CollectTriggered = Input.GetKeyDown(collectKey);
        InteractTriggered = Input.GetKeyDown(interactKey);
        InteractReleased = Input.GetKeyUp(interactKey);
    }
}
