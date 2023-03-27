using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    private int money;
    private bool isShopOpen;

    [SerializeField] private Text moneyText;
    [SerializeField] private Text stimPriceText;
    [SerializeField] private Text upgradeWeaponPriceText;
    [SerializeField] private Text granadePriceText;
    




    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        moneyText.text = "Money: " + money.ToString();
        stimPriceText.text = "Price: " + 100;
        upgradeWeaponPriceText.text = "Price: " + 200;
        granadePriceText.text = "Price: " + 300;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
