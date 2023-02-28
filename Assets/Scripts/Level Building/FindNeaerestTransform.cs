using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public static class FindNeaerestTransform
    {
        public static Transform Find(Vector3 point, HashSet<Transform> transforms)
        {
            Transform nearest = null;
            float nearestDistance = 9999999999999f;


            float distance;
            foreach (var t in transforms)
            {
                distance = Vector3.Distance(point, t.position);
                if (distance < nearestDistance)
                    nearest = t;
            }


            if (nearest == null)
            {
                foreach (var t in transforms)
                {
                    nearest = t;
                    break;
                }
            }

            return nearest;
        }
    }
}
