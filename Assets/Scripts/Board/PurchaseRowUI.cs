using UnityEngine;
using UnityEngine.UI;
using Game.Managers;
using Game.Cards;
using Game.Core;
using TMPro;

public class PurchaseRowUI : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardContainer;

    private PurchaseRow purchaseRow;

    public void Initialize(PurchaseRow row)
    {
        purchaseRow = row;
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (Transform child in cardContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < purchaseRow.Row.Count; i++)
        {
            var cardData = purchaseRow.Row[i];
            GameObject newCard = Instantiate(cardPrefab, cardContainer);
            newCard.GetComponentInChildren<TMP_Text>().text = cardData.ToString();

            int index = i;
            newCard.GetComponent<Button>().onClick.AddListener(() => BuyCard(index));
        }
    }

    private void BuyCard(int index)
    {
        var player = GameManager.Instance.CurrentPlayer;
        var card = purchaseRow.BuyCardAt(index);

        if (card != null && player.BuyCell(card))
        {
            RefreshUI();
        }
    }
}
