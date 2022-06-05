using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderManager : MonoBehaviour
{
    public Text percentageText;
    public AudioSource song;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = AudioListener.volume; //Global volume value
        percentageText.text = "MUSIC VOLUME: " + Mathf.CeilToInt(slider.value * 100) + "%";
        song.volume = slider.value;
    }

    public void SliderValueChanged()
    {
        AudioListener.volume = slider.value; //Setting the global volume
        percentageText.text = "MUSIC VOLUME: " + Mathf.CeilToInt(slider.value * 100) + "%";
        song.volume = slider.value;
    }
}
