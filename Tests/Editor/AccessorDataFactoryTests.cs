// Copyright 2020-2026 Andreas Atteneder and contributors
// SPDX-License-Identifier: Apache-2.0

using GLTFast.Schema;
using NUnit.Framework;
using UnityEngine;

namespace GLTFast.Tests
{
    class AccessorDataFactoryTests
    {
        [Test]
        public void CreatesZeroTranslationDataWithoutBufferView()
        {
            var result = AccessorDataFactory.CreateZeroInitializedAnimationData(
                GltfAccessorAttributeType.VEC3,
                AccessorUsage.Translation,
                2
            ) as AccessorNativeData<Vector3>;

            Assert.NotNull(result);
            Assert.AreEqual(2, result.data.Length);
            Assert.AreEqual(Vector3.zero, result.data[0]);
            Assert.AreEqual(Vector3.zero, result.data[1]);
            result.Dispose();
        }

        [Test]
        public void LeavesCompressedMeshMetadataUnallocated()
        {
            var result = AccessorDataFactory.CreateZeroInitializedAnimationData(
                GltfAccessorAttributeType.VEC3,
                AccessorUsage.Position,
                2
            );

            Assert.IsNull(result);
        }

        [Test]
        public void CreatesZeroWeightDataWithoutBufferView()
        {
            var result = AccessorDataFactory.CreateZeroInitializedAnimationData(
                GltfAccessorAttributeType.SCALAR,
                AccessorUsage.Weight,
                3
            ) as AccessorNativeData<float>;

            Assert.NotNull(result);
            Assert.AreEqual(3, result.data.Length);
            Assert.AreEqual(0f, result.data[2]);
            result.Dispose();
        }
    }
}
