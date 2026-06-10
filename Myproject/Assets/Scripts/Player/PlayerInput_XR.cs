using UnityEngine;

public class PlayerInput_XR : MonoBehaviour, IPlayerInput
{
    // TODO: MR 手部/手柄输入接入后实现
    // - Move: 摇杆/触摸板 → Vector2
    // - Look: 头显追踪 → Vector2
    // - CollectTriggered: 扳机键按下
    // - InteractTriggered: 握持键按下
    // - InteractReleased: 握持键释放

    public Vector2 Move => Vector2.zero;
    public Vector2 Look => Vector2.zero;
    public bool CollectTriggered => false;
    public bool InteractTriggered => false;
    public bool InteractReleased => false;
}
