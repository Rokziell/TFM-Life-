using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    [SerializeField] private LeanTweenType easeType;
    [SerializeField] private float delay;
    [SerializeField] private float animTime;

    void OnEnable()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), this.animTime).setDelay(this.delay).setEase(this.easeType);
    }
}
