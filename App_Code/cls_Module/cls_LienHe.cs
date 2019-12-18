using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for cls_NewsCate
/// </summary>
public class cls_LienHe
{
    dbcsdlDataContext db = new dbcsdlDataContext();
	public cls_LienHe()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Linq_Them(   string email, string phone,string address )
    {
        tbLienHe insert = new tbLienHe(); 
        insert.lienhe_address = address;
        insert.lienhe_email = email;
        insert.lienhe_phone = phone ;
        db.tbLienHes.InsertOnSubmit(insert);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Linq_Sua(int lienhe_id,  string email, string phone, string address)
    {

        tbLienHe update = db.tbLienHes.Where(x => x.lienhe_id == lienhe_id).FirstOrDefault(); 
        update.lienhe_address = address;
        update.lienhe_email = email;
        update.lienhe_phone = phone ;
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Linq_Xoa(int lienhe_id)
    {
        tbLienHe delete = db.tbLienHes.Where(x => x.lienhe_id == lienhe_id).FirstOrDefault();
        db.tbLienHes.DeleteOnSubmit(delete);
        try
        {
            db.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}