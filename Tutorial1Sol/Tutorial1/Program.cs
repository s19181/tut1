using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial1
{
    public class Program
    {
        public static async Task Main(string[] args) //Task same as void, but used for async programming(faster)
        {

            //string websiteUrl = null;
            //var x = websiteUrl ?? throw new ArgumentException("url cant be null"); (checking for null)


            var websiteUrl = args.Length > 0 ? args[0] : throw new ArgumentNullException();
          
            var httpClient = new HttpClient();
            var response =  await httpClient.GetAsync(websiteUrl);
            httpClient.Dispose();
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var htmlContent = await response.Content.ReadAsStringAsync();

                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var emailAddresses = regex.Matches(htmlContent);

                    if (emailAddresses.Count > 0)
                    {
                        foreach (var emailAddress in emailAddresses)
                        {
                            Console.WriteLine(emailAddress.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No email address found");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error while downloading the page");
            }




            Console.ReadKey();


            }
    }
}
