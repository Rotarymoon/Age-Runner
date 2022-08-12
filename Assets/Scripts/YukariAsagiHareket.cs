using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class YukariAsagiHareket : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutCubic);
    }
}
