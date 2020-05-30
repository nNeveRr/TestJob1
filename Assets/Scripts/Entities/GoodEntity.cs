using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEntity : EntityClass
{
    public GoodEntity(float HP) : base(HP)
    {
        myVisual.BodyImage.color = Color.gray;
    }

    protected override void Death()
    {
        base.Death();
        GameManager.Instance.AddGamePoints(-3);
    }
}
