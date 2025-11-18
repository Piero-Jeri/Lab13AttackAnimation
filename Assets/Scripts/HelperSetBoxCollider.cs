using UnityEngine;


[ExecuteAlways]
public class HelperSetBoxCollider : MonoBehaviour
{
    Vector2 lastSpriteSize;
    void OnEnable()
    {
        Sync();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            BoxCollider2D box = GetComponent<BoxCollider2D>();

            if (sr == null || box == null) return;

            bool sizeChanged = sr.size != lastSpriteSize;
            bool scaleChanged = transform.localScale != Vector3.one;

            if (sizeChanged || scaleChanged)
            {
                Sync();
            }
        }
#endif
    }

    void Sync()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        BoxCollider2D box = GetComponent<BoxCollider2D>();

        if (sr == null || box == null) return;

        transform.localScale = Vector3.one;

        box.size = sr.size;

        lastSpriteSize = sr.size;
    }
}
