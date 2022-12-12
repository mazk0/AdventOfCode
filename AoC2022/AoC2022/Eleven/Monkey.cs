namespace AoC2022.Eleven;

public class Monkey
{
    public int Id { get; set; }
    public List<long> Items { get; } = new();
    public string? OperationType { get; set; }
    public int OperationModifier { get; set; }
    public int TestDivider { get; set; }
    public int TargetTrue { get; set; }
    public int TargetFalse { get; set; }
    public bool ModifierTargetSelf { get; set; }
    public int InspectedItemCount { get; set; }
}