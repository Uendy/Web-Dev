using System.IO;
public class Program
{
    public static void Main()
    {
        const int defSize = 4096;

        var reader = new FileStream("Bruno.jpg", FileMode.Open);

        using (reader)
        {
            var buffer = new byte[defSize];
            File.Delete("Copy.jpg");
            var writer = new FileStream("Copy.jpg", FileMode.Create);
            using (writer)
            {
                while (reader.CanRead)
                {
                    int bytesRead = reader.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        break;
                    }
                    writer.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}