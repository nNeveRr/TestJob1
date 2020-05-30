using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartedInput : MonoBehaviour
{
    [SerializeField]
    GameObject ObjectParent;
    [SerializeField]
    RectTransform PlayField;
    [SerializeField]
    RectTransform HelpPositionObject1;
    [SerializeField]
    RectTransform HelpPositionObject2;

    GameObject DamageGO;

    bool isDoubleFingers;

    float ClearTime;

    void OnDisable()
    {
        Destroy(DamageGO);
        DamageGO = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameManager.GamePaused)
            {
                GameManager.Instance.AbortGameButton();
            }
            else
            {
                GameManager.Instance.PauseGameButton();
            }
        }
        if (!GameManager.GameStarted || GameManager.GamePaused)
        {
            return;
        }
        if (Input.GetMouseButton(0)&& Input.touchCount == 0)
        {
            TakeSingleInput(Input.mousePosition);
        }
        else if (Input.touchCount == 1)
        {
            TakeSingleInput(Input.GetTouch(0).position);
        }
        else if (Input.touchCount == 2)
        {
            TakeDoubleInput(Input.GetTouch(0).position, Input.GetTouch(1).position);
        }
        else
        {
            TimeClearDamageObjects(Time.deltaTime);
        }
    }

    void TakeSingleInput(Vector3 pos )
    {
        if (!isInPlayField(pos))
        {
            Destroy(DamageGO);
            return;
        }
        SingleDamageObject(pos);
        ClearTime = 0.5f;
    }

    void TakeDoubleInput(Vector3 pos1, Vector3 pos2)
    {
        if (!isInPlayField(pos1)|| !isInPlayField(pos2))
        {
            Destroy(DamageGO);
            return;
        }
        DoubleDamageObject(pos1, pos2);
        ClearTime = 0.5f;
    }

    void DoubleDamageObject(Vector3 pos1, Vector3 pos2)
    {
        if(!isDoubleFingers && DamageGO!=null)
        { 
            Destroy(DamageGO);
            DamageGO = null;
        }
        isDoubleFingers = true;

        if (DamageGO == null)
        {
            DamageGO = Instantiate(Resources.Load<GameObject>("DoubleDamageObject"));
            DamageGO.transform.SetParent(ObjectParent.transform, false);
        }

        Vector3 position = (pos1 + pos2) / 2f;




        DamageGO.transform.position = Vector3.Lerp(DamageGO.transform.position, position, 0.85f);

        Vector3 dir = pos2 - pos1;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        DamageGO.transform.rotation = Quaternion.AngleAxis(angle+90f, Vector3.forward);


        HelpPositionObject1.transform.position = pos1;
        HelpPositionObject2.transform.position = pos2;

        float newSize = Vector2.Distance(HelpPositionObject1.anchoredPosition, HelpPositionObject2.anchoredPosition);
        var DamObj = DamageGO.GetComponent<DamageObject>();
        DamObj.SetSize(newSize);
    }

    void SingleDamageObject(Vector3 position)
    {
        if(isDoubleFingers)
        {
            Destroy(DamageGO);
            DamageGO = null;
            isDoubleFingers = false;
        }
        if (DamageGO == null)
        {
            DamageGO = Instantiate(Resources.Load<GameObject>("SingleDamageObject"));
            DamageGO.transform.SetParent(ObjectParent.transform, false);
        }
        DamageGO.transform.position = Vector3.Lerp(DamageGO.transform.position, position, 0.85f);
    }

    bool isInPlayField(Vector3 position)
    {
        HelpPositionObject1.transform.position = position;
        return PlayField.rect.Contains(HelpPositionObject1.anchoredPosition);
    }

    void TimeClearDamageObjects(float DeltaTime)
    {
        ClearTime -= DeltaTime;
        if (ClearTime <= 0)
        {
            if (DamageGO != null)
            {
                Destroy(DamageGO);
            }
        }
    }
}
