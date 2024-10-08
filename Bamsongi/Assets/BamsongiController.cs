using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public AudioClip cannonSound; // 발사할 때 재생할 소리
    public AudioClip thunderSound; // 타겟에 맞았을 때 재생할 소리
    private Rigidbody rb;
    private AudioSource audioSource;
    private ScoreManager scoreManager;

    void Awake()
    {
        // Rigidbody 컴포넌트를 가져오거나 추가합니다.
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // AudioSource 컴포넌트를 가져오거나 추가합니다.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ScoreManager 컴포넌트를 가져옵니다.
        GameObject scoreObject = GameObject.Find("Score");
        if (scoreObject != null)
        {
            scoreManager = scoreObject.GetComponent<ScoreManager>();
        }

        // Rigidbody 설정 (중력 활성화)
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotationY; // y축 회전만 허용
    }

    public void Shoot(Vector3 dir) // 인자로 3차원 벡터가 입력되고
    {
        // 발사 소리 재생
        if (cannonSound != null)
        {
            audioSource.PlayOneShot(cannonSound);
        }

        GetComponent<Rigidbody>().AddForce(dir); // 들어온 입력 벡터만큼 오브젝트에 힘이 가해짐.
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            GetComponent<ParticleSystem>().Play();

            // 타겟에 맞았을 때 소리 재생을 위해 별도 오브젝트 생성
            if (thunderSound != null)
            {
                GameObject audioObject = new GameObject("TempAudio");
                AudioSource tempAudioSource = audioObject.AddComponent<AudioSource>();
                tempAudioSource.clip = thunderSound;
                tempAudioSource.Play();

                // 소리가 끝난 후에 오브젝트 삭제
                Destroy(audioObject, thunderSound.length);
            }

            // 점수 증가
            if (scoreManager != null)
            {
                scoreManager.AddScore(1); // 점수 1 추가
            }

            // 밤송이 오브젝트 삭제 (소리가 재생 중이더라도 별도 오브젝트라 영향 없음)
            Destroy(gameObject, 0.3f);
        }
        else if (collision.gameObject.CompareTag("Terrain"))
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
