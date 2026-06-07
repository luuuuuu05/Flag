using UnityEngine;
using UnityEngine.XR;

public class AvatarController : MonoBehaviour
{
    [SerializeField] private Transform helmetModel;
    [SerializeField] private Transform torsoModel;
    [SerializeField] private Transform leftHandModel;
    [SerializeField] private Transform rightHandModel;
    [SerializeField] private Transform headTarget;
    [SerializeField] private Vector3 torsoOffset = new Vector3(0, -0.3f, 0);

    private void Update()
    {
        Transform head = headTarget != null ? headTarget : Camera.main?.transform;
        if (head != null)
        {
            if (helmetModel != null)
                helmetModel.SetPositionAndRotation(head.position, head.rotation);

            if (torsoModel != null)
            {
                Vector3 torsoPos = head.position + head.TransformDirection(torsoOffset);
                torsoModel.position = torsoPos;
                torsoModel.rotation = Quaternion.Euler(0, head.eulerAngles.y, 0);
            }
        }

        UpdateHand(XRNode.LeftHand, leftHandModel);
        UpdateHand(XRNode.RightHand, rightHandModel);
    }

    private void UpdateHand(XRNode node, Transform handModel)
    {
        if (handModel == null) return;

        var devices = new System.Collections.Generic.List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(node, devices);
        if (devices.Count > 0)
        {
            InputDevice device = devices[0];
            if (device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 pos) &&
                device.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rot))
            {
                handModel.SetPositionAndRotation(pos, rot);
            }
        }
    }
}
