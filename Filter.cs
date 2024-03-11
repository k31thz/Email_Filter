using System;
using System.Collections.Generic;


namespace Email_Filter
{
    public class Filter
    {
        public static Tuple<bool, string> CensorEmail(List<string> classifiedWords, string emailText)
        {
            bool flag = false;

            foreach (string word in classifiedWords)
            {
                if (emailText.Contains(word))
                {
                    flag = true;
                    emailText = emailText.Replace(word, new string('*', word.Length));
                }
            }
            return Tuple.Create(flag, emailText);
        }
    }
}
