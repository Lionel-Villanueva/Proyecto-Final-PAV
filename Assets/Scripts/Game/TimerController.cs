using TMPro;
using UnityEngine;

public class TimerController : FailCondition
{
    private TMP_Text text;
    [SerializeField] private float timeRemaining = 30f;
    private bool isRunning = true;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;
        text.text = ((int)timeRemaining).ToString();
        if (timeRemaining <= 0f)
        {
            Fail();
            isRunning = false;
        }
    }
}
