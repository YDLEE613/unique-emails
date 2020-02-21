using System;
using System.Collections.Generic;
using UniqueEmail.Models;

namespace UniqueEmailContext
{
    public class MainContext
    {
        private const char _plusSign = '+';
        private const char _atSign = '@';
        private const char _periodSign = '.';
        private const string _gmailDomain = "@gmail.com";

        public HashSet<string> GetUniqueEmails(List<Email> emailArray)
        {
            HashSet<string> emailHashSet = new HashSet<string>();

            if (emailArray.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (Email eachEmail in emailArray)
                {
                    string result = null;
                    Boolean isValidDomain = false;

                    // check if trimmed email is empty
                    if (String.IsNullOrEmpty(eachEmail.emailAddress.Trim()))
                    {
                        continue;
                    }
                    else
                    {
                        string trimEachEmail = eachEmail.emailAddress.Trim();

                        int atPos = GetAtPos(trimEachEmail);

                        string firstHalf = string.IsNullOrEmpty(trimEachEmail) ? null : GetUserName(trimEachEmail, atPos);
                        string secondHalf = GetDomain(trimEachEmail, atPos);

                        isValidDomain = IsValidNameAndDomain(firstHalf, secondHalf);

                        if (!isValidDomain)
                        {
                            continue;
                        }
                        // remove any periods in firstHalf
                        result = RemovePeriods(firstHalf);

                        int plusPos = GetPlusPos(result);

                        // if there is no plus sign, concat email
                        if (plusPos > 0)
                        {
                            result = result.Substring(0, plusPos);
                        }else if(plusPos == 0)
                        {
                            continue;
                        }

                        // get the rest
                        result += secondHalf;

                    }

                    if (!string.IsNullOrEmpty(result) && isValidDomain)
                    {
                        emailHashSet.Add(result);
                    }
                }
            }

            return emailHashSet;
        }

        private Boolean IsValidNameAndDomain(string userName, string email)
        {
            return !string.IsNullOrEmpty(userName) && email.Equals(_gmailDomain);
        }

        private string GetDomain(string domain, int end)
        {
            if (end <= 0)
            {
                return null;
            }

            return domain.Substring(end);
        }

        private string GetUserName(string userName, int end)
        {
            if (end <= 0)
            {
                return null;
            }

            return userName.Substring(0, end);
        }

        private string RemovePeriods(string email)
        {
            if (email.Contains(_periodSign.ToString()))
            {
                return email.Replace(_periodSign.ToString(), string.Empty);
            }

            return email;
        }

        private int GetPlusPos(string email)
        {
            return email.IndexOf(_plusSign); ;
        }

        private int GetAtPos(string email)
        {
            return email.IndexOf(_atSign);
        }
    }
}
