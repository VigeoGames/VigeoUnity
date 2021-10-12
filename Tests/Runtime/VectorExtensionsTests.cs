#if UNITY_2019_1_OR_NEWER

using NUnit.Framework;
using UnityEngine;
using Object = System.Object;

namespace Vigeo {

    public class VectorExtensionsTests {

        [Test]
        public void Vector3_Extension_Tests() {
            var _1 = new Vector3(0, 0, 0).To(new Vector3(5, 0, 0));
            Assert.AreEqual(new Vector3(5, 0, 0), _1);
            
            var _2 = new Vector3(0, 0, 0).DirectionTo(new Vector3(5, 0, 0));
            Assert.AreEqual(new Vector3(1, 0, 0), _2);
            
            var _3 = new Vector3(0, 0, 0);
            var _4 = _3.With(z: 1);
            Assert.AreNotSame(_3, _4);
            Assert.AreEqual(1, _4.z);
            
            var _5 = new Vector3(0, 0, 0);
            var _6 = _5.Set(z: 1);
            Assert.AreEqual(1, _5.z);
            Assert.AreEqual(1, _6.z);
        }
    }
}

#endif
