using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    [Header("UI Settings")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("SE Settings")]
    public AudioClip damageSE;
    public AudioClip healSE;
    public AudioClip scoreSE;
    public AudioSource audioSource; // 効果音再生用

    void Start()
    {
        currentHP = maxHP;
        UpdateHearts();
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy1"))
        {
            PlaySE(damageSE);
            TakeDamage(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Item1"))
        {
            PlaySE(healSE);
            Heal(1);
            Destroy(other.gameObject, 0.1f); // 少し遅らせて破壊
        }

        if (other.CompareTag("Item2"))
        {
            PlaySE(healSE);

            Destroy(other.gameObject, 0.1f); // 少し遅らせて破壊
        }

        if (other.CompareTag("ItemScore"))
        {
            PlaySE(scoreSE);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        Debug.Log("HP: " + currentHP);
        UpdateHearts();

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Heal(int amount)
    {
        if (currentHP >= maxHP)
        {
            return;
        }

        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        Debug.Log("HP: " + currentHP + "（回復！）");
        UpdateHearts();
    }

    void Die()
    {

        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("GameOver");
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i >= maxHP - currentHP)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    void PlaySE(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}