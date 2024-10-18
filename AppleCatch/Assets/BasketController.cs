using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;          // 사과 사운드
    public AudioClip bombSE;           // 폭탄 사운드
    public GameObject appleParticlePrefab;  // 사과 파티클 프리팹
    public GameObject bombParticlePrefab;   // 폭탄 파티클 프리팹
    AudioSource aud;
    GameObject director;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            // 사과에 대한 사운드 및 파티클
            this.aud.PlayOneShot(this.appleSE);
            this.director.GetComponent<GameDirector>().GetApple();
            
            // 사과에 대한 파티클 생성
            Instantiate(appleParticlePrefab, other.transform.position, Quaternion.identity);
        }
        else if (other.gameObject.tag == "Bomb")
        {
            // 폭탄에 대한 사운드 및 파티클
            this.aud.PlayOneShot(this.bombSE);
            this.director.GetComponent<GameDirector>().GetBomb();
            
            // 폭탄에 대한 파티클 생성
            Instantiate(bombParticlePrefab, other.transform.position, Quaternion.identity);
        }

        Destroy(other.gameObject); // 충돌한 오브젝트 제거
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
