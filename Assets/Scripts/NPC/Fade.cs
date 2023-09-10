using UnityEngine;

public class Fade : MonoBehaviour
{
    public bool faded;

    public bool fadeIn;

    public bool fadeOut;

    private float fadeSpeed;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fadeIn = false;
        fadeOut = false;
        fadeSpeed = 1;
        faded = true;
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
                faded = false;
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
                faded = true;
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

    public bool IsFaded()
    {
        return faded;
    }
}
