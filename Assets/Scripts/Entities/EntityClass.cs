using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityClass 
{
    protected EntityVisual myVisual;

    float HP;

    int MoveDirection;

    float Speed
    {
        get => HP > 0f ? Mathf.Clamp(2f / HP, 0.3f, 3f)*250f : 0f;
    }

    float Size
    {
        get => Mathf.Clamp(HP / 10f, 0.3f, 2f);
    }

    RectTransform myRectTransf
    {
        get => myVisual.RootObject.transform as RectTransform;
    }

    protected EntityClass(float HP)
    {
        GameObject NewObject = GameObject.Instantiate(Resources.Load<GameObject>("Entity"));
        myVisual = NewObject.GetComponent<EntityVisual>();
        myVisual.myClass = this;
        MoveDirection = (int)Mathf.Sign(Random.Range(-1f, 1f));
        this.HP = HP;
        SetStartRandPosition();
        UpdateVisual();
    }

    void SetStartRandPosition()
    {
        float StartX;
        float StartY;

        float Xsize = GameStartedVisual.Instance.BordersObject.rect.size.x;
        float Ysize = GameStartedVisual.Instance.BordersObject.rect.size.y;

        float XRoot = GameStartedVisual.Instance.BordersObject.anchoredPosition.x;
        float YRoot = GameStartedVisual.Instance.BordersObject.anchoredPosition.y;

        StartY = Random.Range(-Ysize / 2f, Ysize / 2f - 100f)+ YRoot;
        StartX = (MoveDirection > 0f ? -Xsize / 2f - 35f  : Xsize / 2f + 35f) + XRoot;
        Vector2 StartPos = new Vector2(StartX, StartY);

        myRectTransf.SetParent(GameManager.Instance.CreateEntityParent.transform, false);
        myRectTransf.anchoredPosition = StartPos;

        myRectTransf.localRotation = Quaternion.Euler(0f, MoveDirection > 0f ? 0f : 180f, 0f);

    }

    protected virtual void Death()
    {
        DestroyMe();
    }

    public void Move(float DeltaTime)
    {
        if(GameManager.GamePaused)
        {
            return;
        }
        myRectTransf.anchoredPosition += new Vector2(DeltaTime * Speed*MoveDirection, 0f);
        if(isOutBorders())
        {
            DestroyMe();
        }
    }

    bool isOutBorders()
    {
        float Xsize = GameStartedVisual.Instance.BordersObject.rect.size.x;
        float XRoot = GameStartedVisual.Instance.BordersObject.anchoredPosition.x;


        float Xpos = myRectTransf.anchoredPosition.x;

        return (Xpos < XRoot - Xsize / 2f - 40f) || (Xpos > XRoot + Xsize / 2f + 40f);
    }

    public void DestroyMe(bool CollectionRemove = true)
    {
        if (CollectionRemove)
        {
            GameManager.Instance.RemoveEntity(this);
        }
        GameObject.Destroy(myVisual.gameObject);
    }

    public void DamageMe(float damage)
    {
        HP -= damage;
        if(HP<=0f)
        {
            Death();
        }
        else
        {
            UpdateVisual();
        }
    }

    void UpdateVisual()
    {
        myVisual.RootObject.transform.localScale = new Vector3(Size, Size, Size);
    }
}
