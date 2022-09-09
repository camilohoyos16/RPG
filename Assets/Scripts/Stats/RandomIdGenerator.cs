public static class RandomIdGenerator
{
    private static int m_idCounter;

    public static int GetNewRandomId() {
        return m_idCounter++;
    }
}
