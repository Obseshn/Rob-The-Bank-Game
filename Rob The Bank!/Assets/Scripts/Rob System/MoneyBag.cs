using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    private int capacity = 5;

    [SerializeField] private int currentMoneyValue = 0;

    public bool HasEmptySlots()
    {
        return capacity > currentMoneyValue ? true : false;
    }
    public void AddMoney(int moneyToAdd)
    {
        if (currentMoneyValue > capacity)
        {

            Debug.Log("Bag is full!");
            return;
        }
        currentMoneyValue += moneyToAdd;
    }

    public int GetCurrentMoneySlots()
    {
        return currentMoneyValue;
    }

    public int RemoveMoney(int moneyToRemove)
    {
        if (moneyToRemove > currentMoneyValue && currentMoneyValue > 0)
        {
            Debug.Log("Invalid count of money to return! Or zero money in the bag");
            return 0;
        }
        currentMoneyValue -= moneyToRemove;
        return moneyToRemove;
    }
}
