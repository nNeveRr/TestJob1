using UnityEngine;

public class EnemyEntity : EntityClass
{
    public EnemyEntity(float HP) : base(HP)
    {
        myVisual.BodyImage.color = Color.red;
    }

    protected override void Death()
    {
        base.Death();
        GameManager.Instance.AddGamePoints(1);
    }
}
