using UnityEngine;

public class Fade : MonoBehaviour
{
    private bool fadeIn;

    private bool fadeOut;

    private float fadeSpeed;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fadeIn = false;
        fadeOut = false;
        fadeSpeed = 2;
    }

    private void Update()
    {
        InAndOut();
    }

    private void InAndOut()
    {
        if (fadeIn)
        {
            Color npcColor = spriteRenderer.color;
            float fadeAmount = npcColor.a + (fadeSpeed * Time.deltaTime);
            spriteRenderer.color = new Color(npcColor.r, npcColor.g, npcColor.b, fadeAmount);
            if (npcColor.a >= 1)
            {
                fadeIn = false;
            }
        }
        if (fadeOut)
        {
            Color npcColor = spriteRenderer.color;
            float fadeAmount = npcColor.a - (fadeSpeed * Time.deltaTime);
            spriteRenderer.color = new Color(npcColor.r, npcColor.g, npcColor.b, fadeAmount);
            if (npcColor.a <= 0)
            {
                fadeOut = false;
            }
        }
    }

    public void SetFadeIn()
    {
        fadeIn = true;
    }

    public void SetFadeOut()
    {
        fadeOut = true;
    }
}
