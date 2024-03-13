using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinController : MonoBehaviour
{
    public Button defaultBtn;
    public Button beautyBtn;
    public Button godBtn;



    public AnimatorOverrideController defaultSkin;
    public AnimatorOverrideController beautySkin;
    public AnimatorOverrideController godSkin;

    public bool isBeautyPurchased = false;
    public bool isGodPurchased = false;
    public bool isDefaultPurchased = true;

    public GameObject player;

    private void Start()
    {
        defaultBtn.onClick.AddListener(DefaultClick);
        beautyBtn.onClick.AddListener(BeautyClick);
        godBtn.onClick.AddListener(GodClick);

        isBeautyPurchased = PlayerPrefs.GetInt("IsBeautyPurchased") == 1;
        isGodPurchased = PlayerPrefs.GetInt("IsGodPurchased") == 1;
        isDefaultPurchased = PlayerPrefs.GetInt("IsDefaultPurchased") == 1;
    }

    private void ApplySkin(AnimatorOverrideController skin)
    {
        var animator = player.GetComponent<Animator>();
        animator.runtimeAnimatorController = skin;
    }

    private void DefaultClick()
    {
        if (!isDefaultPurchased)
        {
            ApplySkin(defaultSkin);
            defaultBtn.interactable = false;
            godBtn.interactable = true;
            beautyBtn.interactable = true;
            isGodPurchased = false;
            isBeautyPurchased = false;
            isDefaultPurchased = true;
        }
    }

    private void BeautyClick()
    {
        if (!isBeautyPurchased)
        {
            ApplySkin(beautySkin);
            defaultBtn.interactable = true;
            godBtn.interactable = true;
            beautyBtn.interactable = false;
            isDefaultPurchased = false;
            isGodPurchased = false;
            isBeautyPurchased = true;
        }
    }

    private void GodClick()
    {
        if (!isGodPurchased)
        {
            ApplySkin(godSkin);
            defaultBtn.interactable = true;
            godBtn.interactable = false;
            beautyBtn.interactable = true;
            isDefaultPurchased = false;
            isBeautyPurchased = false;
            isGodPurchased = true;
        }
    }
    private void Update()
    {
        PlayerPrefs.SetInt("IsBeautyPurchased", isBeautyPurchased ? 1 : 0);
        PlayerPrefs.SetInt("IsGodPurchased", isGodPurchased ? 1 : 0);
        PlayerPrefs.SetInt("IsDefaultPurchased", isDefaultPurchased ? 1 : 0);
    }
  
}