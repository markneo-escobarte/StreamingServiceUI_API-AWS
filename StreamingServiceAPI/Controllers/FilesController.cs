using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // Hardcoded AWS credentials and bucket name
        private const string AccessKey = "";
        private const string SecretKey = "";
        private const string BucketName = "mescobarte";
        private const string Region = "us-east-1";

        private readonly IAmazonS3 _s3client;

        public FilesController()
        {
            var region = Amazon.RegionEndpoint.USEast1;
            _s3client = new AmazonS3Client(AccessKey, SecretKey, region);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(IFormFile file, string? prefix)
        {
            try
            {
                var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_s3client, BucketName);
                if (!bucketExists) return NotFound($"Bucket {BucketName} does not exist.");

                var request = new PutObjectRequest()
                {
                    BucketName = BucketName,
                    Key = string.IsNullOrEmpty(prefix) ? file.FileName : $"{prefix?.TrimEnd('/')}/{file.FileName}",
                    InputStream = file.OpenReadStream()
                };
                request.Metadata.Add("Content-Type", file.ContentType);

                await _s3client.PutObjectAsync(request);
                return Ok($"File {prefix}/{file.FileName} uploaded successfully!");
            }
            catch (AmazonS3Exception e)
            {
                return StatusCode(500, $"Error uploading file: {e.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilesAsync(string? prefix)
        {
            try
            {
                var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_s3client, BucketName);
                if (!bucketExists) return NotFound($"Bucket {BucketName} does not exist.");

                var request = new ListObjectsV2Request()
                {
                    BucketName = BucketName,
                    Prefix = prefix
                };
                var result = await _s3client.ListObjectsV2Async(request);

                if (result.S3Objects == null || !result.S3Objects.Any())
                {
                    return Ok(new List<object>()); // Return an empty list if no files found
                }

                var s3Objects = result.S3Objects.Select(s =>
                {
                    var urlRequest = new GetPreSignedUrlRequest()
                    {
                        BucketName = BucketName,
                        Key = s.Key,
                        Expires = DateTime.UtcNow.AddMinutes(1)
                    };
                    return new { Name = s.Key, PresignedUrl = _s3client.GetPreSignedURL(urlRequest) };
                }).ToList();

                return Ok(s3Objects);
            }
            catch (AmazonS3Exception e)
            {
                return StatusCode(500, $"Error retrieving files: {e.Message}");
            }
        }

        [HttpGet("preview")]
        public async Task<IActionResult> GetFileByKeyAsync(string key)
        {
            try
            {
                var bucketExist = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_s3client, BucketName);
                if (!bucketExist) return NotFound($"Bucket {BucketName} does not exist.");

                var s3Object = await _s3client.GetObjectAsync(BucketName, key);
                return File(s3Object.ResponseStream, s3Object.Headers.ContentType);
            }
            catch (AmazonS3Exception e)
            {
                return StatusCode(500, $"Error retrieving file: {e.Message}");
            }
        }
    }
}
