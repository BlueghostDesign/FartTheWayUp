using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private Button button;


    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        // Disable the purchase of this item if player does not have enough gold.
        if (PlayerPrefs.GetInt("Player Gold", 0) >= 10)
        {
            button.interactable = true;
        }
        // Enable the purchase of this item if player does have enough gold.
        else
        {
            button.interactable = false;
        }
    }
}
