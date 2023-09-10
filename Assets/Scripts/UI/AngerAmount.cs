using UnityEngine;
using UnityEngine.UI;

public class AngerAmount : MonoBehaviour
{
    public Image angerBar;

    public void AngerChange(float percentage)
    {
        angerBar.fillAmount = percentage;
    }
}
