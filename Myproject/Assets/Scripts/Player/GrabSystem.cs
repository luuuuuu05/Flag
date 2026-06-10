using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    [SerializeField] private float grabRange = 2f;
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private Transform holdPoint;

    [SerializeField] private MonoBehaviour playerInputSource;
    private IPlayerInput playerInput;

    private IInteractable grabbedInteractable;
    private GameObject grabbedObject;
    private Rigidbody grabbedRigidbody;

    private void Awake()
    {
        if (playerInputSource != null)
            playerInput = playerInputSource as IPlayerInput;
    }

    private void Update()
    {
        bool interactPressed = playerInput != null
            ? playerInput.InteractTriggered
            : Input.GetKeyDown(KeyCode.G);

        bool interactReleased = playerInput != null
            ? playerInput.InteractReleased
            : Input.GetKeyUp(KeyCode.G);

        if (interactPressed)
        {
            if (grabbedObject == null)
                TryGrab();
            else
                Release();
        }

        if (grabbedObject != null)
            grabbedObject.transform.position = holdPoint.position;
    }

    private void TryGrab()
    {
        Collider[] colliders =
            Physics.OverlapSphere(transform.position, grabRange);
        float closestDistance = grabRange;
        GameObject closest = null;

        foreach (var col in colliders)
        {
            float dist =
                Vector3.Distance(
                    transform.position,
                    col.transform.position);

            if (dist < closestDistance)
            {
                closestDistance = dist;
                closest = col.gameObject;
            }
        }

        if (closest == null)
            return;

        grabbedObject = closest;
        grabbedInteractable = closest.GetComponent<IInteractable>();
        grabbedRigidbody = closest.GetComponent<Rigidbody>();

        if (grabbedInteractable != null)
            grabbedInteractable.OnGrab(transform);
        else if (grabbedRigidbody != null)
            grabbedRigidbody.isKinematic = true;
    }

    private void Release()
    {
        if (grabbedInteractable != null)
        {
            grabbedInteractable.OnRelease(transform.forward, throwForce);
        }
        else if (grabbedRigidbody != null)
        {
            grabbedRigidbody.isKinematic = false;
            grabbedRigidbody.AddForce(
                transform.forward * throwForce,
                ForceMode.Impulse);
        }

        grabbedObject = null;
        grabbedRigidbody = null;
        grabbedInteractable = null;
    }
}
