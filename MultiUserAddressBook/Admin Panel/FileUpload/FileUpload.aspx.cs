using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MultiUserAddressBook_Admin_Panel_FileUpload_FileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if(fuFile.HasFile)
        {
            //lblMessage.Text = "File is Selected" + fuFile.FileName.ToString().Trim();
            string FolderPath = "~/MultiUserAddressBook/Admin Panel/SaveUploadedFie/";
            string AbsolutePath = Server.MapPath(FolderPath);
            lblMessage.Text = "File Will be Uploaded at this Location" + AbsolutePath;
            if(!Directory.Exists(AbsolutePath))
                Directory.CreateDirectory(AbsolutePath);

            fuFile.SaveAs(AbsolutePath + fuFile.FileName.ToString().Trim());
        }
        else
        {
            lblMessage.Text = "You Have Not Selected a File";
        }
    }

    protected void btnDeletFile_Click(object sender, EventArgs e)
    {
        string filepath = "~/MultiUserAddressBook/Admin Panel/SaveUploadedFie/";
        FileInfo file = new FileInfo(Server.MapPath(filepath));
        if(file.Exists)
        {
            file.Delete();
        }
        else
        {
            lblMessage.Text = "File is Not avaible";
        }
    } 
}