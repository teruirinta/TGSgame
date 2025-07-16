using UnityEngine;
using UnityEngine.SceneManagement;

public class kirikae : MonoBehaviour
{
    
    private float timer = 0f;
    public float switchTime = 180f; // 3分（180秒）

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
     }

    // Update is called once per frame
    void Update()
    {

        timer  += Time.deltaTime;

        if (timer >= switchTime)
        {
            SceneManager.LoadScene("goal");
        }
    }
}
