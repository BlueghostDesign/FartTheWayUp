using UnityEngine;
using UnityEngine.UI;

public class FartBar : MonoBehaviour
{
    public Image fartBar;

    public void FartChange(float percentage)
    {
        fartBar.fillAmount = percentage;
    }
}
