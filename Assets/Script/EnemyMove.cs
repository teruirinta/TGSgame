using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveAmount = 0.7f;
    public float verticalSpeed = 1f;
    public float normalSpeed = 2f;
    public float boostedSpeed = 5f;
    public float yThreshold = 0.5f;
    public float xThreshold = 3f;
    public float floatAmplitude = 0.5f; // �㉺�̐U��
    public float floatFrequency = 1f; // �㉺�̑���
    public AudioClip swimSoundClip; // �j���T�E���h
    private AudioSource audioSource;

    private Vector3 startPos;
    private GameObject player;
    private bool isBoosting = false;

    [Header("�r�b�N���}�[�N�֌W")]
    public GameObject alertIconPrefab; // �� �r�b�N���}�[�N�̃v���n�u�iInspector�ɐݒ�j
    private GameObject alertIconInstance;

    void Start()
    {
        startPos = transform.position;

        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player�I�u�W�F�N�g��������Ȃ����I");
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = swimSoundClip;
        audioSource.loop = false;

        // �r�b�N���}�[�N�𐶐����čŏ��͔�\��
        if (alertIconPrefab != null)
        {
            alertIconInstance = Instantiate(alertIconPrefab, transform);
            alertIconInstance.transform.localPosition = new Vector3(0, 1.5f, 0); // ����ɕ\��
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

            // �r�b�N���}�[�N��\��
            if (alertIconInstance != null)
            {
                alertIconInstance.SetActive(true);
            }
        }
        else if (!shouldBoost && isBoosting)
        {
            isBoosting = false;

            // �r�b�N���}�[�N���\��
            if (alertIconInstance != null)
            {
                alertIconInstance.SetActive(false);
            }
        }

        // �ړ�����
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
