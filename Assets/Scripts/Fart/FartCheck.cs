using UnityEngine;

public class FartCheck : MonoBehaviour
{
    private bool stinky;

    private bool loud;

    private bool rainbow;

    private bool playerHasFart;

    private bool playerClearingFart;


    private void Start()
    {
        stinky = false;
        loud = false;
        rainbow = false;
        playerHasFart = false;
        playerClearingFart = false;
    }

    public void SetPlayerHasFart(bool hasFart)
    {
        playerHasFart = hasFart;
    }

    public bool PlayerHasFart()
    {
        return playerHasFart;
    }

    public void SetPlayerClearingFart()
    {
        playerClearingFart = true;
    }

    public void ResetPlayerClearingFart()
    {
        playerClearingFart = false;
    }

    public bool GetPlayerClearingFart()
    {
        return playerClearingFart;
    }

    public bool IsStinky()
    {
        return stinky;
    }

    public void SetStinky()
    {
        stinky = true;
    }

    public void ResetStinky()
    {
        stinky = false;
    }

    public bool IsLoud()
    {
        return loud;
    }

    public void SetLoud()
    {
        loud = true;
    }

    public void ResetLoud()
    {
        loud = false;
    }

    public bool IsRainbow()
    {
        return rainbow;
    }

    public void SetRainbow()
    {
        rainbow = true;
    }

    public void ResetRainbow()
    {
        rainbow = false;
    }
}
