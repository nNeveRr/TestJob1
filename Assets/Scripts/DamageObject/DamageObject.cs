using UnityEngine;
using UnityEngine.UI;

public abstract class DamageObject : MonoBehaviour
{
    public virtual float GetDamage()
    {
        return 0f;
    }

    public virtual void SetSize(float newSize)
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!GameManager.GameStarted || GameManager.GamePaused)
        {
            return;
        }
        if (collision.gameObject.tag == "Entity")
        {
            var ent = collision.gameObject.GetComponent<EntityVisual>();
            ent.DamageMe(GetDamage());
        }
    }
}
