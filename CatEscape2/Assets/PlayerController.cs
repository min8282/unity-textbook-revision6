using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float objectHeight;

    void Start()
    {
        Application.targetFrameRate = 60;

        // Get the height of the object based on its Collider or Renderer
        if (TryGetComponent<Collider>(out var collider))
        {
            objectHeight = collider.bounds.size.y;
        }
        else if (TryGetComponent<Renderer>(out var renderer))
        {
            objectHeight = renderer.bounds.size.y;
        }
    }

    void Update()
    {
        // Calculate the top and bottom positions
        float topPosition = transform.position.y + objectHeight / 2;
        float bottomPosition = transform.position.y - objectHeight / 2;

        // 위쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 3, 0); // 위쪽으로 「3」 움직인다

            // 위쪽 경계 확인
            topPosition = transform.position.y + objectHeight / 2;
            if (topPosition > 5)
            {
                float overshoot = topPosition - 5;
                transform.position = new Vector3(transform.position.x, transform.position.y - overshoot, transform.position.z);
            }
        }

        // 아래쪽 화살표가 눌렸을 때
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -3, 0); // 아래쪽으로 「3」 움직인다

            // 아래쪽 경계 확인
            bottomPosition = transform.position.y - objectHeight / 2;
            if (bottomPosition < -5)
            {
                float overshoot = -5 - bottomPosition;
                transform.position = new Vector3(transform.position.x, transform.position.y + overshoot, transform.position.z);
            }
        }
    }
}
