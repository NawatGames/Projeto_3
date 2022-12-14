using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandAnimationHandler : MonoBehaviour
{

    public float duration;

    public AnimationCurve animationCurve;

    public float ti;
    public float tf;

    public Vector2 offset;

    public float xAxisElipse;
    public float yAxisElipse;


    // Start is called before the first frame update
    void Start()
    {
        var ida = DOTween.To(Refresh,ti,tf,duration).SetEase(animationCurve);
        var volta = DOTween.To(Refresh,tf,ti,duration).SetEase(animationCurve);
        
        var sequence = DOTween.Sequence().Append(ida).Append(volta).SetLoops(-1).Play();
        
    }
    void Refresh(float value)
    {
        var position = new Vector2(xAxisElipse*Mathf.Cos(value), yAxisElipse*Mathf.Sin(value)) + offset;

        transform.localPosition = (Vector3)position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

