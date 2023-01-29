namespace Tech_sell_user.Application
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string Secret { get; set; }
        public int TokenExpirationTimeInHours { get; set; } = 2;
        public string AwsSecretAccessKey { get; set; }
        public string AwsEmailSes { get; set; }
        public string AwsRegionEndpoint { get; set; }
        public string AwsAcessKeyId { get; set; }
        public string AwsBucketProfileImage { get; set; }
        public string AwsBucketFiles { get; set; }
        public string UrlFrontEnd { get; set; }
        public bool EnableEmailVerification { get; set; }
        public int? TimeZone { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public string AdminEmail { get; set; }
    }
}