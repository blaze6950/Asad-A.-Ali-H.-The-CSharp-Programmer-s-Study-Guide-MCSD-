using System;
using System.Security.Cryptography;
using System.Text;

namespace Challenge_16_Develop_a_SWF_app_and_perform_Salt_hashing
{
    public class AccountInfo
    {
        private string _pass;

        public AccountInfo()
        {
            
        }

        public AccountInfo(string login, String pass, string guid)
        {
            Login = login;
            Pass = pass;
            Guid = guid;
        }

        public string Login { get; set; }

        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public string Guid { get; set; }

        public override string ToString()
        {
            return $"Login: {Login}\t Password: {Pass}\t GUID: {Guid}";
        }

        public string GetPassHashCode(string pass)
        {
            if (string.IsNullOrEmpty(Guid))
            {
                Guid = System.Guid.NewGuid().ToString();
            }
            string saltedPassword = pass + Guid;
            var passwordInBytes = Encoding.UTF8.GetBytes(saltedPassword);
            HashAlgorithm sha512 = SHA512.Create();
            byte[] hashInBytes = sha512.ComputeHash(passwordInBytes);
            var hashedData = new StringBuilder();
            foreach (var item in hashInBytes)
            {
                hashedData.Append(item);
            }
            return hashedData.ToString();
        }

        #pragma warning disable 659
        public override bool Equals(object obj)
        {
            var info = obj as AccountInfo;
            Guid = info?.Guid;
            return info != null &&
                   info.Pass.Equals(GetPassHashCode(Pass));
        }
        #pragma warning restore 659
    }
}
