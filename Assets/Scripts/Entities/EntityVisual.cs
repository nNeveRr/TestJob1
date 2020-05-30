using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityVisual : MonoBehaviour
{
    public Image BodyImage;
    public GameObject RootObject;

    [SerializeField]
    float TickDamage = 0.2f;
    float CurrentTick;

    [System.NonSerialized]
    public EntityClass myClass;

    public void DamageMe(float Damage)
    {
        if(CurrentTick<0f)
        {
            CurrentTick = TickDamage;
            myClass.DamageMe(Damage);
        }
    }

    void Update()
    {
        CurrentTick -= Time.deltaTime;
        myClass.Move(Time.deltaTime);
    }
}
