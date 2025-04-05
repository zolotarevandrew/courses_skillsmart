namespace h_work.lesson98;

public interface IOfficeToPdfConverter
{
    Task<byte[]> ConvertAsync(string fileName, byte[] bytes);
    Task<byte[]> MergeAsync(byte[] byte1, byte[] byte2);
    Task<byte[]> ConvertHtmlToPdfAsync(byte[] bytes);
}