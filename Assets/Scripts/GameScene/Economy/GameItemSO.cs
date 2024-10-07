using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewData", menuName = "MyGame/ScriptableObject")]
public abstract class GameItemSO : ScriptableObject
{
    //надо будет возвращать реализацию а не абстракцию
    public abstract GameItemSO GetItem();
}

public enum TypeItem 
{
    Food = 1,
}