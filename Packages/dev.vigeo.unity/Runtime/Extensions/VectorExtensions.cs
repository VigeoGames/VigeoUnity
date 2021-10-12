using UnityEngine;

namespace Vigeo {

    public static class VectorExtensions {

        public static Vector3 To(this Vector3 @this, Vector3 target) =>
            target - @this;
        
        public static Vector3 DirectionTo(this Vector3 @this, Vector3 target) =>
            @this.To(target).normalized;
    }
}
