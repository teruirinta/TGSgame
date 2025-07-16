using UnityEngine;
using UnityEngine.UI;

public class playertest : MonoBehaviour
{
    public float moveForce = 10f; // �������Ƃ��̈ړ���

    public int maxStamina = 20;
    public float recoverDelay = 2f;
    public float recoverRate = 2f;

    public Slider staminaSlider;

    public GameObject particleEffectPrefab; // �ǉ��F�p�[�e�B�N���̃v���n�u

    private int currentStamina;
    private float lastPressTime;
    private float recoverTimer;

    private int currentHP = 5;
    public int maxHP = 5;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // �����Ђ�����Ԃ�Ȃ��悤�ɉ�]�𐧌�
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        currentStamina = maxStamina;
        lastPressTime = -recoverDelay;

        if (staminaSlider != null)
        {
            staminaSlider.maxValue = maxStamina;
            staminaSlider.value = currentStamina;
        }
    }


    void Update()
    {
        // Z�ʒu�Œ�
        Vector3 newPosition = transform.position;
        newPosition.z = 0;
        transform.position = newPosition;

        // ���X�e�B�b�N�̓���
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Vector2 direction = new Vector2(horizontal, vertical).normalized;
            transform.right = direction;

            //Vector2 direction = new Vector2(horizontal, vertical);
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, 0, angle);


            //Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 1f);

        }
        // A�{�^�����������̏���
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentStamina > 0)
            {
                Vector3 forward = transform.right;
                rb.AddForce(forward * moveForce, ForceMode.Impulse);

                currentStamina--;
                lastPressTime = Time.time;
                recoverTimer = 0f;

                // �p�[�e�B�N���\���i1�b�ŏ�����j
                if (particleEffectPrefab != null)
                {
                    GameObject effect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
                    Destroy(effect, 1f); // 1�b��Ɏ����폜
                }
            }
        }

        // �X�^�~�i�񕜏���
        if (Time.time - lastPressTime >= recoverDelay && currentStamina < maxStamina)
        {
            recoverTimer += Time.deltaTime * recoverRate;

            if (recoverTimer >= 1f)
            {
                int recovered = Mathf.FloorToInt(recoverTimer);
                currentStamina = Mathf.Min(currentStamina + recovered, maxStamina);
                recoverTimer -= recovered;
            }
        }

        // UI�X�V
        if (staminaSlider != null)
        {
            staminaSlider.value = currentStamina;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item1"))
        {
            if (currentHP < maxHP)
            {
                currentHP++;
                Debug.Log("HP�񕜁I����: " + currentHP);
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy1"))
        {
            currentHP--;
            currentHP = Mathf.Clamp(currentHP, 0, maxHP);
            currentStamina -= 5;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Item2"))
        {
            if (currentStamina < maxStamina)
            {
                currentStamina += 15;
                currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
                Debug.Log("�X�^�~�i�񕜁I����: " + currentStamina);
            }
            Destroy(other.gameObject);
        }


    }
}

