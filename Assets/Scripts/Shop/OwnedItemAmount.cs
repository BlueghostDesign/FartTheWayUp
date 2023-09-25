using UnityEngine;
using UnityEngine.UI;

public class OwnedItemAmount : MonoBehaviour
{
    private Text amount;


    private void Start()
    {
        amount = GetComponent<Text>();
    }

    private void Update()
    {
        amount.text = $"Owned: {PlayerPrefs.GetInt(gameObject.tag, 0)}";
    }
}
