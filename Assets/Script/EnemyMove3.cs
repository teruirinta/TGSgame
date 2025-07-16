using UnityEngine;

public class EnemyMove3 : MonoBehaviour
{
    public float horizontalSpeed = 2f; // ���ւ̈ړ����x
    public float floatAmplitude = 0.5f; // �㉺�̐U��
    public float floatFrequency = 1f; // �㉺�̑���

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // ���ֈړ�
        float newX = transform.position.x - horizontalSpeed * Time.deltaTime;

        // �㉺�ɂӂ�ӂ퓮���i�T�C���g�j
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
