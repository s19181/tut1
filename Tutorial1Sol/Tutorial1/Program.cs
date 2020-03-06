﻿using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial1
{
    public class Program
    {
        public static async Task Main(string[] args) //Task same as void, but used for async programming(faster)
        {
            var websiteUrl = args[0];
            var httpClient = new HttpClient();
            var response =  await httpClient.GetAsync(websiteUrl);
            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var emailAddresses = regex.Matches(htmlContent);
                foreach (var emailAddress in emailAddresses)
                {
                    Console.WriteLine(emailAddress.ToString());
                }
            }
            Console.ReadKey();


        }
    }
}
