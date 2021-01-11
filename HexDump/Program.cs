using System;
using System.IO;
using System.Text;

namespace HexDump
{
    class Program
    {
        static void Main(string[] args)
        {
            var position = 0;
            using (Stream input = File.OpenRead(args[0]))
            {
                var buffer = new byte[16];
                int bytesRead; 
                    
                 while ((bytesRead = input.Read(buffer, 0, buffer.Length)) >0) {
                    Console.Write("{0:x4}: ", position);
                    position += bytesRead;

                    for (var i = 0; i < 16; i++)
                    {
                        if (i < bytesRead)
                            Console.Write("{0:x2} ", (byte)buffer[i]);
                        else
                            Console.Write("   ");
                        if (i == 7) Console.Write("-- ");
                        if (buffer[i] < 0x20 || buffer[i] > 0x7F) buffer[i] = (byte)'.';
                    }

                    var bufferContents = Encoding.UTF8.GetString(buffer);

                    Console.WriteLine("  {0}", bufferContents.Substring(0, bytesRead));


                    int b = 2380;
                    Console.WriteLine((byte)b);
                }

                    


                
            }
        }
    }
}
