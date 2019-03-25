using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHolder : MonoBehaviour
{
    #region Singleton
    public static AudioHolder instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    public AudioSource crowdChant;

    void Start()
    {
        var allAudios = GetComponents<AudioSource>();

        crowdChant = allAudios[0];

    }

    public void ScoreAudio()
    {
        crowdChant.Play();
    }
}
