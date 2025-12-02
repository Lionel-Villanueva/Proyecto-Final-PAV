using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour , ISaveable
{
    [Header("AudioSources")]
    [SerializeField] private AudioSource[] sounds;

    [Header("Slider")]
    [SerializeField] private Slider volumeSlider;
    private float currentVolume;
    private const string volumeKey = "volumeLevel";
    private void OnEnable()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }
    private void OnDisable()
    {
        volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }
    private void Awake()
    {
        LoadData();
    }
    private void OnDestroy()
    {
        SaveData();
    }
    private void Start()
    {
        OnVolumeChanged(currentVolume);
    }
    public void LoadData()
    {
        currentVolume = PlayerPrefs.GetFloat(volumeKey, 1);
        volumeSlider.value = currentVolume;
    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat(volumeKey, currentVolume);
        PlayerPrefs.Save();
    }
    private void OnVolumeChanged(float value)
    {
        for (int i = 0; i < sounds.Length; ++i)
        {
            sounds[i].volume = value;
        }
        currentVolume = value;
    }
}
