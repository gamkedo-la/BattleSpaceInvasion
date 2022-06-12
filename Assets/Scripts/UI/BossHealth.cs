using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Image HealthBarImage;
    public Ignimbrite1 boss;

    public void SetValue(float value)
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

    public float GetCurrentValue()
    {
        return HealthBarImage.fillAmount;
    }

    public void SetColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    private void Start()
    {
        HealthBarImage.fillAmount = 1f;
    }

    public void Update() 
    {
        SetValue(boss.GetCurrentHealth()/boss.GetTotalHealth());
        //Debug.Log(boss.GetCurrentHealth()/boss.GetTotalHealth());
    }
}