using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{

    [SerializeField] Health _health;
    [SerializeField] Slider _slider;


    private void Start()
    {
        _health.OnTakeDamage += ShowSlider;
    }

    private void OnDestroy()
    {
        _health.OnTakeDamage -= ShowSlider;
    }

    private void Update()
    {
        //ShowSlider();
    }

    private void ShowSlider()
    {
        Debug.Log("Dis Moiiiiiii");
        _slider.value = _health.CurrentHealth;
    }
}
