using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    private static Image HealthBarImage;

    public static void SetValue(float value)
    {
        HealthBarImage.fillAmount = value;
        if(HealthBarImage.fillAmount < 0.2f)
        {
            SetColor(Color.red);
        }
        else if(HealthBarImage.fillAmount < 0.4f)
        {
            SetColor(Color.yellow);
        }
        else
        {
            SetColor(Color.green);
        }
    }

    public static float GetCurrentValue()
    {
        return HealthBarImage.fillAmount;
    }

    public static void SetColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        HealthBarImage.fillAmount = 1f;
    }
}