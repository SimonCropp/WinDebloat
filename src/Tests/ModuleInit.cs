public static class ModuleInit
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifierSettings.NameForParameter<FindGroup>(_ => _.Method.Name);
        VerifierSettings.InitializePlugins();
    }
}