using UnityEngine;
using UnityEngine.UI;

public class MedKitBar : MonoBehaviour
{
    public Slider _Slider;
    public Gradient _Gradient;
    public Image _Fill;

    public void SetMedKitCount(int count)
    {
        _Slider.maxValue = count;
        _Slider.value = count;
        _Fill.color = _Gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        _Slider.value = health;
        _Fill.color = _Gradient.Evaluate(_Slider.normalizedValue);
    }
}
