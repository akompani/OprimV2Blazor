using Minio;
using Minio.ApiEndpoints;
using Minio.DataModel.Args;
using Oprim.Application.Interfaces;

namespace Oprim.Infrastructure.Repositories;

public class MinioService : IMinioService, IDisposable
{
    private readonly IMinioClient _client;
    private bool _disposed;

    public MinioService(string endpoint, string accessKey, string secretKey, bool useSsl = false)
    {
        if (string.IsNullOrWhiteSpace(endpoint)) throw new ArgumentException(nameof(endpoint));

        // build client
        _client = new MinioClient()
            .WithEndpoint(endpoint)
            .WithCredentials(accessKey, secretKey)
            .WithSSL(useSsl)
            .Build();
    }

    // Alternative constructor for DI using IConfiguration (example)
    public MinioService(Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        var section = configuration.GetSection("Minio");
        var endpoint = section["Endpoint"];
        var accessKey = section["AccessKey"];
        var secretKey = section["SecretKey"];
        var useSsl = bool.TryParse(section["UseSsl"], out var s) && s;

        _client = new MinioClient()
            .WithEndpoint(endpoint)
            .WithCredentials(accessKey, secretKey)
            .WithSSL(useSsl)
            .Build();
    }

    public async Task<bool> BucketExistsAsync(string bucketName, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _client.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName), cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task CreateBucketIfNotExistsAsync(string bucketName, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(bucketName)) throw new ArgumentException(nameof(bucketName));

        var exists = await BucketExistsAsync(bucketName, cancellationToken);
        if (!exists)
        {
            await _client.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName), cancellationToken);
        }
    }

    /// <summary>
    /// Uploads a stream to MinIO. Returns the objectName (or you can return presigned url if you want).
    /// objectName should include extension if you want correct content-type inference by consumers.
    /// </summary>
    public async Task<string> UploadFileAsync(string bucketName, string objectName, Stream data, string contentType,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(bucketName)) throw new ArgumentException(nameof(bucketName));
        if (string.IsNullOrWhiteSpace(objectName)) throw new ArgumentException(nameof(objectName));
        if (data == null) throw new ArgumentNullException(nameof(data));

        // Ensure bucket exists
        await CreateBucketIfNotExistsAsync(bucketName, cancellationToken);

        // MinIO PutObject expects a stream length when using WithObject, but PutObjectArgs has WithObjectSize.
        long? length = null;
        if (data.CanSeek)
        {
            length = data.Length - data.Position;
        }

        var putArgs = new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName)
            .WithStreamData(data);

        if (length.HasValue) putArgs = putArgs.WithObjectSize(length.Value);
        if (!string.IsNullOrEmpty(contentType)) putArgs = putArgs.WithContentType(contentType);

        await _client.PutObjectAsync(putArgs, cancellationToken);

        return objectName;
    }

    public async Task DownloadToStreamAsync(string bucketName, string objectName, Stream destination,
        CancellationToken cancellationToken = default)
    {
        if (destination == null) throw new ArgumentNullException(nameof(destination));

        await _client.GetObjectAsync(new GetObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName)
            .WithCallbackStream(stream =>
            {
                // callback invoked with the object's stream
                stream.CopyTo(destination);
            }), cancellationToken);
        // after return, destination will contain the object bytes
        if (destination.CanSeek)
            destination.Position = 0;
    }

    public async Task RemoveObjectAsync(string bucketName, string objectName,
        CancellationToken cancellationToken = default)
    {
        await _client.RemoveObjectAsync(new RemoveObjectArgs().WithBucket(bucketName).WithObject(objectName),
            cancellationToken);
    }


    public async Task<string> PresignedGetObjectUrlAsync(string bucketName, string objectName, int expirySeconds = 3600,
        CancellationToken cancellationToken = default)
    {
        var url = await _client.PresignedGetObjectAsync(
            new PresignedGetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithExpiry(expirySeconds)
        );

        return url;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            // MinioClient doesn't implement IDisposable (last I checked) but keep disposal pattern for future-proof
            _disposed = true;
        }
    }
}

