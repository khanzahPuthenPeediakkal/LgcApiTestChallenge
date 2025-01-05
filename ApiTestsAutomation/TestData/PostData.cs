namespace ApiTestsAutomation.TestData
{
    public static class PostData
    {
        public static object CreatePost(int userId, string title, string body)
        {
            return new
            {
                userId = userId,
                title = title,
                body = body
            };
        }
    }
}
