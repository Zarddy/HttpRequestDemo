using System;
using System.IO;
using System.Net;
using System.Text;

namespace HttpRequestDemo
{
    class HttpRequest
    {

        public static string get(string url)
        {
            return submitHttpRequest(url, "GET", "");
        }

        public static string get(string url, string data)
        {
            return submitHttpRequest(url, "GET", data);
        }

        public static string post(string url)
        {
            return submitHttpRequest(url, "POST", "");
        }

        public static string post(string url, string data)
        {
            return submitHttpRequest(url, "POST", data);
        }

        public static string submitHttpRequest(string url, string method, string data)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);

                request.Method = method;

                if (data != null && data.Length > 0)
                {
                    // Create POST data and convert it to a byte array.
                    string postData = data;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                    // Set the ContentType property of the WebRequest.
                    request.ContentType = "application/x-www-form-urlencoded";

                    // Set the ContentLength property of the WebRequest.
                    request.ContentLength = byteArray.Length;

                    // Get the request stream.
                    Stream requestDataStream = request.GetRequestStream();

                    // Write the data to the request stream.
                    requestDataStream.Write(byteArray, 0, byteArray.Length);

                    // Close the Stream object.
                    requestDataStream.Close();
                }

                // Get the original response.
                WebResponse response = request.GetResponse();

                // Get the stream containing all content returned by the requested server.
                Stream dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);

                // Read the content fully up to the end.
                string responseFromServer = reader.ReadToEnd();

                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer;
            }
            catch (Exception e)
            {
                return "网络请求出错";
            }
        }
    }
}
