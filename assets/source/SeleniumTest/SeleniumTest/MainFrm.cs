using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumTest
{
  public partial class MainFrm : Form
  {
    string url_Selenium_Test = "https://www.selenium.dev/selenium/web/web-form.html";
    string url_Upbit_BTC_KRW = "https://www.upbit.com/exchange?code=CRIX.UPBIT.KRW-BTC";
    string url_UURang_mail = "https://m158.mailplug.com/member/login?host_domain=uurang.co.kr";
    IWebDriver driver;

    string uurangMailId = "";
    string uurangMailPassword = "";
    string encodedString = string.Empty;
    string decodedString = string.Empty;

    public MainFrm()
    {
        InitializeComponent();
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
      txtbxMessage.Text += $"{Environment.NewLine}Selenium 스크래핑을 시작합니다.";
      //getChromDriver();
      //seleniumTestWork();

      SecuWork();
    }

    private void getBTC_info()
    {
      driver.Navigate().GoToUrl(url_Upbit_BTC_KRW);
    }

    private void getChromDriver()
    {
      var driverService = ChromeDriverService.CreateDefaultService();
      if (tgbtnCmd.IsOn)
      {
        driverService.HideCommandPromptWindow = false;
      }
      else
      {
        driverService.HideCommandPromptWindow = true; //크롬드라이버 CMD창 없애기
      }

      ChromeOptions options = new ChromeOptions();
      if (tgbtnBrows.IsOn)
      {

      }
      else
      {
        options.AddArguments("headless"); //headless 옵션 (백그라운드작업)
        options.AddArgument("ignore-certificate-errors");
      }

      driver = new ChromeDriver(driverService, options);
    }

    private void seleniumTestWork()
    {
      driver.Navigate().GoToUrl(url_Selenium_Test);

      string title = driver.Title;
      txtbxMessage.Text += $"{Environment.NewLine}'{title}' 브라우저 이동";

      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

      IWebElement textBox = driver.FindElement(By.Name("my-text"));
      IWebElement submitButton = driver.FindElement(By.TagName("button"));

      textBox.SendKeys("Selenium");
      submitButton.Click();

      IWebElement message = driver.FindElement(By.Id("message"));
      string value = message.Text;

      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);

      driver.Quit();

      txtbxMessage.Text += $"{Environment.NewLine}{value}";
    }

    private void SecuWork()
    {
      // 암호화 개체 생성
      RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

      // 개인키 생성(복호화용)
      RSAParameters privateKey = RSA.Create().ExportParameters(true);
      rsa.ImportParameters(privateKey);
      string privateKeyText = rsa.ToXmlString(true);

      // 공개키 생성(암호화용)
      RSAParameters publicKey = new RSAParameters();
      publicKey.Modulus = privateKey.Modulus;
      publicKey.Exponent = privateKey.Exponent;
      rsa.ImportParameters(publicKey);
      string publicKeyText = rsa.ToXmlString(false);

      encodedString = RSAEncrypt(uurangMailPassword, publicKeyText);
      decodedString = RSADecrypt(encodedString, privateKeyText);

      string encoTest = "t8czMuxZgDoABwz06T9jyrsxdMVyZ6BDWqmLYCNGFd0OUQkZ59lzS1iAM6BOwyHo+hWtqQUulCkj+JpV4O425RaHHIMjd2cW7Of7wge6SaVHTo7pIIni5CmU2ZfGnNd+mHv8cBJfNa3FdiWYVrygq9MGNusclVTDL69wxTd4WcU=";
      string privateTest = "<RSAKeyValue><Modulus>wtgKMZdMOwpEBOQbOyJjIL3QSfYQ+GI0bE2FX4bLsAavwR0ZYER1YpyXDqgPEC8JT0zMA/RDGowzBM9LqPg8FvMLcgdzF1Gd8rqSDg3Z47f1iekLfBKsnTWTypN8WQWDf+BprhNsTwhkNw8mj1BeGEFapfjSorXcfeRUXXlwNfE=</Modulus><Exponent>AQAB</Exponent><P>5fhQrzvnm3g28bItT+rhrzx7yphNg68q7mNzmy11UYes4B3vUOyZH3Hz3tEQlssB9sw0svllo00jExHz1VBYQw==</P><Q>2OXma2LD7cMLj8ucZ+0bLyDpFhkMkO8nfxYe4UoPTfFur48YPMpBg1cfA55n103UStznwysLP3neGrd/kgf/uw==</Q><DP>cSFnD814cpMA9IWipN33iC1I+LFT8KQLipqCFKSYQjNsaBRR1o2OBloYjlRqxMO5g5+RjToDNgKMbqU2Pon34Q==</DP><DQ>h73Bqd0iz48ski6UUPoz9Be9qCW/FomFh2SZqNcHovkBE4ATZCAURhVlBIfDZxx/SubbaOpsXKpxVPkYLpUw9w==</DQ><InverseQ>5EsgBTQLoK5XUywX2bW/Q4UC3Q4aKG+d+eHvk9h6+UNO9uAKPxqwHdBRFgpZHDigtPEy66/5W6GUOsnSubhtKA==</InverseQ><D>MOdKf7HqxzLHabbbAteZq8EYg0fIcJ8tazV10Uki3JaBDGZCVUA5eju1Sk9yIGy92HJ9Dk0DfqlLsNxasBlF80h6Rbzlf/v2kSZyaMhxh8B7iGf1P2zlp21b71IPu0O1PgJppx4OMh3Cd6zlc0/tdCg6JjpvgD/rt7aVXTSXWvU=</D></RSAKeyValue>";
      string decotest = RSADecrypt(encoTest, privateTest);
    }


    // RSA 암호화
    private string RSAEncrypt(string getValue, string pubKey)
    {
      RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
      rsa.FromXmlString(pubKey);

      //암호화할 문자열을 UFT8인코딩
      byte[] inbuf = (new UTF8Encoding()).GetBytes(getValue);

      //암호화
      byte[] encbuf = rsa.Encrypt(inbuf, false);

      //암호화된 문자열 Base64인코딩
      return System.Convert.ToBase64String(encbuf);
    }

    // RSA 복호화
    private string RSADecrypt(string getValue, string priKey)
    {
      RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
      rsa.FromXmlString(priKey);

      //sValue문자열을 바이트배열로 변환
      byte[] srcbuf = System.Convert.FromBase64String(getValue);

      //바이트배열 복호화
      byte[] decbuf = rsa.Decrypt(srcbuf, false);

      //복호화 바이트배열을 문자열로 변환
      string sDec = (new UTF8Encoding()).GetString(decbuf, 0, decbuf.Length);
      return sDec;
    }

  }
}
