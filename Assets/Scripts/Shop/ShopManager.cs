using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;


    public void OpenShop()
    {
        shopUI.SetActive(true);
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
    }
}
