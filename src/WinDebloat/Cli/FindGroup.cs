using System.Diagnostics.CodeAnalysis;

public delegate bool FindGroup(string id, [NotNullWhen(true)] out Group? group);