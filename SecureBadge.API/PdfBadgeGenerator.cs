﻿using System;
using System.IO;
using System.Reflection;

namespace SecureBadge.API
{
    public class PdfBadgeGenerator
    {


        public PdfBadgeGenerator()
        {

            // 30 Day Trail Key
            IronPdf.License.LicenseKey = "IRONPDF.CJPUVVULA.31074-DE5C06B6BB-H7ZC66-GWTVQICY4PRW-BE44WGXLQJC3-MIBT2FF2A3TX-EJNF2IS4FVUH-QQYMC5XK55LO-Z3VHHC-TCR75QXPAESHEA-DEPLOYMENT.TRIAL-IGSAAE.TRIAL.EXPIRES.22.AUG.2022";
        }

        public string GeneratePdfBatch(string FirstName, string LastName)
        {
            var renderer = new IronPdf.ChromePdfRenderer();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BadgeTemplate\", "BadgeTemplate.html");
            var pdf = renderer.RenderHTMLFileAsPdf(filePath);
            var guid = Guid.NewGuid();
            var assetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BadgeTemplate\", guid + ".pdf");
            pdf.SaveAs(assetPath);

            var restService = new RestService();
            var result = restService.PostToPinataApi(assetPath, guid + "_Certificate").Result;
            return result;
        }
    }
}
