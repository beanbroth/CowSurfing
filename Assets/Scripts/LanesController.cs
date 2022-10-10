using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesController : MonoBehaviour
{
    [SerializeField] Transform[] _lanes;

    public Transform[] Lanes { get => _lanes; }

}
