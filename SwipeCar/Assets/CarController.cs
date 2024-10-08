using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;

    void Start()
    {
        
    }
    void Update()
    {
        // 스와이프의 길이를 구한다.
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스를 클릭한 좌표
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            float swipeLength = endPos.x - this.startPos.x;
            this.speed = swipeLength / 5000.0f;

            // 효과음
            GetComponent<AudioSource>().Play();
        }

        // 현재 위치에서 speed만큼 이동
        transform.Translate(this.speed, 0, 0);  

        // 현재 x 좌표를 제한된 범위 내로 고정
        float clampedX = Mathf.Clamp(transform.position.x, -8f, 10f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // 감속
        this.speed *= 0.98f;
    }
}
