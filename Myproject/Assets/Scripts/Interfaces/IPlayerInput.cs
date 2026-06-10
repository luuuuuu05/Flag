using UnityEngine;

public interface IPlayerInput
{
    Vector2 Move { get; }
    Vector2 Look { get; }
    bool CollectTriggered { get; }
    bool InteractTriggered { get; }
    bool InteractReleased { get; }
}
