using BusinessLogic.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Helpers
{
    public class StoragePathHelper : IStoragePathHelper
    {
        private readonly FileStorageConfig _fileStorageConfig;

        public StoragePathHelper(IOptions<FileStorageConfig> fileStorageConfigs)
        {
            _fileStorageConfig = fileStorageConfigs.Value;
        }

        public string ProductImagesPathString() => _fileStorageConfig.Products;
    }

    public interface IStoragePathHelper
    {
        string ProductImagesPathString();
    }
}
