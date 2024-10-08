using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagController : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;

    float rotSpeed = 0; // 깃발 회전 속도
    void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");   
    }

    void Update()
    {
        // 자동차와 깃발의 거리 계산
        float length = this.flag.transform.position.x - this.car.transform.position.x;

        // 깃발의 현재 회전각도를 Quaternion을 Euler 각도로 변환하여 구함
        float currentRotation = this.flag.transform.eulerAngles.z;

        if (currentRotation > 180) currentRotation -= 360f;

        if (length < 0 && currentRotation > -70f) // 거리가 0보다 작고, 회전각이 -70도보다 클 때
        {
            this.rotSpeed = -0.98f; // 시계방향 회전 (음수로 설정)
            transform.Rotate(0, 0, rotSpeed);

            // 회전각이 -70도 이하로 떨어지면 멈춤
            if (currentRotation + rotSpeed <= -70f)
            {
                transform.rotation = Quaternion.Euler(0, 0, -70f);
            }
        }
    }
}
