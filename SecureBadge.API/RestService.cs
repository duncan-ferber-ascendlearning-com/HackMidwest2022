﻿using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SecureBadge.API
{
    public class RestService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string Jwt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySW5mb3JtYXRpb24iOnsiaWQiOiIzNDk5YjUzYy04YTkxLTRmMzUtOGRmOC1jNWYyNmIzYjkzZTgiLCJlbWFpbCI6ImFzaG9rY2hpcnUxMjA1QGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJwaW5fcG9saWN5Ijp7InJlZ2lvbnMiOlt7ImlkIjoiRlJBMSIsImRlc2lyZWRSZXBsaWNhdGlvbkNvdW50IjoxfSx7ImlkIjoiTllDMSIsImRlc2lyZWRSZXBsaWNhdGlvbkNvdW50IjoxfV0sInZlcnNpb24iOjF9LCJtZmFfZW5hYmxlZCI6ZmFsc2UsInN0YXR1cyI6IkFDVElWRSJ9LCJhdXRoZW50aWNhdGlvblR5cGUiOiJzY29wZWRLZXkiLCJzY29wZWRLZXlLZXkiOiIxMDY2MWVhZDY0NzZkMTA3MGMxMiIsInNjb3BlZEtleVNlY3JldCI6ImExYjE1OTc4NWJmN2Q5YmNmYjdjYWZjNDMyNjY5NTFlMDcxYmI2Mzc4ZDg5NTE1ZDBjMzFiNDVjNjJjOGIwZGQiLCJpYXQiOjE2NTg0MjUwMDB9.5miZT5bVNrF4SiQcnJHbIuH_MW4eM6yCWLnnsZ9Z7qY";

        public async Task<bool> PostToPinataApi(string assetPath, string fileName)
        {

            var buffer = AssetBytes(assetPath);

            using var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.pinata.cloud/pinning/pinFileToIPFS");
            request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Jwt);

            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new ByteArrayContent(buffer), "file", fileName);
            multipartContent.Add(new StringContent("\"{\"cidVersion\": 1}\""), "pinataOptions");
            multipartContent.Add(new StringContent("\"{\"name\": \"Certificate\", \"keyvalues\": {\"company\": \"Ascend\"}}\""), "pinataMetadata");

            request.Content = multipartContent;

            var response = await _httpClient.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            return false;
        }

        public byte[] AssetBytes(string assetPath)
        {
            byte[] buffer;
            var fileStream = new FileStream(assetPath, FileMode.Open, FileAccess.Read);
            try
            {
                var length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                var sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }

            return buffer;

        }
    }
}
