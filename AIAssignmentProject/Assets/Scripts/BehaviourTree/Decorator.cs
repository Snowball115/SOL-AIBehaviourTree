using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Decorators modify the outcome of a node
public abstract class Decorator : BaseNode
{
    protected BaseNode childNode;
}
