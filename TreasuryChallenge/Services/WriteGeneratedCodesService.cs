using TreasuryChallenge.Interfaces;

namespace TreasuryChallenge.Services
{
    public class WriteGeneratedCodesService
    {
        private readonly IFileService FileService;

        public WriteGeneratedCodesService(IFileService fileService)
        {
            FileService = fileService;
        }

        public void Write(string codes)
        {
            FileService.SaveText(codes);
        }
    }
}
