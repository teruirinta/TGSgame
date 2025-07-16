using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveAmount = 0.7f;
    public float verticalSpeed = 1f;
    public float normalSpeed = 2f;
    public float boostedSpeed = 5f;
    public float yThreshold = 0.5f;
    public float xThreshold = 3f;
    public float floatAmplitude = 0.5f; // 上下の振幅
    public float floatFrequency = 1f; // 上下の速さ
    public AudioClip swimSoundClip; // 泳ぎサウンド
    private AudioSource audioSource;

    private Vector3 startPos;
    private GameObject player;
    private bool isBoosting = false;

    [Header("ビックリマーク関係")]
    public GameObject alertIconPrefab; // ← ビックリマークのプレハブ（Inspectorに設定）
    private GameObject alertIconInstance;

    void Start()
    {
        startPos = transform.position;

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Playerオブジェクトが見つからないラ！");
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = swimSoundClip;
        audioSource.loop = false;

        // ビックリマークを生成して最初は非表示
        if (alertIconPrefab != null)
        {
            alertIconInstance = Instantiate(alertIconPrefab, transform);
            alertIconInstance.transform.localPosition = new Vector3(0, 1.5f, 0); // 頭上に表示
            alertIconInstance.SetActive(false);
        }
    }

    void Update()
    {



        if (player == null) return;

        float yDiff = Mathf.Abs(transform.position.y - player.transform.position.y);
        float xDiff = Mathf.Abs(transform.position.x - player.transform.position.x);

        bool shouldBoost = (yDiff <= yThreshold && xDiff <= xThreshold);

        float currentSpeed = shouldBoost ? boostedSpeed : normalSpeed;

        if (shouldBoost && !isBoosting)
        {
            isBoosting = true;

            if (swimSoundClip != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }

            // ビックリマークを表示
            if (alertIconInstance != null)
            {
                alertIconInstance.SetActive(true);
            }
        }
        else if (!shouldBoost && isBoosting)
        {
            isBoosting = false;

            // ビックリマークを非表示
            if (alertIconInstance != null)
            {
                alertIconInstance.SetActive(false);
            }
        }

        // 移動処理
        float newY = Mathf.Sin(Time.time * verticalSpeed) * moveAmount;
        float newX = transform.position.x - currentSpeed * Time.deltaTime;
        transform.position = new Vector3(newX, startPos.y + newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
