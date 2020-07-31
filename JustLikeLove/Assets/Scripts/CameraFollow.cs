using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("目標")]
    public Transform target;
    [Header("跟隨速度"), Range(0, 50)]
    public float speed = 1;
    [Header("上下限制")]
    public Vector2 limit = new Vector2(0, 2);

    private void LateUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 posA = target.position;
        Vector3 posB = transform.position;
        posA.z = -10;
        posA.y = Mathf.Clamp(posA.y, limit.x, limit.y);

        posA = Vector3.Lerp(posA, posB, Time.deltaTime * speed);

        transform.position = posA;
    }
}
