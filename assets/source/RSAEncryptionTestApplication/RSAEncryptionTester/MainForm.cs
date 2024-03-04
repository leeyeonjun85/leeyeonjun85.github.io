using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using RSAEncryptionLib;

namespace RSAEncryptionTester
{
    public partial class MainForm : Form
    {
        RSAEncryption myRsa = new RSAEncryption();

        public MainForm()
        {
            InitializeComponent();
        }

        private void createKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string privateKey = rsa.ToXmlString(true);
            File.WriteAllText(Application.StartupPath + "\\PrivateKey.xml", privateKey);
            string publicKey = rsa.ToXmlString(false);
            File.WriteAllText(Application.StartupPath + "\\PublicKey.xml", publicKey);
            MessageBox.Show("The Key pair created successfully at:\n" + Application.StartupPath);
        }

        private void loadKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openKeyFileDialog.InitialDirectory = Application.StartupPath;
            if (openKeyFileDialog.ShowDialog() != DialogResult.OK)
                return;

            // Determine which LoadKey menu item was selected (public or private)
            bool isLoadPrivate =
                (sender as ToolStripMenuItem).Name == "loadPrivateKeyToolStripMenuItem" ? true : false;

            try
            {
                if (isLoadPrivate)
                    myRsa.LoadPrivateFromXml(openKeyFileDialog.FileName);  // Loading the private key to the custom RSA instance
                else
                    myRsa.LoadPublicFromXml(openKeyFileDialog.FileName);  // Or the public Key

                if (!chkShowData.Checked)  // Does the user want to see the Key components in the form?
                    return;  // I guess not

                // If he does, Loading the key to .NET RSA class, to show is components in the form:
                RSACryptoServiceProvider localRsa = new RSACryptoServiceProvider();
                localRsa.FromXmlString(File.ReadAllText(openKeyFileDialog.FileName));
                RSAParameters rsaParams = localRsa.ExportParameters(isLoadPrivate);
                txtExponent.Text = GetHexString(rsaParams.Exponent);
                txtModulus.Text = GetHexString(rsaParams.Modulus);
                if (isLoadPrivate)
                    txtD.Text = GetHexString(rsaParams.D);  // This parameter is in private key only

                // Clearing the RSA instance
                localRsa.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred while trying to load a Key,\nMessage: " + ex.Message);
            }
        }

        private void EncryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine which Encryption menu item was selected (public or private)
            bool isEncryptPrivate =
                (sender as ToolStripMenuItem).Name == "privateEncryptionToolStripMenuItem" ? true : false;

            // Check if the proper key has been loaded to the rsa class
            if (isEncryptPrivate && !myRsa.IsPrivateKeyLoaded)
            {
                    MessageBox.Show("Please Load the Private Key before the Encryption.");
                    return;
            }
            else if(!isEncryptPrivate && !myRsa.IsPublicKeyLoaded)
            {
                    MessageBox.Show("Please Load the Public Key before the Encryption.");
                    return;
            }

            try
            {
                byte[] message = Encoding.UTF8.GetBytes(txtMessage.Text);
                byte[] encMessage = null;
                if (isEncryptPrivate)  // Calling the right encryption method according to the user selection
                    encMessage = myRsa.PrivateEncryption(message);
                else
                    encMessage = myRsa.PublicEncryption(message);

                txtEncMsg.Text = Convert.ToBase64String(encMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred while trying to encrypt the data,\nMessage: " + ex.Message);
            }
        }

        private void DecryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine which Decryption menu item was selected (public or private)
            bool isDecryptPrivate =
                (sender as ToolStripMenuItem).Name == "privateDecryptionToolStripMenuItem" ? true : false;

            // Check if the proper key has been loaded to the rsa class
            if (isDecryptPrivate && !myRsa.IsPrivateKeyLoaded)
            {
                    MessageBox.Show("Please Load the Private Key before the Deccryption.");
                    return;
            }
            else if(!isDecryptPrivate && !myRsa.IsPublicKeyLoaded)
            {
                    MessageBox.Show("Please Load the Public Key before the Decryption.");
                    return;
            }

            try
            {
                byte[] decMessage = Convert.FromBase64String(txtEncMsg.Text);
                byte[] message = null;
                if (isDecryptPrivate)  // Calling the right decryption method according to the user selection
                    message = myRsa.PrivateDecryption(decMessage);
                else
                    message = myRsa.PublicDecryption(decMessage);

                string sMsg = Encoding.UTF8.GetString(message);
                MessageBox.Show("The Decrypted Message is:\n" + sMsg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred while trying to decrypt the data,\nMessage: " + ex.Message);
            }
        }

        private string GetHexString(byte[] byteArray)
        {
            StringBuilder hexString = new StringBuilder(byteArray.Length * 2);
            for (int i = 0; i < byteArray.Length; i++)
                hexString.Append(string.Format("{0:X}", byteArray[i]));
            int x = hexString.Capacity;
            return hexString.ToString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myRsa.Dispose();
        }
    }
}
