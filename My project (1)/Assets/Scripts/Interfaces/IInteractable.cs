using UnityEngine;

public interface IInteractable
{
    bool CanInteract { get; }
    void OnGrab(Transform grabber);
    void OnRelease(Vector3 direction, float force);
}
