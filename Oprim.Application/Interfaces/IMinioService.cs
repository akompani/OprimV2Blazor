namespace Oprim.Application.Interfaces;

public interface IMinioService
{
    Task<bool> BucketExistsAsync(string bucketName, CancellationToken cancellationToken = default);
    Task CreateBucketIfNotExistsAsync(string bucketName, CancellationToken cancellationToken = default);
    Task<string> UploadFileAsync(string bucketName, string objectName, Stream data, string contentType, CancellationToken cancellationToken = default);
    Task DownloadToStreamAsync(string bucketName, string objectName, Stream destination, CancellationToken cancellationToken = default);
    Task RemoveObjectAsync(string bucketName, string objectName, CancellationToken cancellationToken = default);
    Task<string> PresignedGetObjectUrlAsync(string bucketName, string objectName, int expirySeconds = 3600, CancellationToken cancellationToken = default);

}