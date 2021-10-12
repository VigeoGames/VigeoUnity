using System;

namespace Vigeo {
    
    /// <summary>
    /// A set of scope extension methods inspired by Kotlin's scope extensions.
    /// </summary>
    /// <remarks>
    /// The implementations are loosely based on Kotlin versions with required adjustments for C#
    /// (i.e. no [this] override, separate implementation of the same method for reference and value
    /// type, if required, etc.). This means that not all use cases available in Kotlin are supported.
    /// </remarks>
    /// <seealso href="https://stackoverflow.com/questions/2974519/generic-constraints-where-t-struct-and-where-t-class#comment111131939_36775837">Generic constraints, where T : struct and where T : class</seealso>
    public static class ScopeExtensions {
        
#region [Also()] scope extension method (various versions)

        /// <summary>
        /// Returns [@this] but also calls provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as reference types (i.e. classes, arrays or
        /// delegates) and accepts a parameterless [block]. The [block] will not be called if [@this]
        /// is null but if it does, it's guaranteed to receive a non-null [@this].
        /// </remarks>
        public static T Also<T>(this T @this, Action block) where T : class {
            if (@this == null) {
                return null;
            }
            block();
            return @this;
        }

        /// <summary>
        /// Returns [@this] but also calls provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as non-nullable value types (i.e. structs, enums
        /// or primitives) and accepts a parameterless [block]. Parameter [defaultValue] is added
        /// only to prevent name clash with class-constrained version of [Also()]. When called,
        /// [block] is guaranteed to receive a non-null [@this].
        /// </remarks>
        // ReSharper disable once MethodOverloadWithOptionalParameter
        public static T Also<T>(this T @this, Action block, T defaultValue = default) where T : struct {
            block();
            return @this;
        }
        
        /// <summary>
        /// Returns [@this] but also calls provided [block] giving it access to [@this].
        /// </summary>
        /// This version supports types constrained as nullable value types (i.e. structs, enums or
        /// primitives) and accepts a parameterless [block]. The [block] will not be called if [@this]
        /// is null but if it does, it's guaranteed to receive a non-null [@this].
        /// </remarks>
        public static T? Also<T>(this T? @this, Action block) where T : struct {
            if (@this == null) {
                return null;
            }
            return ((T) @this).Also(block);
        }

        /// <summary>
        /// Returns [@this] but also calls provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as reference types (i.e. classes, arrays or
        /// delegates) and accepts a [block] that accepts parameter of type [T]. The [block] will
        /// not be called if [@this] is null but if it does, it's guaranteed to receive a non-null
        /// [@this].
        /// </remarks>
        public static T Also<T>(this T @this, Action<T> block) where T : class {
            if (@this == null) {
                return null;
            }
            block(@this);
            return @this;
        }
        
        /// <summary>
        /// Returns [@this] but also calls provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as non-nullable value types (i.e. structs, enums
        /// or primitives) and accepts a [block] that accepts parameter of type [T]. Parameter
        /// [defaultValue] is added only to prevent name clash with class-constrained version of
        /// [Also()]. When called, [block] is guaranteed to receive a non-null [@this].
        /// </remarks>
        // ReSharper disable once MethodOverloadWithOptionalParameter
        public static T Also<T>(this T @this, Action<T> block, T defaultValue = default) where T : struct {
            block(@this);
            return @this;
        }
        
        /// <summary>
        /// Returns [@this] but also calls provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as nullable value types (i.e. structs, enums or
        /// primitives) and accepts a [block] that accepts parameter of type [T]. The [block] will
        /// not be called if [@this] is null but if it does, it's guaranteed to receive a non-null
        /// [@this].
        /// </remarks>
        public static T? Also<T>(this T? @this, Action<T> block) where T : struct {
            if (@this == null) {
                return null;
            }
            return ((T) @this).Also(block);
        }

        /// <summary>
        /// Returns [@this] but also calls provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as reference types (i.e. classes, arrays or
        /// delegates) and accepts a parameterless [block] returning type [R]. The [block] will not
        /// be called if [@this] is null but if it does, it's guaranteed to receive a non-null [@this].
        /// </remarks>
        public static T Also<T, R>(this T @this, Func<R> block) where T : class {
            if (@this == null) {
                return null;
            }
            block();
            return @this;
        }

