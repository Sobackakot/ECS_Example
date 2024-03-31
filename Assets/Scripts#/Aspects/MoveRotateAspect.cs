 
using Unity.Entities;
using Unity.Transforms;

public readonly partial struct MoveRotateAspect : IAspect
{
    public readonly RefRO<CubeTag> cubeComponent; // ��� ����� ��������� ���������-��� ������ ������� ��� ���������� ������ ��������
    public readonly RefRW<LocalTransform> localTransform;
    public readonly RefRO<RotateSpeed> rotateSpeed;
    public readonly RefRO<MoveSpeed> moveSpeed;

    public void MoveRotateObject(float delatTime)
    {
        localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.speed * delatTime);
        localTransform.ValueRW = localTransform.ValueRO.Translate(moveSpeed.ValueRO.movementVector * delatTime);
    }

}
