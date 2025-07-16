using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverselct : MonoBehaviour
{
    public RectTransform[] menuItems;
    public RectTransform selector;

    private int currentIndex = 0;
    private float inputCooldown = 0.3f;
    private float lastInputTime = 0f;

    void Start()
    {
        


    }

    void Update()
    {
        float dpadY = Input.GetAxis("DPadY");

        if (Time.time - lastInputTime > inputCooldown)
        {
            if (dpadY > 0.5f)
            {
                currentIndex = (currentIndex - 1 + menuItems.Length) % menuItems.Length;
                UpdateSelectorPosition();
                lastInputTime = Time.time;
            }
            else if (dpadY < -0.5f)
            {
                currentIndex = (currentIndex + 1) % menuItems.Length;
                UpdateSelectorPosition();
                lastInputTime = Time.time;
            }
        }

        // Aボタンで決定（通常は joystick button 0）
        if (Input.GetKeyDown("joystick button 1"))
        {
            SelectStage(currentIndex);
        }

        void UpdateSelectorPosition()
        {
            // 三角形を選択中のメニュー項目の左に配置
            Vector2 targetAnchoredPosition = menuItems[currentIndex].anchoredPosition;
            selector.anchoredPosition = new Vector2(targetAnchoredPosition.x - 350f, targetAnchoredPosition.y);
        }

    }

    

    void SelectStage(int index)
    {

        Debug.Log("選択されたインデックス: " + index);
        if (index == 0)
        {
            string previousScene = PlayerPrefs.GetString("PreviousScene", "title"); // デフォルトは title
            SceneManager.LoadScene(previousScene);
        }
        else if (index == 1)
        {
            SceneManager.LoadScene("title");
        }

        

    }
}
