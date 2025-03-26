// ReSharper disable MethodOverloadWithOptionalParameter // silences warnings related to optional parameter overloads requied to prevent clashes betwen class/struct versions
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local
using System;

namespace Vigeo  {
    
    public static class TupleScopeExtensions {

#region [Run()] scope extension method (various pair tuple versions, returning void)

        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, struct]. The [block] will not be called if
        /// any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2>(this (T1, T2) @this, Action<T1, T2> block, T1 _ = default, T2 __ = default)
            where T1 : struct
            where T2 : struct
        {
            block(@this.Item1, @this.Item2);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2>(this (T1?, T2) @this, Action<T1, T2> block, T1 _ = default)
            where T1 : struct
            where T2 : struct
        {
            if (!@this.Item1.HasValue) return;
            block(@this.Item1.Value, @this.Item2);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, nullable struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2>(this (T1, T2?) @this, Action<T1, T2> block, T1 _ = default)
            where T1 : struct
            where T2 : struct
        {
            if (!@this.Item2.HasValue) return;
            block(@this.Item1, @this.Item2.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, nullable struct]. The [block] will
        /// not be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2>(this (T1?, T2?) @this, Action<T1, T2> block, T1 _ = default)
            where T1 : struct
            where T2 : struct
        {
            if (!@this.Item1.HasValue || !@this.Item2.HasValue) return;
            block(@this.Item1.Value, @this.Item2.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, class]. The [block] will not be called if
        /// any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2>(this (T1, T2) @this, Action<T1, T2> block, T1 _ = default)
            where T1 : struct
            where T2 : class
        {
            if (@this.Item2 == null) return;
            block(@this.Item1, @this.Item2);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, class]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2>(this (T1?, T2) @this, Action<T1, T2> block, T1 _ = default, T2 __ = default)
            where T1 : struct
            where T2 : class
        {
            if (!@this.Item1.HasValue || @this.Item2 == null) return;
            block(@this.Item1.Value, @this.Item2);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, struct]. The [block] will not be called if
        /// any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2>(this (T1, T2) @this, Action<T1, T2> block, T2 _ = default)
            where T1 : class
            where T2 : struct
        {
            if (@this.Item1 == null) return;
            block(@this.Item1, @this.Item2);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, nullable struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2>(this (T1, T2?) @this, Action<T1, T2> block, T2 _ = default)
            where T1 : class
            where T2 : struct
        {
            if (@this.Item1 == null || !@this.Item2.HasValue) return;
            block(@this.Item1, @this.Item2.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, class]. The [block] will not be called if any
        /// element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2>(this (T1, T2) @this, Action<T1, T2> block)
            where T1 : class
            where T2 : class
        {
            if (@this.Item1 == null || @this.Item2 == null) return;
            block(@this.Item1, @this.Item2);
        }

#endregion

#region [Run()] scope extension method (various pair tuple versions, returning result)

        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, struct]. The [block] will not be called if
        /// any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static R Run<R, T1, T2>(this (T1, T2) @this, Func<T1, T2, R> block, T1 _ = default, T2 __ = default)
            where T1 : struct
            where T2 : struct
        {
            return block(@this.Item1, @this.Item2);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<R, T1, T2>(this (T1?, T2) @this, Func<T1, T2, R> block, T1 _ = default)
            where T1 : struct
            where T2 : struct
        {
            if (!@this.Item1.HasValue) return default;
            return block(@this.Item1.Value, @this.Item2);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, nullable struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<R, T1, T2>(this (T1, T2?) @this, Func<T1, T2, R> block, T1 _ = default)
            where T1 : struct
            where T2 : struct
        {
            if (!@this.Item2.HasValue) return default;
            return block(@this.Item1, @this.Item2.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, nullable struct]. The [block] will
        /// not be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<R, T1, T2>(this (T1?, T2?) @this, Func<T1, T2, R> block, T1 _ = default)
            where T1 : struct
            where T2 : struct
        {
            if (!@this.Item1.HasValue || !@this.Item2.HasValue) return default;
            return block(@this.Item1.Value, @this.Item2.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, class]. The [block] will not be called if any
        /// element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static R Run<R, T1, T2>(this (T1, T2) @this, Func<T1, T2, R> block, T1 _ = default)
            where T1 : struct
            where T2 : class
        {
            if (@this.Item2 == null) return default;
            return block(@this.Item1, @this.Item2);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, class]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all parameters
        /// are guaranteed to be not null.
        /// </remarks>
        public static R Run<R, T1, T2>(this (T1?, T2) @this, Func<T1, T2, R> block, T1 _ = default, T2 __ = default)
            where T1 : struct
            where T2 : class
        {
            if (!@this.Item1.HasValue || @this.Item2 == null) return default;
            return block(@this.Item1.Value, @this.Item2);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, struct]. The [block] will not be called if any
        /// element of [@this] tuple is null but if it does get called, all parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<R, T1, T2>(this (T1, T2) @this, Func<T1, T2, R> block, T2 _ = default)
            where T1 : class
            where T2 : struct
        {
            if (@this.Item1 == null) return default;
            return block(@this.Item1, @this.Item2);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, nullable struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all parameters
        /// are guaranteed to be not null.
        /// </remarks>
        public static R Run<R, T1, T2>(this (T1, T2?) @this, Func<T1, T2, R> block, T2 _ = default)
            where T1 : class
            where T2 : struct
        {
            if (@this.Item1 == null || !@this.Item2.HasValue) return default;
            return block(@this.Item1, @this.Item2.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, class]. The [block] will not be called if any
        /// element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static R Run<R, T1, T2>(this (T1, T2) @this, Func<T1, T2, R> block)
            where T1 : class
            where T2 : class
        {
            if (@this.Item1 == null || @this.Item2 == null) return default;
            return block(@this.Item1, @this.Item2);
        }

#endregion

#region [Run()] scope extension method (various triple tuple versions, returning void)

        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, struct, struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all parameters
        /// are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3) @this, Action<T1, T2, T3> block, T1 _ = default, T2 __ = default, T3 ___ = default)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, struct, struct]. The [block] will
        /// not be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1?, T2, T3) @this, Action<T1, T2, T3> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1.HasValue == false) return;
            block(@this.Item1.Value, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, nullable struct, struct]. The [block] will
        /// not be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2?, T3) @this, Action<T1, T2, T3> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item2.HasValue == false) return;
            block(@this.Item1, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, struct, nullable struct]. The [block] will
        /// not be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3?) @this, Action<T1, T2, T3> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item3.HasValue == false) return;
            block(@this.Item1, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, nullable struct, nullable struct]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2?, T3?) @this, Action<T1, T2, T3> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item2.HasValue == false || @this.Item3.HasValue == false) return;
            block(@this.Item1, @this.Item2.Value, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, nullable struct, struct]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1?, T2?, T3) @this, Action<T1, T2, T3> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1.HasValue == false || @this.Item2.HasValue == false) return;
            block(@this.Item1.Value, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, struct, nullable struct]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1?, T2, T3?) @this, Action<T1, T2, T3> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1.HasValue == false || @this.Item3.HasValue == false) return;
            block(@this.Item1.Value, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, nullable struct, nullable struct].
        /// The [block] will not be called if any element of [@this] tuple is null but if it does
        /// get called, all parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1?, T2?, T3?) @this, Action<T1, T2, T3> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1.HasValue == false || @this.Item2.HasValue == false || @this.Item3.HasValue == false) return;
            block(@this.Item1.Value, @this.Item2.Value, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, struct, struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all parameters
        /// are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3) @this, Action<T1, T2, T3> block, T1 _ = default)
            where T1 : class
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1 == null) return;
            block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, nullable struct, struct]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2?, T3) @this, Action<T1, T2, T3> block, T1 _ = default)
            where T1 : class
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1 == null || @this.Item2.HasValue == false) return;
            block(@this.Item1, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, struct, nullable struct]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3?) @this, Action<T1, T2, T3> block, T1 _ = default)
            where T1 : class
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1 == null || @this.Item3.HasValue == false) return;
            block(@this.Item1, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, nullable struct, nullable struct]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2?, T3?) @this, Action<T1, T2, T3> block, T1 _ = default)
            where T1 : class
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1 == null || @this.Item2.HasValue == false || @this.Item3.HasValue == false) return;
            block(@this.Item1, @this.Item2.Value, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, class, struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all parameters
        /// are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3) @this, Action<T1, T2, T3> block, T1 _ = default, T2 __ = default)
            where T1 : struct
            where T2 : class
            where T3 : struct
        {
            if (@this.Item2 == null) return;
            block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, class, struct]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1?, T2, T3) @this, Action<T1, T2, T3> block, T1 _ = default)
            where T1 : struct
            where T2 : class
            where T3 : struct
        {
            if (@this.Item1.HasValue == false || @this.Item2 == null) return;
            block(@this.Item1.Value, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, class, nullable struct]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3?) @this, Action<T1, T2, T3> block, T1 _ = default, T2 __ = default)
            where T1 : struct
            where T2 : class
            where T3 : struct
        {
            if (@this.Item2 == null || @this.Item3.HasValue == false) return;
            block(@this.Item1, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, class, nullable struct]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1?, T2, T3?) @this, Action<T1, T2, T3> block, T1 _ = default, T2 __ = default)
            where T1 : struct
            where T2 : class
            where T3 : struct
        {
            if ( @this.Item1.HasValue == false || @this.Item2 == null || @this.Item3.HasValue == false) return;
            block(@this.Item1.Value, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, struct, class]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all parameters
        /// are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3) @this, Action<T1, T2, T3> block, T3 _ = default)
            where T1 : struct
            where T2 : struct
            where T3 : class
        {
            if (@this.Item3 == null) return;
            block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, struct, class]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1?, T2, T3) @this, Action<T1, T2, T3> block, T3 _ = default)
            where T1 : struct
            where T2 : struct
            where T3 : class
        {
            if (@this.Item1.HasValue == false || @this.Item3 == null) return;
            block(@this.Item1.Value, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, nullable struct, class]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2?, T3) @this, Action<T1, T2, T3> block, T3 _ = default)
            where T1 : struct
            where T2 : struct
            where T3 : class
        {
            if (@this.Item2.HasValue == false || @this.Item3 == null) return;
            block(@this.Item1, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, nullable struct, class]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1?, T2?, T3) @this, Action<T1, T2, T3> block, T3 _ = default)
            where T1 : struct
            where T2 : struct
            where T3 : class
        {
            if (@this.Item1.HasValue == false || @this.Item2.HasValue == false || @this.Item3 == null) return;
            block(@this.Item1.Value, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, class, class]. The [block] will not be called
        /// if any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3) @this, Action<T1, T2, T3> block, T1 _ = default, T1 __ = default)
            where T1 : struct
            where T2 : class
            where T3 : class
        {
            if (@this.Item2 == null || @this.Item3 == null) return;
            block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, class, class]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1?, T2, T3) @this, Action<T1, T2, T3> block, T1 _ = default, T1 __ = default)
            where T1 : struct
            where T2 : class
            where T3 : class
        {
            if (@this.Item1.HasValue == false || @this.Item2 == null || @this.Item3 == null) return;
            block(@this.Item1.Value, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, class, struct]. The [block] will not be called
        /// if any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3) @this, Action<T1, T2, T3> block, T2 _ = default)
            where T1 : class
            where T2 : class
            where T3 : struct
        {
            if (@this.Item1 == null || @this.Item2 == null) return;
            block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, class, nullable struct]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3?) @this, Action<T1, T2, T3> block, T1 _ = default, T2 __ = default, T3 ___ = default)
            where T1 : class
            where T2 : class
            where T3 : struct
        {
            if (@this.Item1 == null || @this.Item2 == null || @this.Item3.HasValue == false) return;
            block(@this.Item1, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, struct, class]. The [block] will not be called
        /// if any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3) @this, Action<T1, T2, T3> block, T2 _ = default, T2 __ = default)
            where T1 : class
            where T2 : struct
            where T3 : class
        {
            if (@this.Item1 == null || @this.Item3 == null) return;
            block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, nullable struct, class]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2?, T3) @this, Action<T1, T2, T3> block, T2 _ = default, T2 __ = default)
            where T1 : class
            where T2 : struct
            where T3 : class
        {
            if (@this.Item1 == null || @this.Item2.HasValue == false || @this.Item3 == null) return;
            block(@this.Item1, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, class, class]. The [block] will not be called
        /// if any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static void Run<T1, T2, T3>(this (T1, T2, T3) @this, Action<T1, T2, T3> block)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            if (@this.Item1 == null || @this.Item2 == null || @this.Item3 == null) return;
            block(@this.Item1, @this.Item2, @this.Item3);
        }

