using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    private Elevator elevator;


    private void Awake()
    {
        elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
    }

    public void SmallRedPacket()
    {
        int num = PlayerPrefs.GetInt("Small Red Packet", 0);
        PlayerPrefs.SetInt("Small Red Packet", num - 1);
        elevator.UseItem(1);
    }

    public void MediumRedPacket()
    {
        int num = PlayerPrefs.GetInt("Medium Red Packet", 0);
        PlayerPrefs.SetInt("Medium Red Packet", num - 1);
        elevator.UseItem(2);
    }

    public void LargeRedPacket()
    {
        int num = PlayerPrefs.GetInt("Large Red Packet", 0);
        PlayerPrefs.SetInt("Large Red Packet", num - 1);
        elevator.UseItem(3);
    }

    public void Vacuum()
    {
        int num = PlayerPrefs.GetInt("Vacuum", 0);
        PlayerPrefs.SetInt("Vacuum", num - 1);
        elevator.UseItem(4);
    }

    public void EmergencyStop()
    {
        int num = PlayerPrefs.GetInt("Emergency Stop", 0);
        PlayerPrefs.SetInt("Emergency Stop", num - 1);
        elevator.UseItem(5);
    }
}

