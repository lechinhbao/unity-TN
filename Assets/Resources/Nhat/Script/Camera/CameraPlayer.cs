using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform[] targets; // Mảng chứa tất cả nhân vật cần theo dõi
    public float smoothTime = 0.5f; // Thời gian di chuyển mềm mại của camera
    public Vector3 offset; // Độ chênh lệch vị trí giữa camera và trung bình của các nhân vật

    private Vector3 velocity;

    void Update()
    {
        if (targets.Length == 0)
        {
            return; // Không có nhân vật nào để theo dõi
        }

        MoveCamera();
    }

    void MoveCamera()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Length == 1)
        {
            return targets[0].position;
        }

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Length; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
