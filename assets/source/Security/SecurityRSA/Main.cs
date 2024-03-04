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
    string encodedString = string.Empty;
    string decodedString = string.Empty;
    string privateKeyText = string.Empty;
    string publicKeyText = string.Empty;

    public Main()
    {
        InitializeComponent();
    }

    private void btnGetPublicKey_Click(object sender, EventArgs e)
    {

    }


    private void btnGetPublicKey_Click_1(object sender, EventArgs e)
    {

    }

    private void btnGetPrivateKey_Click(object sender, EventArgs e)
    {

    }



    private void btnEncrypt_Click(object sender, EventArgs e)
    {
      encodedString = RSAEncrypt(tbxNomalText.Text, tbxPublicKey.Text);

      tbxMessage.Text += $"{Environment.NewLine}{Environment.NewLine}   ■■■■ RSA 암호화 성공 ■■■■";
      tbxMessage.Text += $"{Environment.NewLine}   ■ Nomal Text";
      tbxMessage.Text += $"{Environment.NewLine}{tbxNomalText.Text}";
      tbxMessage.Text += $"{Environment.NewLine}{Environment.NewLine}   ■ Encrypt Text";
      tbxMessage.Text += $"{Environment.NewLine}{encodedString}";
    }

    private void btnDecrypt_Click(object sender, EventArgs e)
    {
      decodedString = RSADecrypt(tbxEncryptText.Text, tbxPrivateKey.Text);

      tbxMessage.Text += $"{Environment.NewLine}{Environment.NewLine}   ■■■■ RSA 복호화 성공 ■■■■";
      tbxMessage.Text += $"{Environment.NewLine}   ■ Encrypted Text 텍스트";
      tbxMessage.Text += $"{Environment.NewLine}{tbxEncryptText.Text}";
      tbxMessage.Text += $"{Environment.NewLine}{Environment.NewLine}   ■ Decrypt Text";
      tbxMessage.Text += $"{Environment.NewLine}{decodedString}";
    }

    private (string privateKeyText, string publicKeyText) GenerateKey()
    {
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

      return (privateKeyText, publicKeyText);
    }

    private string RSAEncrypt(string stringToEncrypt, string publicKey)
    {
      RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
      rsa.FromXmlString(publicKey);

      byte[] inputArray = (new UTF8Encoding()).GetBytes(stringToEncrypt);
      byte[] encryptedArray = rsa.Encrypt(inputArray, false);

      return Convert.ToBase64String(encryptedArray);
    }

    private string RSADecrypt(string stringToDecrypt, string privateKey)
    {
      RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
      rsa.FromXmlString(privateKey);

      byte[] inputArray = Convert.FromBase64String(stringToDecrypt);
      byte[] decryptedArray = rsa.Decrypt(inputArray, false);

      return (new UTF8Encoding()).GetString(decryptedArray, 0, decryptedArray.Length);
    }

  }
}
