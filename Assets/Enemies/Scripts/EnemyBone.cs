using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBone : MonoBehaviour
{

    [SerializeField]
    private AnimationCurve alphaCurve;
    [SerializeField]
    private Sprite[] bones; 

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();   
        spriteRenderer.sprite = bones[Random.Range(0, bones.Length)];

        Rigidbody2D rigidbody2d = GetComponent<Rigidbody2D>();   
        rigidbody2d.AddForce(Random.insideUnitCircle * Random.Range(40f, 80f));

        StartCoroutine(ColorCycle());
    }

    IEnumerator ColorCycle()
    {
        float t = 0f;
        
        Color color = spriteRenderer.color;
        float initialAlpha = color.a;

        while (t < 1f)
        {
            t += Time.deltaTime * .5f;
            color.a = initialAlpha * alphaCurve.Evaluate(t);

            spriteRenderer.color = color;

            yield return null;
        }

        Destroy(gameObject);
    }

}
