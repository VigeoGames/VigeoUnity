#if UNITY_2019_1_OR_NEWER

using NUnit.Framework;

namespace Vigeo {
    
    public class ScopeExtensionsTests {

        [Test]
        public void Also_Scope_Extension_Tests() {
            // Calling [Also()] on value types
            true.Also(@this => Assert.AreEqual(@this, true));
            ((bool?) null).Also(@this => Assert.Fail("Also() block should not be called when nullable value type is null."));
            ((bool?) true).Also(@this => Assert.AreEqual(@this, true));

            // Calling [Also()] on reference types
            ((string) null).Also(@this => Assert.Fail("Also() block should not be called when reference type is null."));
            "".Also(@this => Assert.AreEqual(@this, ""));
            
            // Calling [Also()] on value types ignoring [@this]
            ((bool?) null).Also(() => Assert.Fail("Also() block should not be called when nullable value type is null."));
            ((bool?) true).Also(() => {});
            
            true.Also(() => {});
            
            // Calling [Also()] on reference types ignoring [@this]
            ((string) null).Also(() => Assert.Fail("Also() block should not be called when reference type is null."));
            "".Also(() => {});
            
            // Calling [Also()] for result on value types
            var _1 = ((int?) null).Also(@this => {
                Assert.Fail("Also() block should not be called for result when nullable value type is null.");
            });
            Assert.IsNull(_1, "Calling [Also()] for result on null value type should not change result type.");
            
            Assert.AreEqual(1.Also(@this => {}), 1);
            
            // Calling [Also()] for result on reference types
            var _2 = ((string) null).Also(@this => {
                Assert.Fail("Also() block should not be called for result when reference type is null.");
            });
            Assert.IsNull(_2, "Calling [Also()] for result on null reference type should yield null.");
            
            Assert.AreEqual("".Also(@this => {}), "");
            
            // Calling [Also()] for result on value types ignoring [@this]
            var _3 = ((int?) null).Also(() => {
                Assert.Fail("Also() block should not be called for result when nullable value type is null.");
            });
            Assert.IsNull(_3, "Calling [Also()] for result on null value type should not change result type.");
            
            Assert.AreEqual(1.Also(() => {}), 1);
            
            // Calling [Also()] for result on reference types ignoring [@this]
            var _4 = ((string) null).Also(() => {
                Assert.Fail("Also() block should not be called for result when reference type is null.");
            });
            Assert.IsNull(_4, "Calling [Also()] for result on null reference type should yield null.");
            
            Assert.AreEqual("".Also(() => {}), "");

            // Calling [Also()] for result on value types ignoring [@this] with [block] returning different type
            var _5 = ((int?) null).Also(() => {
                Assert.Fail("Also() block should not be called for result when nullable value type is null.");
                return true;
            });
            Assert.IsNull(_5, "Calling [Also()] for result on null value type should not change result type.");
            
            Assert.AreEqual(1.Also(() => true), 1);
            
            // Calling [Also()] for result on reference types ignoring [@this] with [block] returning different type
            var _6 = ((string) null).Also(() => {
                Assert.Fail("Also() block should not be called for result when reference type is null.");
                return true;
            });
            Assert.IsNull(_6, "Calling [Also()] for result on null reference type should yield null.");
            
            Assert.AreEqual("".Also(() => true), "");

            // Chaining [Also()] calls on reference types
            var _7 = ((string) null).Also(@this => {
                Assert.Fail("Also() block should not be called for result when reference type is null.");
            }).Also(@this => {
                Assert.Fail("Also() block should not be called for result when reference type is null.");
            });
            Assert.IsNull(_7, "Chaining calls to [Also()] for result on null reference type should yield null.");
            
            // Chaining [Also()] calls on value types
            var _8 = ((int?) null).Also(() => {
                Assert.Fail("Also() block should not be called for result when nullable value type is null.");
                return true;
            }).Also(() => {
                Assert.Fail("Also() block should not be called for result when nullable value type is null.");
                return true;
            });
            Assert.IsNull(_8, "Calling [Also()] for result on null value type should not change result type.");
        }
        
        [Test]
        public void Apply_Scope_Extension_Tests() {
            // Calling [Apply()] on reference types
            var _1 = new string[1].Apply(@this => {
                @this[0] = "";
            });
            Assert.AreEqual(_1[0], "");
    
            var _2 = new string[1].Apply(@this => {
                @this[0] = "";
                return true;
            });
            Assert.AreEqual(_2[0], "");
    
            // Chaining [Apply()] calls
            var _3 = new string[2].Apply(@this => {
                @this[0] = "";
                @this[1] = "";
            });
            Assert.AreEqual(_3[0], "");
            Assert.AreEqual(_3[1], "");
        }

        [Test]
        public void Run_Scope_Extension_Tests() {
            // Calling [Run()] on value types
            ((bool?) null).Run(@this => Assert.Fail("Run() block should not be called when nullable value type is null."));
            ((bool?) true).Run(@this => Assert.AreEqual(@this, true));
            
            true.Run(@this => Assert.AreEqual(@this, true));
            
            // Calling [Run()] on reference types
            ((string) null).Run(@this => Assert.Fail("Run() block should not be called when reference type is null."));
            "".Run(@this => Assert.AreEqual(@this, ""));
            
            // Calling [Run()] for result on value types
            var _1 = ((int?) null).Run(@this => {
                Assert.Fail("Run() block should not be called for result when nullable value type is null.");
                return true;
            });
            Assert.NotNull(_1, "Calling [Run()] on null value type should yield default non-nullable value of this type.");
            
            Assert.AreEqual(1.Run(@this => @this), 1);
            
            // Calling [Run()] for result on reference types
            var _2 = ((string) null).Run(@this => {
                Assert.Fail("Run() block should not be called for result when reference type is null.");
                return true;
            });
            Assert.NotNull(_2, "Calling [Run()] on null reference type with block returning value type should not yield null.");
            
            var _3 = ((string) null).Run(@this => {
                Assert.Fail("Run() block should not be called for result when reference type is null.");
                return @this;
            });
            Assert.IsNull(_3, "Calling [Run()] on null reference type should yield null.");
            
            Assert.AreEqual("".Run(@this => @this), "");
        }
    }
}

#endif
