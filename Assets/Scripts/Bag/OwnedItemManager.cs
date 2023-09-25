using UnityEngine;
using UnityEngine.UI;

public class OwnedItemManager : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt(gameObject.tag, 0) == 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
