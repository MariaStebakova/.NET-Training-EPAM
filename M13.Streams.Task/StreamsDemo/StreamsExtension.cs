using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int bytes = 0;
            byte[] sourceBytes;

            using (FileStream sourceStream = File.OpenRead(sourcePath))
            {
                sourceBytes = new byte[sourceStream.Length];
                sourceStream.Read(sourceBytes, 0, sourceBytes.Length);
            }

            using (FileStream destinationStream = File.OpenWrite(destinationPath))
            {
                for (int i = 0; i < sourceBytes.Length; i++)
                {
                    destinationStream.WriteByte(sourceBytes[i]);
                    bytes++;
                }

            }

            return bytes;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            string sourceData;

            // TODO: step 1. Use StreamReader to read entire file in string
            using (StreamReader streamReader = new StreamReader(sourcePath, Encoding.UTF8))
            {
                sourceData = streamReader.ReadToEnd();
            }

            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
            byte[] sourceBytes = Encoding.UTF8.GetBytes(sourceData);

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)
            int srcBytesLen = sourceBytes.Length;
            MemoryStream memStream = new MemoryStream(sourceBytes);
            memStream.Write(sourceBytes, 0, srcBytesLen);
            memStream.Position = 0;

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
            byte[] destinationBytes = new byte[srcBytesLen];
            memStream.Read(destinationBytes, 0, srcBytesLen);

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content
            char[] charArray = Encoding.UTF8.GetChars(destinationBytes);

            // TODO: step 6. Use StreamWriter here to write char array content in new file
            using (StreamWriter streamWriter = new StreamWriter(File.Create(destinationPath), Encoding.UTF8))
            {
                for (int i = 0; i < charArray.Length; i++)
                {
                    streamWriter.Write(charArray[i]);
                }
            }

            return charArray.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int bytes;
            int bytesByDefault = 100;

            using (FileStream readStream = File.OpenRead(sourcePath))
            {
                using (FileStream writeStream = new FileStream(destinationPath, FileMode.Open))
                {
                    byte[] temp = new byte[bytesByDefault];
                    while (readStream.Read(temp, 0, temp.Length) > 0)
                    {
                        writeStream.Write(temp, 0, temp.Length);
                    }
                    bytes = (int)readStream.Length;
                }
            }

            return bytes;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            // TODO: Use InMemoryByByteCopy method's approach
            InputValidation(sourcePath, destinationPath);

            string readingResult;

            using (StreamReader streamReader = new StreamReader(sourcePath, Encoding.UTF8))
            {
                readingResult = streamReader.ReadToEnd();
            }

            byte[] readingResultBytes = Encoding.UTF8.GetBytes(readingResult);
            byte[] writingBytes;

            using (MemoryStream memoryStream = new MemoryStream(readingResultBytes, 0, readingResultBytes.Length))
            {
                memoryStream.Write(readingResultBytes, 0, readingResultBytes.Length);
                writingBytes = memoryStream.ToArray();
            }

            char[] writingChars = Encoding.UTF8.GetChars(writingBytes);

            using (StreamWriter streamWriter = new StreamWriter(destinationPath, false, Encoding.UTF8))
            {
                streamWriter.WriteLine(writingChars);
            }

            return writingBytes.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int bufferSize = 10000;
            byte[] readingBytes;

            using (FileStream stream = new FileStream(sourcePath, FileMode.Open))
            using (BufferedStream bufferedStream = new BufferedStream(stream, bufferSize))
            {
                readingBytes = new byte[stream.Length];
                bufferedStream.Read(readingBytes, 0, readingBytes.Length);
            }

            using (FileStream writeStream = new FileStream(destinationPath, FileMode.Open))
            {
                writeStream.Write(readingBytes, 0, readingBytes.Length);
            }

            return readingBytes.Length;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            int lineCount = 0;
            string buffer;

            using (Stream sourceStream = new FileStream(sourcePath, FileMode.Open))
            using (TextReader sourceTextReader = new StreamReader(sourceStream))
            using (TextWriter destTextWriter = new StreamWriter(destinationPath))
            {
                
                buffer = sourceTextReader.ReadLine();
                while (buffer != null)
                {
                    destTextWriter.WriteLine(buffer);
                    lineCount++;
                    buffer = sourceTextReader.ReadLine();
                }
                
            }

            return lineCount;
            
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            if (!File.Exists(destinationPath))
                throw new ArgumentException($"{nameof(destinationPath)} must exist");

            byte[] lhs = File.ReadAllBytes(sourcePath);
            byte[] rhs = File.ReadAllBytes(destinationPath);
            for (int i = 0; i < lhs.Length; i++)
            {
                if (lhs[i] != rhs[i])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (String.IsNullOrEmpty(sourcePath))
                throw new ArgumentException($"{nameof(sourcePath)} can't be null of empty");

            if (!File.Exists(sourcePath))
                throw new ArgumentException($"{nameof(sourcePath)} must exist");

            if (String.IsNullOrEmpty(destinationPath))
                throw new ArgumentException($"{nameof(destinationPath)} can't be null of empty");

            /*if (!File.Exists(destinationPath))
                throw new ArgumentException($"{nameof(destinationPath)} must exist");*/
        }

        #endregion

        #endregion

    }
}
