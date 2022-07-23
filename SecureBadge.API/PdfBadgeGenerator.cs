using System;
using System.IO;

namespace SecureBadge.API
{
    public class PdfBadgeGenerator
    {


        public PdfBadgeGenerator()
        {

            // 30 Day Trail Key
            IronPdf.License.LicenseKey = "IRONPDF.CJPUVVULA.31074-DE5C06B6BB-H7ZC66-GWTVQICY4PRW-BE44WGXLQJC3-MIBT2FF2A3TX-EJNF2IS4FVUH-QQYMC5XK55LO-Z3VHHC-TCR75QXPAESHEA-DEPLOYMENT.TRIAL-IGSAAE.TRIAL.EXPIRES.22.AUG.2022";
        }

        public string GeneratePdfBatch()
        {
            var renderer = new IronPdf.ChromePdfRenderer();
            var filePath = Path.Combine(@"BadgeTemplate\", "BadgeTemplate.html");
            var pdf = renderer.RenderHTMLFileAsPdf(filePath);
            var guid = Guid.NewGuid();
            var assetPath = Path.Combine(@"BadeTemplate\", guid + ".pdf");
            pdf.SaveAs(assetPath);

            var restService = new RestService();
            var result = restService.PostToPinataApi(assetPath, guid + "_Certificate").Result;
            return result;
        }
    }
}
