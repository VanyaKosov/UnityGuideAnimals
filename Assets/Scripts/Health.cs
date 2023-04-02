using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject Bar;

    public int HP;

    private int _currentHP;

    private float _barScale;

    void Start()
    {
        _barScale = Bar.transform.localScale.x;

        _currentHP = HP;
    }

    internal bool Reduce()
    {
        _currentHP--;

        var barScale = Bar.transform.localScale;
        barScale.x = _barScale / HP * _currentHP;
        Bar.transform.localScale = barScale;

        return _currentHP <= 0;
    }
}
