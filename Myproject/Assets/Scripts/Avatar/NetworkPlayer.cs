using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField] private Transform helmet;
    [SerializeField] private Transform torso;
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;

    public void UpdatePose(
        Vector3 headPos, Quaternion headRot,
        Vector3 torsoPos, Quaternion torsoRot,
        Vector3 leftHandPos, Quaternion leftHandRot,
        Vector3 rightHandPos, Quaternion rightHandRot)
    {
        if (helmet != null)
            helmet.SetPositionAndRotation(headPos, headRot);
        if (torso != null)
            torso.SetPositionAndRotation(torsoPos, torsoRot);
        if (leftHand != null)
            leftHand.SetPositionAndRotation(leftHandPos, leftHandRot);
        if (rightHand != null)
            rightHand.SetPositionAndRotation(rightHandPos, rightHandRot);
    }
}
