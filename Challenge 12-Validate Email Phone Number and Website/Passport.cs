using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace Challenge_12_Validate_Email_Phone_Number_and_Website
{
    public class Passport : IDataErrorInfo
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string ZipCode { get; set; }
        public string Website { get; set; }

        private Regex _regex;

        #region ValidatePatterns
        private string _emailPatternValidate;
        private string _phoneNumberPatternValidate;
        private string _dateOfBirthPatternValidate;
        private string _zipCodePatternValidate;
        private string _websitePatternValidate;

        public Passport()
        {
            InitializePatterns();
        }
        #endregion

        private void InitializePatterns()
        {
            _emailPatternValidate = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            _phoneNumberPatternValidate = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            _dateOfBirthPatternValidate = @"^\d{1,2}[/.-]\d{1,2}[/.-]\d{4}$";
            _zipCodePatternValidate = @"^\d{5}$";
            _websitePatternValidate = @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
        }

        public void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GoCheck();
            }
            catch (IOException exception)
            {
                MessageBox.Show(exception.Message, "Ooops", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ooops", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        private void GoCheck()
        {
            if (!string.IsNullOrEmpty(Email)
                && !string.IsNullOrEmpty(PhoneNumber)
                && !string.IsNullOrEmpty(DateOfBirth)
                && !string.IsNullOrEmpty(ZipCode)
                && !string.IsNullOrEmpty(Website))
            {
                ValidateInfo();
            }
            else
            {
                throw new IOException("Fill in all the fields!");
            }
        }

        #region ValidatingFieldsMethods
        private void ValidateInfo()
        {
            if (!ValidateEmail())
            {
                throw new IOException("email address is invalid");
            }
            if (!ValidatePhoneNumber())
            {
                throw new IOException("phone number is invalid");
            }
            if (!ValidateDateOfBirth())
            {
                throw new IOException("date of birth is invalid");
            }
            if (!ValidateZipCode())
            {
                throw new IOException("zip code is invalid");
            }
            if (!ValidateWebsite())
            {
                throw new IOException("url is invalid");
            }
            MessageBox.Show("Information saved successfully!", "Success", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private bool ValidateWebsite()
        {
            _regex = new Regex(_websitePatternValidate);
            if (string.IsNullOrEmpty(Website))
            {
                return false;
            }
            return _regex.IsMatch(Website);
        }

        private bool ValidateZipCode()
        {
            _regex = new Regex(_zipCodePatternValidate);
            if (string.IsNullOrEmpty(ZipCode))
            {
                return false;
            }
            return _regex.IsMatch(ZipCode);
        }

        private bool ValidateDateOfBirth()
        {
            _regex = new Regex(_dateOfBirthPatternValidate);
            if (string.IsNullOrEmpty(DateOfBirth))
            {
                return false;
            }
            return _regex.IsMatch(DateOfBirth);
        }

        private bool ValidatePhoneNumber()
        {
            _regex = new Regex(_phoneNumberPatternValidate);
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                return false;
            }
            return _regex.IsMatch(PhoneNumber);
        }

        private bool ValidateEmail()
        {
            _regex = new Regex(_emailPatternValidate);
            if (string.IsNullOrEmpty(Email))
            {
                return false;
            }
            return _regex.IsMatch(Email);
        }
        #endregion

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Email":
                        if (!ValidateEmail())
                        {
                            error = "Enter the correct email!";
                        }
                        break;
                    case "PhoneNumber":
                        if (!ValidatePhoneNumber())
                        {
                            error = "Enter the correct phone number!";
                        }
                        break;
                    case "DateOfBirth":
                        if (!ValidateDateOfBirth())
                        {
                            error = "Enter the correct date of birth!";
                        }
                        break;
                    case "ZipCode":
                        if (!ValidateZipCode())
                        {
                            error = "Enter the correct zip code!";
                        }
                        break;
                    case "Website":
                        if (!ValidateWebsite())
                        {
                            error = "Enter the correct website!";
                        }
                        break;
                }
                return error;
            }
        }

        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public string Error { get; }
    }
}