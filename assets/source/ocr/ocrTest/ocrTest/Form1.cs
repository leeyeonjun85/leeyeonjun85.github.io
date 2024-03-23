using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace ocrTest
{
  public partial class Form1 : Form
  {
    readonly string _imagePath = @"D:\leeyeonjun\leeyeonjun85.github.io\assets\source\ocr\invoice-template-en-band-blue-750px.png";
    readonly string _hostUrl = @"http://localhost/TestOCR";

    public Form1()
    {
      InitializeComponent();    
    }

    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        using (var client = new WebClient())
        {
          using (var stream = new MemoryStream())
          using (var writer = new StreamWriter(stream))
          {
            // 첫 번째 이미지 파일 추가
            writer.Write("--boundary\r\n");
            writer.Write("Content-Disposition: form-data; name=\"image1\"; filename=\"image1.jpg\"\r\n");
            writer.Write("Content-Type: image/jpeg\r\n");
            writer.Write("\r\n");
            writer.Flush();

            using (var fileStream = File.OpenRead(_imagePath))
            {
              fileStream.CopyTo(stream);
            }

            writer.Write("\r\n--boundary--\r\n");
            writer.Flush();

            // 요청 설정
            client.Headers["Content-Type"] = "multipart/form-data; boundary=boundary";
            byte[] formData = stream.ToArray();

            // POST 요청 보내기
            byte[] responseBytes = client.UploadData(_hostUrl, "POST", formData);

            // 응답 출력
            string responseString = System.Text.Encoding.UTF8.GetString(responseBytes);
            Console.WriteLine(responseString);
             
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("오류 발생: " + ex.Message);
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        string result = string.Empty; // 전송 후 결과값
        result = RequestHelper.PostMultipart(
          _hostUrl,
          new Dictionary<string, object>()
          {
            { "image1", new FormFile()
              {
                Name = "image1.png",
                ContentType = "application/png",
                FilePath = _imagePath
              }
            }
          });
      }
      catch (Exception ex)
      {
        MessageBox.Show("오류 발생: " + ex.Message);
      }
    }

    private async void button3_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// octet-stream 방식으로 POST 하기
    /// 서버에서 file = request.data 로 받음
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button4_Click(object sender, EventArgs e)
    {
      try
      {
        // 이미지 파일을 바이트 배열로 읽기
        byte[] imageBytes = File.ReadAllBytes(_imagePath);

        // HttpWebRequest 생성
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_hostUrl);
        request.Method = "POST";
        request.ContentType = "application/octet-stream"; // 이미지 파일의 MIME 타입에 맞게 수정

        // 이미지 바이트 배열을 요청 본문에 쓰기
        using (Stream requestStream = request.GetRequestStream())
        {
          requestStream.Write(imageBytes, 0, imageBytes.Length);
        }

        // 응답 받기
        //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //using (Stream responseStream = response.GetResponseStream())
        //using (MemoryStream memoryStream = new MemoryStream())
        //{
        //  responseStream.CopyTo(memoryStream);
        //  byte[] resizedImageBytes = memoryStream.ToArray();
        //  // 클라이언트에서 받은 이미지를 저장하거나 다른 작업 수행
        //  // 여기서는 간단히 출력만 하겠습니다.
        //  Console.WriteLine("이미지 받음. 크기: " + resizedImageBytes.Length + " bytes");
        //}
        using (WebResponse response = request.GetResponse())
        {
          using (Stream responseStream = response.GetResponseStream())
          using (StreamReader reader = new StreamReader(responseStream))
          {
            string result = reader.ReadToEnd();

            JObject ret = JObject.Parse(result);

            foreach (KeyValuePair<string, JToken> item in ret)
            {
              string key1 = item.Key;
              JToken key2 = item.Value;

              textBox1.Text += $"{key2}";
              //foreach (JToken item1 in key2)
              //{
              //  textBox1.Text += $"{item1}";
              //}
            }
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("오류 발생: " + ex.Message);
      }
    }
  }


  public class FileForm
  {
    public string Name { get; set; }
    public string ContentType { get; set; }
    public string FilePath { get; set; }
    public Stream Stream { get; set; }
  }
}
