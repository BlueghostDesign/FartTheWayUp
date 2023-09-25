using UnityEngine;
using UnityEngine.UI;

public class PlayerGold : MonoBehaviour
{
    private Text playerGold;


    private void Start()
    {
        playerGold = GetComponent<Text>();
    }

    private void Update()
    {
        playerGold.text = $"Current Gold: {PlayerPrefs.GetInt("Player Gold", 0)}";
    }
}
