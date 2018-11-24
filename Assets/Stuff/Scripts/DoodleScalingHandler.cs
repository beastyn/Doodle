using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleScalingHandler : MonoBehaviour {

    [SerializeField] float doodleRelativeScale = 0.04f;

    public float GetDoodleRelativeScale()
    {
        return doodleRelativeScale;
    }
}
