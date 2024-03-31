 
using Unity.Entities;
using Unity.Transforms;

public readonly partial struct MoveRotateAspect : IAspect
{
    public readonly RefRO<CubeTag> cubeComponent; // тут можно назначить компонент-таг любого объекта для исключения других объектов
    public readonly RefRW<LocalTransform> localTransform;
    public readonly RefRO<RotateSpeed> rotateSpeed;
    public readonly RefRO<MoveSpeed> moveSpeed;

    public void MoveRotateObject(float delatTime)
    {
        localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.speed * delatTime);
        localTransform.ValueRW = localTransform.ValueRO.Translate(moveSpeed.ValueRO.movementVector * delatTime);
    }

}
