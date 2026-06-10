using UnityEngine;

public class DoubleItemEffect : MonoBehaviour
{
    private Vector3 startPos;

    public float floatHeight = 0.15f;
    public float floatSpeed = 2f;

    public float rotateSpeed = 90f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float y =
            Mathf.Sin(Time.time * floatSpeed)
            * floatHeight;

        transform.position =
            startPos +
            Vector3.up * y;

        transform.Rotate(
            Vector3.up,
            rotateSpeed * Time.deltaTime,
            Space.World
        );
    }
}