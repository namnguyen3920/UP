using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public float aspectRatio = 9f / 16f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(target.position.y, 0f, float.MaxValue), transform.position.z);
    }

}