using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ********************
// Decorators modify the outcome of a node
// ********************
public abstract class Decorator : BaseNode
{
    // The node we want to modify
    protected BaseNode childNode;
}
