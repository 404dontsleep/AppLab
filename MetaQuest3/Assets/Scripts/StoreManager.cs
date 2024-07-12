using Oculus.Platform;
using Oculus.Platform.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    private string[] tags = { "Cost_5", "Cost_10", "Cost_25", "Cost_50", "Cost_100" };

    private AutoCreateClone AutoCreateClone;

    public RectTransform panel;

    public RectTransform SimpleMenu;

    // Start is called before the first frame update
    void Start()
    {
        AutoCreateClone = gameObject.GetComponent<AutoCreateClone>();
        GetPrices();
        //GetPurchases();
    }
    public List<GameObject> GetAllChildrenObjectsWithTag(GameObject parent, string tag)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in parent.transform)
        {
            if (child.CompareTag(tag)) children.Add(child.gameObject);
        }
        return children;
    }
    private void GetPrices()
    {
        IAP.GetProductsBySKU(tags).OnComplete(GetPricesCallBack);
    }
    private void GetPricesCallBack(Message<ProductList> message)
    {
        Debug.Log(message.IsError);
        Debug.Log(message.Type);
        if (message.IsError) return;
        
        Vector3 trans = Vector3.zero;

        foreach (var prod in message.GetProductList())
        {
            if(panel != null && SimpleMenu != null)
            {
                var _panel = Instantiate(panel);
                _panel.name = prod.Name;
                TextMeshPro textMeshPro = _panel.GetComponent<TextMeshPro>();
                Button button = _panel.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.AddListener(()=> BuyPack(prod.Sku));
                }
                textMeshPro.text = prod.Name + " " + prod.FormattedPrice;
                _panel.transform.SetParent(SimpleMenu.transform);
                _panel.position = trans;
                trans += Vector3.down * 20;
            }
        }
    }

    private void GetPurchases()
    {
        IAP.GetViewerPurchases().OnComplete(GetPurchasesCallBack);
    }
    private void GetPurchasesCallBack(Message<PurchaseList> message)
    {
        if (message.IsError) return;
        foreach(var purchase in message.GetPurchaseList())
        {
            if (AutoCreateClone != null) AutoCreateClone.CloneTag(purchase.Sku);
        }
    }

    public void BuyPack(string tag)
    {
        IAP.LaunchCheckoutFlow(tag).OnComplete(BuyPackCallBack);
    }
    private void BuyPackCallBack(Message<Purchase> message) {
        if(message.IsError) return;
        Debug.Log(message.Data);
        if (AutoCreateClone != null) AutoCreateClone.CloneTag(message.Data.Sku);
    }
}