#endregion

#region [Run()] scope extension method (various triple tuple versions, returning result)

        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, struct, struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all parameters
        /// are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3) @this, Func<T1, T2, T3, R> block, T1 _ = default, T2 __ = default, T3 ___ = default)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, struct, struct]. The [block] will
        /// not be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1?, T2, T3) @this, Func<T1, T2, T3, R> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1.HasValue == false) return default;
            return block(@this.Item1.Value, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, nullable struct, struct]. The [block] will
        /// not be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2?, T3) @this, Func<T1, T2, T3, R> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item2.HasValue == false) return default;
            return block(@this.Item1, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, struct, nullable struct]. The [block] will
        /// not be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3?) @this, Func<T1, T2, T3, R> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item3.HasValue == false) return default;
            return block(@this.Item1, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, nullable struct, nullable struct]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2?, T3?) @this, Func<T1, T2, T3, R> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item2.HasValue == false || @this.Item3.HasValue == false) return default;
            return block(@this.Item1, @this.Item2.Value, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, nullable struct, struct]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1?, T2?, T3) @this, Func<T1, T2, T3, R> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1.HasValue == false || @this.Item2.HasValue == false) return default;
            return block(@this.Item1.Value, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, struct, nullable struct]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1?, T2, T3?) @this, Func<T1, T2, T3, R> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1.HasValue == false || @this.Item3.HasValue == false) return default;
            return block(@this.Item1.Value, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, nullable struct, nullable struct].
        /// The [block] will not be called if any element of [@this] tuple is null but if it does
        /// get called, all parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1?, T2?, T3?) @this, Func<T1, T2, T3, R> block)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1.HasValue == false || @this.Item2.HasValue == false || @this.Item3.HasValue == false) return default;
            return block(@this.Item1.Value, @this.Item2.Value, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, struct, struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all parameters
        /// are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3) @this, Func<T1, T2, T3, R> block, T1 _ = default)
            where T1 : class
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1 == null) return default;
            return block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, nullable struct, struct]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2?, T3) @this, Func<T1, T2, T3, R> block, T1 _ = default)
            where T1 : class
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1 == null || @this.Item2.HasValue == false) return default;
            return block(@this.Item1, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, struct, nullable struct]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3?) @this, Func<T1, T2, T3, R> block, T1 _ = default)
            where T1 : class
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1 == null || @this.Item3.HasValue == false) return default;
            return block(@this.Item1, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, nullable struct, nullable struct]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2?, T3?) @this, Func<T1, T2, T3, R> block, T1 _ = default)
            where T1 : class
            where T2 : struct
            where T3 : struct
        {
            if (@this.Item1 == null || @this.Item2.HasValue == false || @this.Item3.HasValue == false) return default;
            return block(@this.Item1, @this.Item2.Value, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, class, struct]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all parameters
        /// are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3) @this, Func<T1, T2, T3, R> block, T1 _ = default, T2 __ = default)
            where T1 : struct
            where T2 : class
            where T3 : struct
        {
            if (@this.Item2 == null) return default;
            return block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, class, struct]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1?, T2, T3) @this, Func<T1, T2, T3, R> block, T1 _ = default)
            where T1 : struct
            where T2 : class
            where T3 : struct
        {
            if (@this.Item1.HasValue == false || @this.Item2 == null) return default;
            return block(@this.Item1.Value, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, class, nullable struct]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3?) @this, Func<T1, T2, T3, R> block, T1 _ = default, T2 __ = default)
            where T1 : struct
            where T2 : class
            where T3 : struct
        {
            if (@this.Item2 == null || @this.Item3.HasValue == false) return default;
            return block(@this.Item1, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, class, nullable struct]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1?, T2, T3?) @this, Func<T1, T2, T3, R> block, T1 _ = default, T2 __ = default)
            where T1 : struct
            where T2 : class
            where T3 : struct
        {
            if ( @this.Item1.HasValue == false || @this.Item2 == null || @this.Item3.HasValue == false) return default;
            return block(@this.Item1.Value, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, struct, class]. The [block] will not be
        /// called if any element of [@this] tuple is null but if it does get called, all parameters
        /// are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3) @this, Func<T1, T2, T3, R> block, T3 _ = default)
            where T1 : struct
            where T2 : struct
            where T3 : class
        {
            if (@this.Item3 == null) return default;
            return block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, struct, class]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1?, T2, T3) @this, Func<T1, T2, T3, R> block, T3 _ = default)
            where T1 : struct
            where T2 : struct
            where T3 : class
        {
            if (@this.Item1.HasValue == false || @this.Item3 == null) return default;
            return block(@this.Item1.Value, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, nullable struct, class]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2?, T3) @this, Func<T1, T2, T3, R> block, T3 _ = default)
            where T1 : struct
            where T2 : struct
            where T3 : class
        {
            if (@this.Item2.HasValue == false || @this.Item3 == null) return default;
            return block(@this.Item1, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, nullable struct, class]. The [block]
        /// will not be called if any element of [@this] tuple is null but if it does get called,
        /// all parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1?, T2?, T3) @this, Func<T1, T2, T3, R> block, T3 _ = default)
            where T1 : struct
            where T2 : struct
            where T3 : class
        {
            if (@this.Item1.HasValue == false || @this.Item2.HasValue == false || @this.Item3 == null) return default;
            return block(@this.Item1.Value, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [struct, class, class]. The [block] will not be called
        /// if any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3) @this, Func<T1, T2, T3, R> block, T1 _ = default, T1 __ = default)
            where T1 : struct
            where T2 : class
            where T3 : class
        {
            if (@this.Item2 == null || @this.Item3 == null) return default;
            return block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [nullable struct, class, class]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1?, T2, T3) @this, Func<T1, T2, T3, R> block, T1 _ = default, T1 __ = default)
            where T1 : struct
            where T2 : class
            where T3 : class
        {
            if (@this.Item1.HasValue == false || @this.Item2 == null || @this.Item3 == null) return default;
            return block(@this.Item1.Value, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, class, struct]. The [block] will not be called
        /// if any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3) @this, Func<T1, T2, T3, R> block, T2 _ = default)
            where T1 : class
            where T2 : class
            where T3 : struct
        {
            if (@this.Item1 == null || @this.Item2 == null) return default;
            return block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, class, nullable struct]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3?) @this, Func<T1, T2, T3, R> block, T1 _ = default, T2 __ = default, T3 ___ = default)
            where T1 : class
            where T2 : class
            where T3 : struct
        {
            if (@this.Item1 == null || @this.Item2 == null || @this.Item3.HasValue == false) return default;
            return block(@this.Item1, @this.Item2, @this.Item3.Value);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, struct, class]. The [block] will not be called
        /// if any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3) @this, Func<T1, T2, T3, R> block, T2 _ = default, T2 __ = default)
            where T1 : class
            where T2 : struct
            where T3 : class
        {
            if (@this.Item1 == null || @this.Item3 == null) return default;
            return block(@this.Item1, @this.Item2, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, nullable struct, class]. The [block] will not
        /// be called if any element of [@this] tuple is null but if it does get called, all
        /// parameters are guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2?, T3) @this, Func<T1, T2, T3, R> block, T2 _ = default, T2 __ = default)
            where T1 : class
            where T2 : struct
            where T3 : class
        {
            if (@this.Item1 == null || @this.Item2.HasValue == false || @this.Item3 == null) return default;
            return block(@this.Item1, @this.Item2.Value, @this.Item3);
        }
        
        /// <summary>
        /// Runs provided [block] giving it access to elements of [@this] tuple ensuring that all
        /// of them are not null and returning result of the call.
        /// </summary>
        /// <remarks>
        /// This version handles constraints: [class, class, class]. The [block] will not be called
        /// if any element of [@this] tuple is null but if it does get called, all parameters are
        /// guaranteed to be not null.
        /// </remarks>
        public static R Run<T1, T2, T3, R>(this (T1, T2, T3) @this, Func<T1, T2, T3, R> block)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            if (@this.Item1 == null || @this.Item2 == null || @this.Item3 == null) return default;
            return block(@this.Item1, @this.Item2, @this.Item3);
        }

#endregion

    }
}
