using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FurnitureSO : ScriptableObject
{

    [Header("General Settings")]
    [SerializeField] string furnitureName;
    [SerializeField] bool isMovable;
    [SerializeField] bool isHeavy;
    [SerializeField] int maxHealth;
    [SerializeField] float mass = 1f;

    //Pooping section
    [Header("Pooping Settings")]
    [SerializeField] int bonusForPoop;
  //  [SerializeField] string messagePooOnScoreboard;

    //Pee section
    [Header("Pee Settings")]
    [SerializeField] int bonusForPee;
  //  [SerializeField] string messagePeeOnScoreboard;

    //Properties
    public string FurnitureName
    {
        get => name;
    }
    public bool IsMovable
    {
        get => isMovable;
    }
    public bool IsHeavy
    {
        get => isHeavy;
    }

    public int MaxHealth
    {
        get => maxHealth;
    }
    public float Mass
    {
        get { return mass;}
    }
    public int BonusForPoop
    {
        get => bonusForPoop;
    }
    public int BonusForPee
    {
        get => bonusForPee;
    }
    /*
    public string MessagePooOnScoreboard
    {
        get => messagePooOnScoreboard;
    }

    public string MessagePeeOnScoreboard
    {
        get => messagePeeOnScoreboard;
    }*/


}
