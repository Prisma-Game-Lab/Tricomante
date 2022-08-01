using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{

    public enum Item { UpgradeRuna, UnlockRuna, LevelUp }
    private int preco;
    private int nivel;
    private Color lowOpacity = new Color(1, 1, 1, 0.4f);


    [Header("referencias")]
    public Item item;
    public CharactersSetup setup;
    private effects runa;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI levelText;


    private void Awake()
    {
        try
        {
            runa = GetComponent<RunaId>().tipo;
        }
        catch {/*Esperado*/}
        GetPrice();
        GetCurrentLevel();
    }

    public void TryPurchase()
    {
        if (GameStateManager.instance.fiapos >= preco)
        {
            GameStateManager.instance.fiapos -= preco;
            switch (item)
            {
                case Item.UpgradeRuna:
                    GameStateManager.instance.UpgradeRuna(runa);
                    break;
                case Item.UnlockRuna:
                    GameStateManager.instance.AddRuna(runa);
                    break;
                case Item.LevelUp:
                    setup.LevelUp();
                    break;
            }
            GameStateManager.instance.UpdateStorePrices();
            GetCurrentLevel();
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(InsuficientFunds());
        }
    }

    private void GetCurrentLevel()
    {
        switch (item)
        {
            case Item.UpgradeRuna:
                nivel = GameStateManager.instance.playerLevels.levels[runa];
                break;
            case Item.UnlockRuna:
                nivel = -1;
                break;
            case Item.LevelUp:
                nivel = setup.nivel;
                break;
        }
        UpdateLevel(nivel);
    }

    public void GetPrice()
    {
        switch (item)
        {
            case Item.UpgradeRuna:
                preco = 12;
                break;
            case Item.UnlockRuna:
                preco = 15;
                break;
            case Item.LevelUp:
                preco = 12 + 6 * (setup.nivel - 1);
                break;
        }
        UpdatePrice();
    }

    private IEnumerator InsuficientFunds()
    {
        priceText.color = Color.red;
        Vector3 originalPosition = priceText.GetComponent<RectTransform>().position;
        float counter = 0f;
        float maxX = 3f;
        float maxY = 2f;
        float ShakeTime = 1f;
        while (true)
        {
            counter += Time.deltaTime;
            if (counter >= ShakeTime)
            {
                break;
            }
            else
            {
                priceText.GetComponent<RectTransform>().position = originalPosition + new Vector3((ShakeTime - counter) * Random.Range(-maxX, maxX), (ShakeTime - counter) * Random.Range(-maxY, maxY));
            }
            yield return null;
        }
        priceText.color = lowOpacity;
    }

    private void UpdatePrice()
    {
        priceText.text = preco.ToString();
        if (GameStateManager.instance.fiapos < preco)
        {
            priceText.color = lowOpacity;
        }
    }

    private void UpdateLevel(int level)
    {
        levelText.text = nivel.ToString();
    }
}
