﻿using System.Collections.Generic;

namespace P3D.Game
{
    public static class CollectionsExtensions
    {
        public static T First<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }

            return list[0];
        }
    }
}