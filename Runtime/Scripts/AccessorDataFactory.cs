// Copyright 2020-2026 Andreas Atteneder and contributors
// SPDX-License-Identifier: Apache-2.0

using GLTFast.Schema;
using Unity.Collections;
using UnityEngine;

namespace GLTFast
{
    static class AccessorDataFactory
    {
        internal static AccessorDataBase CreateZeroInitializedAnimationData(
            GltfAccessorAttributeType attributeType,
            AccessorUsage usage,
            int count
        )
        {
            if (count < 0)
            {
                return null;
            }

            if (attributeType == GltfAccessorAttributeType.VEC3
                && (usage & (AccessorUsage.Translation | AccessorUsage.Scale)) != 0)
            {
                return Create<Vector3>(count);
            }

            if (attributeType == GltfAccessorAttributeType.VEC4
                && (usage & AccessorUsage.Rotation) != 0)
            {
                return Create<Quaternion>(count);
            }

            if (attributeType == GltfAccessorAttributeType.SCALAR
                && (usage & (AccessorUsage.AnimationTimes | AccessorUsage.Weight)) != 0)
            {
                return Create<float>(count);
            }

            return null;
        }

        static AccessorNativeData<T> Create<T>(int count) where T : struct
        {
            return new AccessorNativeData<T>
            {
                data = new NativeArray<T>(count, Allocator.Persistent, NativeArrayOptions.ClearMemory)
            };
        }
    }
}
