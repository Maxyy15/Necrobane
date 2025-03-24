using UnityEngine;

public class SlowdownManager : MonoBehaviour
{
    public float slowdownFactor = 0.1f;
    public KeyCode slowdownKey = KeyCode.Z;
    private float originalTimeScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(slowdownKey))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = slowdownFactor;
                Time.fixedDeltaTime *= slowdownFactor;
            }
            else
            {
                Time.timeScale = originalTimeScale;
                Time.fixedDeltaTime *= originalTimeScale;
            }
        }
    }
}
