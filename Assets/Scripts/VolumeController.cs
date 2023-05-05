using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider.value = PlayerPrefs.GetFloat("Volume", 0.75f);
        SetVolume(slider.value);
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public void SetVolume(float volume)
    {
        float decibels = -80f; // Mute olarak kabul edilecek minimum desibel deðeri.
        if (volume > 0)
        {
            decibels = Mathf.Log10(volume) * 20;
        }

        audioMixer.SetFloat("Volume", decibels);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}