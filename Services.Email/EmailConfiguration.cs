namespace Services.Email
{
    internal class EmailConfiguration
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string InviteUrl { get; set; }
        public string ChangePasswordUrl { get; set; }
    }
}