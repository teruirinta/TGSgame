using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BounceWall : MonoBehaviour
{
    [SerializeField]
    private float bounceStrength = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
        collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            // 最初の接触点の法線を取得
            if (collision.contactCount > 0)
            {
                Vector3 normal = collision.contacts[0].normal;

                // 現在の速度を法線で反射
                Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, normal);

                // 跳ね返りの強さを適用
                rb.velocity = reflectedVelocity * bounceStrength;
            }
        }
    }
}




