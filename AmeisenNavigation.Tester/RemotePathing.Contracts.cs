namespace AmeisenNavigation.Tester
{
    public static class RemotePathing
    {
        public const string EndpointPath = "DrawWorldPath";
    }

    public readonly record struct DrawWorldPathRequest(int mapId, Vector3[] path);
}
