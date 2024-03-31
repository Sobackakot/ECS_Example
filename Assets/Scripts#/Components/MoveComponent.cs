using Unity.Entities;
using Unity.Mathematics;
using UnityEngine; 

public class MoveComponent : MonoBehaviour
{ 
    private class Baker : Baker<MoveComponent>
    {
        public override void Bake(MoveComponent authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new MoveSpeed
            {
                movementVector = new Vector3(UnityEngine.Random.Range(-1f, +1f), 0, UnityEngine.Random.Range(-1f, +1f))
            });

        }
    }
}

public struct MoveSpeed : IComponentData
{
    public float3 movementVector;
}