using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void Update()
    {
        transform.position = target.position + offset;
    }
}
