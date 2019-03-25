using UnityEngine;
using UnityEngine.UI;

public class MatchTimer : MonoBehaviour
{
    #region Singleton
    public static MatchTimer instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    private float timer = 120f;
    public float currentTimer;
    public Text timeText;
    internal bool ready;



    void Start()
    {
        currentTimer = timer;
        timeText = GetComponent<Text>();
    }

    
    void Update()
    {
        if (ready) {
            currentTimer -= Time.deltaTime;

            string minutes = Mathf.Floor(currentTimer / 60).ToString("00");
            string seconds = (currentTimer % 60).ToString("00");

            timeText.text = string.Format("{0}:{1}", minutes, seconds);

            if (currentTimer <= 0)
            {
                EventHandler.instance.StopMovement(null);
                timeText.text = "00:00";
            }
        }
    }

    public void ResetValues()
    {
        currentTimer = timer;

        string minutes = Mathf.Floor(currentTimer / 60).ToString("00");
        string seconds = (currentTimer % 60).ToString("00");

        timeText.text = string.Format("{0}:{1}", minutes, seconds);
        ready = false;
    }
}
