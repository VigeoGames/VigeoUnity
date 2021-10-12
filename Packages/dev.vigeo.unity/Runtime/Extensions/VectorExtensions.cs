using UnityEngine;

namespace Vigeo {

    public static class VectorExtensions {

        public static Vector3 To(this Vector3 @this, Vector3 target) =>
            target - @this;
        
        public static Vector3 DirectionTo(this Vector3 @this, Vector3 target) =>
            @this.To(target).normalized;
        
        public static Vector3 With(this Vector3 @this, float? x = null, float? y = null, float? z = null) =>
            new Vector3(x ?? @this.x, y ?? @this.y, z ?? @this.z);

        public static Vector3 Set(this Vector3 @this, float? x = null, float? y = null, float? z = null) => @this.Apply(vector =>
            vector.Set(x ?? vector.x, y ?? vector.y, z ?? vector.z)
        );
    }
}
