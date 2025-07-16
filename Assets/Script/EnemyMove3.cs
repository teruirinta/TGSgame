using UnityEngine;

public class EnemyMove3 : MonoBehaviour
{
    public float horizontalSpeed = 2f; // 左への移動速度
    public float floatAmplitude = 0.5f; // 上下の振幅
    public float floatFrequency = 1f; // 上下の速さ

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // 左へ移動
        float newX = transform.position.x - horizontalSpeed * Time.deltaTime;

        // 上下にふわふわ動く（サイン波）
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
