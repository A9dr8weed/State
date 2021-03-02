namespace State
{
    public static class Program
    {
        private static void Main()
        {
            Steak account = new Steak("T-Bone");

            // Apply temperature changes.
            account.AddTemp(120);
            account.AddTemp(15);
            account.AddTemp(15);
            account.RemoveTemp(10);
            account.RemoveTemp(15);
            account.AddTemp(20);
            account.AddTemp(20);
            account.AddTemp(20);
        }
    }
}