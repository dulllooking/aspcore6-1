namespace aspcore6_1.Service
{
    public interface IMail
    {
        // 強迫實作帳密
        public string Account { get; set; }

        public string Password { get; set; }

        public void SendMail(string mailTo, string subject, string body);

        public void SendMailWithCC(string mailTo, string subject, string body, string mailToCC);

        public void SendMailWithFile(string mailTo, string subject, string body, string filePath);
    }
}
