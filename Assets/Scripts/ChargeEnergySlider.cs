using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeEnergySlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Image fill;
    [SerializeField] Text press;

    Gradient gradient;
    GradientColorKey[] gck;
    GradientAlphaKey[] gak;

    public static bool isFullPower = false;

	void Start ()
    {
        press.gameObject.SetActive(false);
        gradient = new Gradient();

        gck = new GradientColorKey[3];
        gck[0].color = Color.red;
        gck[0].time = 0.0f;
        gck[1].color = Color.yellow;
        gck[1].time = 0.5f;
        gck[2].color = Color.green;
        gck[2].time = 1.0f;

        gak = new GradientAlphaKey[3];
        gak[0].alpha = 1.0f;
        gak[0].time = 0.0f;
        gak[1].alpha = 1.0f;
        gak[1].time = 0.5f;
        gak[2].alpha = 1.0f;
        gak[2].time = 1.0f;

        gradient.SetKeys(gck, gak);
	}

    void Update()
    {
        slider.value = Time.timeSinceLevelLoad;
        fill.color = gradient.Evaluate(slider.value/40f);
        if (slider.value == 40)
        {
            press.gameObject.SetActive(true);
            isFullPower = true;
        }
    }
}
