using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamageObject : DamageObject
{
    float CurrentSize;
    float NominalSize = 204f;

    public override float GetDamage()
    {
        return 450f/CurrentSize;
    }

    public override void SetSize(float newSize)
    {
        CurrentSize = newSize;
        RectTransform tr = transform as RectTransform;
        float XnewSize = Mathf.Clamp(115f * NominalSize / CurrentSize, 50f, NominalSize);
        tr.sizeDelta = new Vector2(XnewSize, CurrentSize);

        GetComponent<BoxCollider2D>().size = tr.sizeDelta;
    }
}
