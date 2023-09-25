using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemManager : MonoBehaviour
{
    // Update amount of items and player gold.
    public void SmallRedPacket()
    {
        int num = PlayerPrefs.GetInt("Small Red Packet", 0);
        int gold = PlayerPrefs.GetInt("Player Gold", 0);
        PlayerPrefs.SetInt("Small Red Packet", num + 1);
        PlayerPrefs.SetInt("Player Gold", gold - 25);
    }

    // Update amount of items and player gold.
    public void MediumRedPacket()
    {
        int num = PlayerPrefs.GetInt("Medium Red Packet", 0);
        int gold = PlayerPrefs.GetInt("Player Gold", 0);
        PlayerPrefs.SetInt("Medium Red Packet", num + 1);
        PlayerPrefs.SetInt("Player Gold", gold - 50);
    }

    // Update amount of items and player gold.
    public void LargeRedPacket()
    {
        int num = PlayerPrefs.GetInt("Large Red Packet", 0);
        int gold = PlayerPrefs.GetInt("Player Gold", 0);
        PlayerPrefs.SetInt("Large Red Packet", num + 1);
        PlayerPrefs.SetInt("Player Gold", gold - 100);
    }

    // Update amount of items and player gold.
    public void Vacuum()
    {
        int num = PlayerPrefs.GetInt("Vacuum", 0);
        int gold = PlayerPrefs.GetInt("Player Gold", 0);
        PlayerPrefs.SetInt("Vacuum", num + 1);
        PlayerPrefs.SetInt("Player Gold", gold - 100);
    }

    // Update amount of items and player gold.
    public void EmergencyStop()
    {
        int num = PlayerPrefs.GetInt("Emergency Stop", 0);
        int gold = PlayerPrefs.GetInt("Player Gold", 0);
        PlayerPrefs.SetInt("Emergency Stop", num + 1);
        PlayerPrefs.SetInt("Player Gold", gold - 50);
    }
}
