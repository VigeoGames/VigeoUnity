using UnityEngine;

namespace Vigeo {

    public static class VectorExtensions {

        public static Vector3 To(this Vector3 @this, Vector3 target) =>
            target - @this;
        
        public static Vector3 DirectionTo(this Vector3 @this, Vector3 target) =>
            @this.To(target).normalized;
        
        public static Vector3 With(this Vector3 @this, float? x = null, float? y = null, float? z = null) =>
            new Vector3(x ?? @this.x, y ?? @this.y, z ?? @this.z);

        public static ref Vector3 Set(this ref Vector3 @this, float? x = null, float? y = null, float? z = null) =>
            ref @this.Apply((ref Vector3 vector) =>
                vector.Set(x ?? vector.x, y ?? vector.y, z ?? vector.z)
            );
        
        public static Vector2 XY(this Vector3 @this) =>
            new Vector2(@this.x, @this.y);

        public static Vector2 XZ(this Vector3 @this) =>
            new Vector2(@this.x, @this.z);
    }
}
