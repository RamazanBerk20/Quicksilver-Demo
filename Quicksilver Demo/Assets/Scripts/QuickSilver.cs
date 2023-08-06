using System.Collections;
using UnityEngine;

public class QuickSilver : MonoBehaviour
{
    [Header("Slowdown")]
    public bool isSlowedDown = false;
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 10f;

    [Header("Time")]
    public float timeToSlow = 0.2f;
    public float timeToFast = 2f;

    private void Update()
    {
        if (Input.GetButtonDown("Slowdown"))
        {
            isSlowedDown = !isSlowedDown;
        }

        if(isSlowedDown)
        {
            DecreaseTimeScale();
            StartCoroutine(SlowdownCoroutine());
        }
        else
        {
            IncreaseTimeScale();
            StopCoroutine(SlowdownCoroutine());
        }
    }

    private void IncreaseTimeScale()
    {
        if (Time.timeScale < 1)
        {
            Time.timeScale += (1/timeToFast) * Time.unscaledDeltaTime;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    private void DecreaseTimeScale()
    {
        if (Time.timeScale > slowDownFactor)
        { 
            Time.timeScale -= (1/timeToSlow) * Time.unscaledDeltaTime;
        }
        else
        {
            Time.timeScale = slowDownFactor;
        }
    }

    IEnumerator SlowdownCoroutine()
    {
        yield return new WaitForSecondsRealtime(slowDownLength);
        isSlowedDown = false;

        StopCoroutine(SlowdownCoroutine());
    }
}
