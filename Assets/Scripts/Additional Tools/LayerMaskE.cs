using UnityEngine;

public static class LayerMaskE
{
    public static bool IsInLayer(LayerMask mask, int layer)
    {
        return mask == (mask | (1<< layer));
    }
    public static bool IsNotInLayer(LayerMask mask, int layer)
    {
        return mask != (mask | (1<< layer));
    }
}
