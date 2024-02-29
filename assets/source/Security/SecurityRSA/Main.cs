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

namespace SecurityRSA
{
  public partial class Main : Form
  {
    public Main()
    {
        InitializeComponent();
    }

    string encodedString = string.Empty;
    string decodedString = string.Empty;
    string privateKeyText = string.Empty;
    string publicKeyText = string.Empty;

    private void btnRun_Click(object sender, EventArgs e)
    {
      SecuWork();

      tbxMessage.Text = $"■ RSA 암호화 성공";
      tbxMessage.Text += $"{Environment.NewLine}   ■ 입력 텍스트";
      tbxMessage.Text += $"{Environment.NewLine}{tbxInput.Text}";
      tbxMessage.Text += $"{Environment.NewLine}   ■ 암호화 텍스트";
      tbxMessage.Text += $"{Environment.NewLine}{encodedString}";
      tbxMessage.Text += $"{Environment.NewLine}   ■ 복호화 텍스트";
      tbxMessage.Text += $"{Environment.NewLine}{decodedString}";
      tbxMessage.Text += $"{Environment.NewLine}   ■ 공개키";
      tbxMessage.Text += $"{Environment.NewLine}{publicKeyText}";
      tbxMessage.Text += $"{Environment.NewLine}   ■ 개인키";
      tbxMessage.Text += $"{Environment.NewLine}{privateKeyText}";
    }
    private void SecuWork()
    {
      // 암호화 개체 생성
      RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

      // 개인키 생성(복호화용)
      RSAParameters privateKey = RSA.Create().ExportParameters(true);
      rsa.ImportParameters(privateKey);
      privateKeyText = rsa.ToXmlString(true);

      // 공개키 생성(암호화용)
      RSAParameters publicKey = new RSAParameters
      {
        Modulus = privateKey.Modulus,
        Exponent = privateKey.Exponent
      };
      rsa.ImportParameters(publicKey);
      publicKeyText = rsa.ToXmlString(false);

      encodedString = RSAEncrypt(tbxInput.Text, publicKeyText);
      decodedString = RSADecrypt(encodedString, privateKeyText);
    }

    private string RSAEncrypt(string getValue, string pubKey)
    {
      RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
      rsa.FromXmlString(pubKey);

      byte[] inbuf = (new UTF8Encoding()).GetBytes(getValue);
      byte[] encbuf = rsa.Encrypt(inbuf, false);

      return System.Convert.ToBase64String(encbuf);
    }

    private string RSADecrypt(string getValue, string priKey)
    {
      RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
      rsa.FromXmlString(priKey);

      byte[] srcbuf = System.Convert.FromBase64String(getValue);
      byte[] decbuf = rsa.Decrypt(srcbuf, false);

      string sDec = (new UTF8Encoding()).GetString(decbuf, 0, decbuf.Length);
      return sDec;
    }
  }
}
