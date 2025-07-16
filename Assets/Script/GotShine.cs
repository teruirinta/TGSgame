using UnityEngine;

public class GotShine : MonoBehaviour
{

    public Light[] lightRays;
    public float minInterval = 2f;
    public float maxInterval = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        foreach (Light ray in lightRays)
        {
            StartCoroutine(FlickerLight(ray));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    System.Collections.IEnumerator FlickerLight(Light ray)
    {
        while (true)
        {
            float waitTime = Random.Range(minInterval, maxInterval);
            ray.enabled = true;
            yield return new WaitForSeconds(0.2f); // 光が差す時間
            ray.enabled = false;
            yield return new WaitForSeconds(waitTime);
        }
    }

}
