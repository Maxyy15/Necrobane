using UnityEngine;

public class SlowdownManager : MonoBehaviour
{
    public float slowdownFactor = 0.1f;
    public KeyCode slowdownKey = KeyCode.Z;
    private float originalTimeScale;
    private float originalFixedDeltaTime;
    public PlayerProfile playerProfile;

    public bool isTimeSlowed;

    void Start()
    {
        originalTimeScale = Time.timeScale;
        originalFixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(slowdownKey))
        {
            if (Time.timeScale == originalTimeScale)
            {
                Time.timeScale = slowdownFactor;
                Time.fixedDeltaTime = originalFixedDeltaTime * slowdownFactor;
                isTimeSlowed = true;
                
            }
            else
            {
                Time.timeScale = originalTimeScale;
                Time.fixedDeltaTime = originalFixedDeltaTime; 
                isTimeSlowed = false;
            }
        }
        if (playerProfile.playerStamina <= 10)
        {
            Time.timeScale = originalTimeScale;
            Time.fixedDeltaTime = originalFixedDeltaTime;
            isTimeSlowed = false;
        }
        if (isTimeSlowed)
        {
            playerProfile.DeductStamina(0.2f);
        }
    }
}
