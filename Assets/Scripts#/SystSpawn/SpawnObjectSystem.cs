using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms; 

public partial struct SpawnObjectSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<ObjectPrefab>();
    }
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
        ObjectPrefab prefab = SystemAPI.GetSingleton<ObjectPrefab>();
        for(int i = 0; i <prefab.amountToSpawn; i++)
        {
            Entity spawnedEntity = state.EntityManager.Instantiate(prefab.cubePrefab);
            SystemAPI.SetComponent(spawnedEntity, new LocalTransform
            {
                Position = new float3(UnityEngine.Random.Range(-15f, 15f), 0 , UnityEngine.Random.Range(-15f, 15f)),
                Rotation = quaternion.identity,
                Scale = 1f
            });
        }
    }
}
