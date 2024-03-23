using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
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
    string _imagePath = @"D:\leeyeonjun\leeyeonjun85.github.io\assets\source\ocr\invoice-template-en-band-blue-750px.png";
    string _hostUrl = @"http://127.0.0.1:6714/TestOCR";

    public Form1()
    {
      InitializeComponent();    
    }

    private async void BtnOCR_Click(object sender, EventArgs e)
    {

      await Task.Run(() =>
      {
        try
        {
          this.BeginInvoke(new Action(() =>
          {
            lbStatus.Text = $"Status : OCR 작업중......";
            progressBar1.Visible = true;
          }));
          _imagePath = textBox2.Text;

          // Read file data
          FileStream fs = new FileStream(_imagePath, FileMode.Open, FileAccess.Read);
          byte[] data = new byte[fs.Length];
          fs.Read(data, 0, data.Length);
          fs.Close();

          // Generate post objects
          Dictionary<string, object> postParameters = new Dictionary<string, object>();
          postParameters.Add("filename", "image1.png");
          postParameters.Add("fileformat", "png");
          postParameters.Add("image1", new RequestManager.FileParameter(data, "image1.png", "image/png"));

          // Create request and receive response
          string postURL = _hostUrl;
          string userAgent = "Someone";
          HttpWebResponse webResponse = RequestManager.MultipartFormDataPost(postURL, userAgent, postParameters);

          // Process response
          StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
          string fullResponse = responseReader.ReadToEnd();
          webResponse.Close();

          JObject ret = JObject.Parse(fullResponse);
          string ocrByteString = (string)ret["ocrEncodedString"];
          byte[] imageBytes = Convert.FromBase64String(ocrByteString);

          this.BeginInvoke(new Action(() =>
          {
            for (int i = 0; i < ret["scores"].Count(); i++)
            {
              tbxLog.Text += $"{ret["txts"][i]} : {ret["scores"][i]}{Environment.NewLine}";
            }
            pbxImage.Image = Image.FromStream(new MemoryStream(imageBytes));
            Application.DoEvents();
          }));
        }
        catch (Exception ex)
        {
          MessageBox.Show("오류 발생: " + ex.Message);
        }
        finally
        {
          this.BeginInvoke(new Action(() =>
          {
            progressBar1.Visible = false;
            lbStatus.Text = $"Status : Ready";
          }));
        }
      });
      
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
                ContentType = "image/png",
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
        request.ContentType = "application/octet-stream";

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

              tbxLog.Text += $"{key2}";
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

    private void button5_Click(object sender, EventArgs e)
    {

    }

    private void BtnOpenFileDialog_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Title = "이미지파일 선택";
      ofd.FileName = "test";
      ofd.Filter = "그림 파일 (*.jpg, *.jpeg, *.gif, *.bmp, *.png) | *.jpg; *.jpeg; *.gif; *.bmp; *.png; | 모든 파일 (*.*) | *.*";

      DialogResult dr = ofd.ShowDialog();

      if (dr == DialogResult.OK)
      {
        textBox2.Text = ofd.FileName;
        lbStatus.Text = $"Status : {ofd.FileName} 이미지 불러옴";
      }
      else if (dr == DialogResult.Cancel)
      {
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
