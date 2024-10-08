
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하므로 잊지 않고 추가
using UnityEngine.SceneManagement; 

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;

    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.2f;

        // hp게이지 0이 되면 ClearScene으로 이동.
        if (this.hpGauge.GetComponent<Image>().fillAmount <= 0f)
        {
            SceneManager.LoadScene("ClearScene"); 
        }
    }
}
