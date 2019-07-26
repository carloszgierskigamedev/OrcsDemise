using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealthContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject heartPrefab;
    [SerializeField]
    private int heartsAmount = 5;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite halfHeart;
    [SerializeField]
    private Sprite emptyHeart;

    private Transform heartList;

    private PlayerHealth health;
    private List<Image> heartImages;

    private Image damageDisplayImage;

    private float lastHealth;

    void Awake()
    {
        heartImages = new List<Image>();
        heartList = transform.Find("HeartList");
        damageDisplayImage = transform.Find("DamageDisplay").GetComponent<Image>();
    }

    void Start()
    {
        for (int i = 0; i < heartsAmount; i++)
        {
            GameObject heartCreated = Instantiate(heartPrefab);
            heartCreated.transform.SetParent(heartList);

            heartImages.Add( heartCreated.GetComponent<Image>() );
        }

        health = GameObject.FindObjectOfType<PlayerHealth>();
        UpdateHealthContainer();    
        
        lastHealth = health.CurrentHealthPoints;
    }

    void Update()
    {
        if(lastHealth != health.CurrentHealthPoints)    
        {
            lastHealth = health.CurrentHealthPoints;

            UpdateHealthContainer();
            DisplayDamage();
        }
    }

    void UpdateHealthContainer()
    {
        float currentHealthPerc = (health.CurrentHealthPoints / health.TotalHealthPoints) * heartImages.Count;
        for (int i = 0; i < heartImages.Count; i++)
        {
            int heartAmount = i + 1;

            if(heartAmount == Mathf.Floor(currentHealthPerc) + 1)
            {
                if(currentHealthPerc - Mathf.Floor(currentHealthPerc) >= .5f)
                {
                    heartImages[i].sprite = halfHeart;
                }
                else
                {
                    heartImages[i].sprite = emptyHeart;
                }
            }
            else if(heartAmount > currentHealthPerc)
            {
                heartImages[i].sprite = emptyHeart;
            }
            else
            {
                heartImages[i].sprite = fullHeart;
            }
        }
    }

    void DisplayDamage()
    {
        StartCoroutine(DamageDisplayCycle());
    }

    IEnumerator DamageDisplayCycle()
    {
        float alpha = .2f;

        Color color = damageDisplayImage.color;
        color.a = alpha;

        damageDisplayImage.color = color;

        while (alpha > .0f)
        {
            alpha -= Time.deltaTime;

            color.a = alpha;
            damageDisplayImage.color = color;

            yield return null;
        }
    }

}
