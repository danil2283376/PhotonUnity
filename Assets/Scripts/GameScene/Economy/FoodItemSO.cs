using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "GameItemsSO/Food")]
public class FoodItemSO : GameItemSO
{
    public float HealthRestortion = 20;
    public TypeFood FoodType;

    private TypeItem TypeItem = TypeItem.Food;

    public override GameItemSO GetItem()
    {
        return this;
    }
}

public enum TypeFood 
{
    Meat = 1,

}