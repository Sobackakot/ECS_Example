using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    public float speed;
    private class Baker : Baker<RotateComponent>
    {
        public override void Bake(RotateComponent authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RotateSpeed { speed = math.radians(authoring.speed)});
        }
    }
}
public struct RotateSpeed : IComponentData
{
    public float speed;
}
