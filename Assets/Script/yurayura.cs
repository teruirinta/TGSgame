using UnityEngine;

public class yurayura : MonoBehaviour

{
    [Header("Yurayura Settings")]
    [SerializeField] float posSpeed = 1f;
    [SerializeField] float rotSpeed = 1f;
    [SerializeField] float scaleSpeed = 1f;
    [SerializeField] float posAmount = 1f;
    [SerializeField] float rotAmount = 1f;
    [SerializeField, Range(0f, 1f)] float scaleAmount = 1f;

    [Header("Movement Settings")]
    public float horizontalSpeed = 2f;

    Vector3 initialPos;
    Vector3 initialRot;
    Vector3 initialScale;
    float xPosDiff;
    float yPosDiff;
    float zRotDiff;
    float xScaleDiff;
    float yScaleDiff;

    void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation.eulerAngles;
        initialScale = transform.localScale;

        xPosDiff = Random.Range(-1f, 1f) * Mathf.PI * 2f;
        yPosDiff = Random.Range(-1f, 1f) * Mathf.PI * 2f;
        zRotDiff = Random.Range(-1f, 1f) * Mathf.PI * 2f;
        xScaleDiff = Random.Range(-1f, 1f) * Mathf.PI * 2f;
        yScaleDiff = Random.Range(-1f, 1f) * Mathf.PI * 2f;
    }

    void Update()
    {
        float time = Time.time;

        // ゆらゆら位置
        float xPos = Mathf.Sin(time * posSpeed + xPosDiff);
        float yPos = Mathf.Sin(time * posSpeed + yPosDiff);
        Vector3 posOffset = new Vector3(xPos, yPos, 0f) * posAmount;

        // 左方向への移動
        initialPos.x -= horizontalSpeed * Time.deltaTime;

        // 合成位置
        transform.position = initialPos + posOffset;

        // 回転
        float zRot = Mathf.Sin(time * rotSpeed + zRotDiff);
        Vector3 rot = initialRot + new Vector3(0f, 0f, zRot * rotAmount);
        transform.rotation = Quaternion.Euler(rot);

        // スケール
        float xScale = Mathf.Sin(time * scaleSpeed + xScaleDiff) * scaleAmount;
        float yScale = Mathf.Sin(time * scaleSpeed + yScaleDiff) * scaleAmount;
        transform.localScale = new Vector3(initialScale.x + xScale, initialScale.y + yScale, 1f);
    }

}
