using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float moveSpeed = 3.0f; // 움직임 속도
    public float minX = -15.0f; // 이동 최소 x값
    public float maxX = 15.0f;  // 이동 최대 x값

    void Update()
    {
        // 좌우로 -15에서 15까지 이동
        float x = Mathf.PingPong(Time.time * moveSpeed, maxX - minX) + minX;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
