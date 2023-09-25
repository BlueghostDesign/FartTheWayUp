using UnityEngine;
using UnityEngine.UI;

public class BaggedAmount : MonoBehaviour
{
    private Text amount;


    private void Start()
    {
        amount = GetComponent<Text>();
    }

    private void Update()
    {
        amount.text = PlayerPrefs.GetInt(gameObject.tag, 0).ToString();
    }
}
