using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDrivable
{
    //Actions
    void Accelerate();

    void Brake();

    //Observations
    float GetSpeed();
}
