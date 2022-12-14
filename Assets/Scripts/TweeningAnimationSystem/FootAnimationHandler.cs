using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FootAnimationHandler : MonoBehaviour
{
    public float height = 1;
    private float _initialHeight;

    public float duration;

    public AnimationCurve animationCurve;





    // Start is called before the first frame update
    void Start()
    {
        _initialHeight = transform.position.y;
        var ascending = transform.DOLocalMoveY(_initialHeight+height,duration).SetEase(animationCurve);
        var descending = transform.DOLocalMoveY(_initialHeight,duration).SetEase(animationCurve);

        var sequency = DOTween.Sequence().Append(ascending).Append(descending).SetLoops(-1).Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
