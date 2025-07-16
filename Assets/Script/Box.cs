using UnityEngine;

public class Box : MonoBehaviour

{
    public float rotationSpeed = 10f; // 回転のスムーズさ

    void Update()
    {
        // 入力を取得（例：水平と垂直の軸）
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 入力がある場合のみ方向を更新
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.sqrMagnitude > 0.01f)
        {
            // 向くべき方向の回転を計算
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            // スムーズに回転
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