        /// <summary>
        /// Returns [@this] but also calls provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as non-nullable value types (i.e. structs, enums
        /// or primitives) and accepts a parameterless [block] returning type [R]. Parameter
        /// [defaultValue] is added only to prevent name clash with class-constrained version of
        /// [Also()]. When called, [block] is guaranteed to receive a non-null [@this].
        /// </remarks>
        // ReSharper disable once MethodOverloadWithOptionalParameter
        public static T Also<T, R>(this T @this, Func<R> block, T defaultValue = default) where T : struct {
            block();
            return @this;
        }
        
        /// <summary>
        /// Returns [@this] but also calls provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as nullable value types (i.e. structs, enums or
        /// primitives) and accepts a parameterless [block] returning type [R]. The [block] will not
        /// be called if [@this] is null (instead a default non-nullable value for type [R] will be
        /// returned) but if it does, it's guaranteed to receive a non-null [@this].
        /// </remarks>
        public static T? Also<T, R>(this T? @this, Func<R> block) where T : struct {
            if (@this == null) {
                return null;
            }
            return ((T) @this).Also(block);
        }
        
#endregion

#region [Run()] scope extension method (various versions)

        /// <summary>
        /// Runs provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as reference types (i.e. classes, arrays or
        /// delegates) and accepts [block] that accepts parameter of type [T] and returns void
        /// (non-assignment scenario). The [block] will not be called if [@this] is null but if it
        /// does, it's guaranteed to receive a non-null [@this].
        /// </remarks>
        public static void Run<T>(this T @this, Action<T> block) where T : class {
            if (@this == null) {
                return;
            }
            block(@this);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as non-nullable value types (i.e. structs, enums
        /// or primitives) and accepts [block] that accepts parameter of type [T] and returns void
        /// (non-assignment scenario). Parameter [defaultValue] is added only to prevent name clash
        /// with class-constrained version of [Run()].
        /// </remarks>
        // ReSharper disable once MethodOverloadWithOptionalParameter // we need [defaultValue] to prevent clash with class-constrained version of [Run()]
        public static void Run<T>(this T @this, Action<T> block, T defaultValue = default) where T : struct {
            block(@this);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to [@this].
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as nullable value types (i.e. structs, enums or
        /// primitives) and accepts [block] that accepts parameter of type [T] and returns void
        /// (non-assignment scenario). The [block] will not be called if [@this] is null but if it
        /// does, it's guaranteed to receive a non-null [@this].
        /// </remarks>
        public static void Run<T>(this T? @this, Action<T> block) where T : struct {
            if (@this == null) {
                return;
            }
            ((T) @this).Run(block);
        }

        /// <summary>
        /// Runs provided [block] giving it access to [@this] returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as reference types (i.e. classes, arrays or
        /// delegates) and accepts [block] that accepts parameter of type [T] and returns type [R]
        /// (assignment scenario). The [block] will not be called if [@this] is null but if it does,
        /// it's guaranteed to receive a non-null [@this].
        /// </remarks>
        public static R Run<T, R>(this T @this, Func<T, R> block) where T : class {
            if (@this == null) {
                return default;
            }
            return block(@this);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to [@this] returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as non-nullable value types (i.e. structs, enums
        /// or primitives) and accepts [block] that accepts parameter of type [T] and returns type
        /// [R] (assignment scenario). Parameter [defaultValue] is added only to prevent name clash
        /// with class-constrained version of [Run()].
        /// </remarks>
        // ReSharper disable once MethodOverloadWithOptionalParameter // we need [defaultValue] to prevent clash with class-constrained version of [Run()]
        public static R Run<T, R>(this T @this, Func<T, R> block, T defaultValue = default) where T : struct {
            return block(@this);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to [@this] returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version supports types constrained as nullable value types (i.e. structs, enums or
        /// primitives) and accepts [block] that accepts parameter of type [T] and returns type [R]
        /// (assignment scenario). The [block] will not be called if [@this] is null (instead a
        /// default non-nullable value for type [R] will be returned) but if it does, it's
        /// guaranteed to receive a non-null [@this].
        /// </remarks>
        public static R Run<T, R>(this T? @this, Func<T, R> block) where T : struct {
            if (@this == null) {
                return default;
            }
            return ((T) @this).Run(block);
        }
        
#endregion

    }
}
