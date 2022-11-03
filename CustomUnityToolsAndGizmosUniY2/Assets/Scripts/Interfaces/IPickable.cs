using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    void Pickup();
    void Drop(Vector3 location);


}

