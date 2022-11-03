using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
namespace P3D.Game
{
    [CustomEditor(typeof(MovingObject))]
    public class MovingObjectEditor : Editor
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]

        private static void Draw(MovingObject movingObject, GizmoType gizmoType)
        {
            if (!ShouldDraw(movingObject, gizmoType))
            {
                return;
            }
            if (movingObject.FromTransform == null || movingObject.ToTransform == null)
            {
                return;
            }
            
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(movingObject.FromTransform.position, 0.4f);
            Gizmos.DrawSphere(movingObject.ToTransform.position, 0.4f);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(movingObject.FromTransform.position,movingObject.ToTransform.position);
        }

        private static bool ShouldDraw(MovingObject movingObject, GizmoType gizmoType)
        {
            if (gizmoType == GizmoType.Selected)
            {
                return true;
            }

            Transform parent = movingObject.transform.parent;
            if (parent == Selection.activeTransform)
            {
                return true;
            }

            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i) == Selection.activeTransform)
                {
                    return true;
                }
            }

            return false;
        }
    }
}