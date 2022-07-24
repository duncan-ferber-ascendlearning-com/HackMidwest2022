using System;
using System.IO;
using System.Reflection;
using SecureBadge.API.Models;
using Telnyx;

namespace SecureBadge.API
{
    public class PdfBadgeGenerator
    {


        public PdfBadgeGenerator()
        {

            // 30 Day Trail Key
            IronPdf.License.LicenseKey = "IRONPDF.CJPUVVULA.31074-DE5C06B6BB-H7ZC66-GWTVQICY4PRW-BE44WGXLQJC3-MIBT2FF2A3TX-EJNF2IS4FVUH-QQYMC5XK55LO-Z3VHHC-TCR75QXPAESHEA-DEPLOYMENT.TRIAL-IGSAAE.TRIAL.EXPIRES.22.AUG.2022";
        }

        public string GeneratePdfBatch(string firstName, string lastName, string badgeTemplate, string assessmentName)
        {
            var renderer = new IronPdf.ChromePdfRenderer();
            var random = new Random();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BadgeTemplate\", badgeTemplate + ".html");
            var fileString = File.ReadAllText(filePath);
            var formatFirstName = Char.ToUpperInvariant(firstName[0]) + firstName.Substring(1).ToLowerInvariant();
            var formatLastName = Char.ToUpperInvariant(lastName[0]) + lastName.Substring(1).ToLowerInvariant();
            var dateCompleted = DateTime.Now.ToShortDateString();
            var timeCompleted = DateTime.Now.ToShortTimeString();
            fileString = fileString.Replace("FirstName", formatFirstName)
                .Replace("LastName", formatLastName)
                .Replace("DateAwarded", dateCompleted)
                .Replace("AssessmentName", assessmentName)
                .Replace("TimeCompleted", timeCompleted);               
            renderer.RenderingOptions.CustomCssUrl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BadgeTemplate\", "BadgeTemplate.css");
            var pdf = renderer.RenderHtmlAsPdf(fileString);
            var guid = Guid.NewGuid();
            var assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BadgeTemplate\", guid + ".pdf");
            pdf.SaveAs(assetPath);

            var restService = new RestService();
            var result = restService.PostToPinataApi(assetPath, guid + "_Certificate", assessmentName, formatFirstName + "_" + formatLastName, dateCompleted, timeCompleted).Result;
            SendMessageToLearner(result);
            return result;
        }


        public void SendMessageToLearner(string result)
        {
            try
            {
                const string TELNYX_API_KEY = "KEY01822E449A00BC4BB944D94B26B37A3C_d4zQrNbHed3sp9ah412eQd";
                TelnyxConfiguration.SetApiKey(TELNYX_API_KEY);
                var service = new MessagingSenderIdService();
                var options = new NewMessagingSenderId
                {
                    MessagingProfileId = Guid.Parse("4001822e-47cc-49c9-9104-1e4fb22515e5"),
                    From = "+19133571167", // alphanumeric sender id
                    To = "+19136020379",
                    Text = "Congratulations!.You earned a badge from Ascend Learning! Check it out!  " + result
                };
                var messageResponse = service.CreateAsync(options).Result;
            }
            catch (Exception e)
            {
                //ignore
            }
            
           

        }
    }



}
