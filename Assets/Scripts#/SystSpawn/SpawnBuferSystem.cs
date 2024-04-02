using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct SpawnBuferSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<PlayerTag>();
    }
    public void OnUpdate(ref SystemState state)
    {
        if (!Input.GetMouseButtonDown(0)) return;

        ObjectPrefab newObject = SystemAPI.GetSingleton<ObjectPrefab>();
        EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(state.WorldUpdateAllocator);
        foreach(var localTransform in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<PlayerTag>())
        {
           Entity spawnedEntity =  entityCommandBuffer.Instantiate(newObject.cubePrefab);
            entityCommandBuffer.SetComponent(spawnedEntity, new LocalTransform
            {
                Position = localTransform.ValueRO.Position,
                Rotation = quaternion.identity,
                Scale = 1f
            });
        }
        entityCommandBuffer.Playback(state.EntityManager);
    }
}

