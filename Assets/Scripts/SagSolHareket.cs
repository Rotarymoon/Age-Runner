using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SagSolHareket : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveX(2.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic);        
    }
}
