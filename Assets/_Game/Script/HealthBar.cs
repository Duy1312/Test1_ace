using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public Vector3 offset;
     public float maxhp = 100;
    private float currentHp;
    private Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        currentHp = maxhp;
        UpdateHpBar();
    }
    private void Update()
    {
      transform.position = player.transform.position + offset;
    }
    public void IncreaseHP( float hp)
    {
        currentHp += hp;
        currentHp = Mathf.Clamp(currentHp, 0, maxhp);
        UpdateHpBar();
    }
    public void DecreaseHP(float hp)
    {
        currentHp -= hp;
        currentHp = Mathf.Clamp(currentHp, 0, maxhp);
        UpdateHpBar();
    }
    private void UpdateHpBar()
    {
        slider.value = currentHp/maxhp;
    }

}
